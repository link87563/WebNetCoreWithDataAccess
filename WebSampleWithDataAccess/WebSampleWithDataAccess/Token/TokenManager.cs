using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSampleWithDataAccess.Entities;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using WebSampleWithDataAccess.DataAccess.Interface;
using WebSampleWithDataAccess.DataAccess.Base;

namespace WebSampleWithDataAccess.Token
{
    public class TokenManager : ITokenManager
    {
        private IHttpContextAccessor _accessor;
        public string key = "AAAAAAAAAA-BBBBBBBBBB-CCCCCCCCCC-DDDDDDDDDD-EEEEEEEEEE-FFFFFFFFFF-GGGGGGGGGG";

        public TokenManager(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        /// Create Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Entities.Token Create(User user)
        {
            // expired time
            var exp = 3600;

            var payload = new Payload
            {
                UserInfo = user,
                // Unix time tag
                exp = Convert.ToInt32(
                    (DateTime.Now.AddSeconds(exp) -
                     new DateTime(1970, 1, 1)).TotalSeconds)
            };

            var json = JsonConvert.SerializeObject(payload);
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            var iv = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);

            // Use ASE encrypt payload
            var encrypt = TokenCrypto.AESEncrypt(base64, key.Substring(0, 16), iv);

            // Get signature
            var signature = TokenCrypto.ComputedHMACSHA256(iv + "." + encrypt, key.Substring(0, 64));

            return new Entities.Token
            {
                // Substring iv + encrypt + signature 
                AccessToken = iv + "." + encrypt + "." + signature,
                // Use Guid
                RefreshToken = Guid.NewGuid().ToString().Replace("-", ""),
                Expires = exp
            };
        }

        /// <summary>
        /// Get user info
        /// </summary>
        /// <returns></returns>
        public IResult GetUser()
        {
            var result = new Result();
            try
            {
                var token = _accessor.HttpContext.Request.Headers["Authorization"].ToString();

                var split = token.Split(".");
                var iv = split[0];
                var encrypt = split[1];
                var signature = split[2];

                if (signature != TokenCrypto.ComputedHMACSHA256(iv + "." + encrypt, key.Substring(0, 64)))
                {
                    return result.Fail("No Data");
                }

                var base64 = TokenCrypto.AESDecrypt(encrypt, key.Substring(0, 16), iv);
                var json = Encoding.UTF8.GetString(Convert.FromBase64String(base64));
                var payload = JsonConvert.DeserializeObject<Payload>(json);

                if (payload.exp < Convert.ToInt32((DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds))
                {
                    return result.Fail("No data");
                }

                result.Data = payload.UserInfo;
                result.Success();
            }
            catch (Exception ex)
            {
                result.Fail(ex.Message);
            }
            return result;
        }
    }
}
