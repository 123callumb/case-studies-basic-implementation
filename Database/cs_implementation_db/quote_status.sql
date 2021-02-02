-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.17-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             11.1.0.6116
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for table cs_implementation_db.quote_status
DROP TABLE IF EXISTS `quote_status`;
CREATE TABLE IF NOT EXISTS `quote_status` (
  `QuoteStatusID` int(11) NOT NULL AUTO_INCREMENT,
  `StatusName` varchar(50) NOT NULL,
  PRIMARY KEY (`QuoteStatusID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

-- Dumping data for table cs_implementation_db.quote_status: ~3 rows (approximately)
DELETE FROM `quote_status`;
/*!40000 ALTER TABLE `quote_status` DISABLE KEYS */;
INSERT INTO `quote_status` (`QuoteStatusID`, `StatusName`) VALUES
	(1, 'Awaiting Response'),
	(2, 'Rejected'),
	(3, 'Approved');
/*!40000 ALTER TABLE `quote_status` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
