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
  `user_id` varchar(50) DEFAULT NULL,
  `user_name` varchar(50) DEFAULT NULL,
  `is_active` varchar(2) DEFAULT 'Y',
  `created_date` datetime DEFAULT NULL,
  `updated_date` datetime DEFAULT NULL,
  PRIMARY KEY (`row_num`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- 正在傾印表格  mao.user 的資料：~2 rows (大約)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`row_num`, `user_id`, `user_name`, `is_active`, `created_date`, `updated_date`) VALUES
	(1, 'aaa', 'JJJ', 'N', '2019-12-30 14:37:45', '2019-12-31 13:34:38'),
	(2, 'bbb', 'BBBB', 'Y', '2019-12-30 14:37:45', '2019-12-30 14:36:52'),
	(3, 'ccc', 'CCC', 'Y', '2019-12-31 13:19:17', NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
