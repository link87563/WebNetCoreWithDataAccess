-- --------------------------------------------------------
-- 主機:                           127.0.0.1
-- 伺服器版本:                        10.3.10-MariaDB - mariadb.org binary distribution
-- 伺服器操作系統:                      Win64
-- HeidiSQL 版本:                  9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- 傾印 mao 的資料庫結構
CREATE DATABASE IF NOT EXISTS `mao` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `mao`;

-- 傾印  表格 mao.user 結構
CREATE TABLE IF NOT EXISTS `user` (
  `row_num` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `user_name` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `user_password` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `user_token` varchar(500) COLLATE utf8_bin DEFAULT NULL,
  `is_active` varchar(2) COLLATE utf8_bin DEFAULT 'Y',
  `created_date` datetime DEFAULT NULL,
  `updated_date` datetime DEFAULT NULL,
  PRIMARY KEY (`row_num`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- 正在傾印表格  mao.user 的資料：~6 rows (大約)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`row_num`, `user_id`, `user_name`, `user_password`, `user_token`, `is_active`, `created_date`, `updated_date`) VALUES
	(1, 'aaa', 'JJJ', '123', 'c31f972d89cc4e6e9505ea322665f0a4', 'N', '2019-12-30 14:37:45', '2020-02-14 00:58:13'),
	(2, 'bbb', 'BBBB', '4456', NULL, 'Y', '2019-12-30 14:37:45', '2019-12-30 14:36:52'),
	(3, 'ccc', 'CCC', '789', NULL, 'Y', '2019-12-31 13:19:17', NULL),
	(6, 'hhh', 'HHH', 'a123', NULL, 'Y', '2020-02-10 18:44:15', NULL),
	(7, 'ddd', '好', 'b456', NULL, 'Y', '2020-02-10 18:57:48', NULL),
	(8, 'ttt', '好', 'c789', NULL, 'Y', '2020-02-10 18:58:16', NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
