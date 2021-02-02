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

-- Dumping structure for table cs_implementation_db.quote_response
DROP TABLE IF EXISTS `quote_response`;
CREATE TABLE IF NOT EXISTS `quote_response` (
  `QuoteResponseID` int(11) NOT NULL AUTO_INCREMENT,
  `QuoteID` int(11) NOT NULL,
  `QuoteStatusID` int(11) NOT NULL DEFAULT 0,
  `ResponseDate` datetime NOT NULL,
  `ReponseText` varchar(1000) NOT NULL,
  `Quote` float NOT NULL,
  PRIMARY KEY (`QuoteResponseID`),
  KEY `FK_Quote_Quote_Response` (`QuoteID`),
  KEY `FK_Quote_Reponse_Status` (`QuoteStatusID`),
  CONSTRAINT `FK_Quote_Quote_Response` FOREIGN KEY (`QuoteID`) REFERENCES `quote` (`QuoteID`),
  CONSTRAINT `FK_Quote_Reponse_Status` FOREIGN KEY (`QuoteStatusID`) REFERENCES `quote_status` (`QuoteStatusID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table cs_implementation_db.quote_response: ~0 rows (approximately)
DELETE FROM `quote_response`;
/*!40000 ALTER TABLE `quote_response` DISABLE KEYS */;
/*!40000 ALTER TABLE `quote_response` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
