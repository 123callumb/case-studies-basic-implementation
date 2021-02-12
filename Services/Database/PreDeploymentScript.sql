/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

CREATE DATABASE IF NOT EXISTS `cs_implementation_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `cs_implementation_db`;

DROP TABLE IF EXISTS `quote`;
CREATE TABLE IF NOT EXISTS `quote` (
  `QuoteID` int(11) NOT NULL AUTO_INCREMENT,
  `VendorItemID` int(11) NOT NULL,
  `QuoteDate` datetime NOT NULL,
  `QuantityRequested` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`QuoteID`),
  KEY `FK_Quote_Vendor_Item` (`VendorItemID`),
  CONSTRAINT `FK_Quote_Vendor_Item` FOREIGN KEY (`VendorItemID`) REFERENCES `vendor_item` (`ItemID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

DELETE FROM `quote`;
/*!40000 ALTER TABLE `quote` DISABLE KEYS */;
INSERT INTO `quote` (`QuoteID`, `VendorItemID`, `QuoteDate`, `QuantityRequested`) VALUES
	(1, 7, '2021-02-11 11:51:18', 100),
	(2, 8, '2021-02-11 11:51:18', 5),
	(3, 6, '2021-02-11 11:51:49', 5),
	(4, 5, '2021-02-11 19:51:28', 50),
	(5, 2, '2021-02-11 19:51:34', 300),
	(6, 3, '2021-02-11 19:51:54', 500);
/*!40000 ALTER TABLE `quote` ENABLE KEYS */;

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

DELETE FROM `quote_response`;
/*!40000 ALTER TABLE `quote_response` DISABLE KEYS */;
/*!40000 ALTER TABLE `quote_response` ENABLE KEYS */;

DROP TABLE IF EXISTS `quote_status`;
CREATE TABLE IF NOT EXISTS `quote_status` (
  `QuoteStatusID` int(11) NOT NULL AUTO_INCREMENT,
  `StatusName` varchar(50) NOT NULL,
  PRIMARY KEY (`QuoteStatusID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

DELETE FROM `quote_status`;
/*!40000 ALTER TABLE `quote_status` DISABLE KEYS */;
INSERT INTO `quote_status` (`QuoteStatusID`, `StatusName`) VALUES
	(1, 'Awaiting Response'),
	(2, 'Rejected'),
	(3, 'Approved');
/*!40000 ALTER TABLE `quote_status` ENABLE KEYS */;

DROP TABLE IF EXISTS `role`;
CREATE TABLE IF NOT EXISTS `role` (
  `RoleID` int(11) NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(100) NOT NULL,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

DELETE FROM `role`;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` (`RoleID`, `RoleName`) VALUES
	(1, 'Procurement');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `RoleID` int(11) NOT NULL,
  `Firstname` varchar(100) NOT NULL,
  `Lastname` varchar(100) NOT NULL,
  `CompanyEmail` varchar(50) NOT NULL,
  `DOB` date DEFAULT NULL,
  PRIMARY KEY (`UserID`) USING BTREE,
  KEY `FK_User_RoleID` (`RoleID`),
  CONSTRAINT `FK_User_RoleID` FOREIGN KEY (`RoleID`) REFERENCES `role` (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;

DELETE FROM `user`;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`UserID`, `RoleID`, `Firstname`, `Lastname`, `CompanyEmail`, `DOB`) VALUES
	(5, 1, 'Callum', 'Beckwith', 'cb@abc.com', '1998-05-27');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

DROP TABLE IF EXISTS `vendor`;
CREATE TABLE IF NOT EXISTS `vendor` (
  `VendorID` int(11) NOT NULL AUTO_INCREMENT,
  `VendorName` varchar(100) NOT NULL DEFAULT '0',
  PRIMARY KEY (`VendorID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

DELETE FROM `vendor`;
/*!40000 ALTER TABLE `vendor` DISABLE KEYS */;
INSERT INTO `vendor` (`VendorID`, `VendorName`) VALUES
	(1, 'Planet Express'),
	(2, 'Pied Piper'),
	(3, 'Apeture Science'),
	(4, 'Dunder Mifflin Paper Company');
/*!40000 ALTER TABLE `vendor` ENABLE KEYS */;

DROP TABLE IF EXISTS `vendor_item`;
CREATE TABLE IF NOT EXISTS `vendor_item` (
  `ItemID` int(11) NOT NULL AUTO_INCREMENT,
  `VendorID` int(11) DEFAULT NULL,
  `ItemName` varchar(100) NOT NULL,
  `ItemImageURL` varchar(1000) DEFAULT NULL,
  `ItemDescription` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`ItemID`),
  KEY `FK_Item_Vendor` (`VendorID`),
  CONSTRAINT `FK_Item_Vendor` FOREIGN KEY (`VendorID`) REFERENCES `vendor` (`VendorID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;

DELETE FROM `vendor_item`;
/*!40000 ALTER TABLE `vendor_item` DISABLE KEYS */;
INSERT INTO `vendor_item` (`ItemID`, `VendorID`, `ItemName`, `ItemImageURL`, `ItemDescription`) VALUES
	(1, 4, '100 Sheets A4 Paper', 'http://www.hobbycraft.co.uk/supplyimages/584769_1000_1_800.jpg', '100 Sheets of A4 printer paper'),
	(2, 4, '500 Sheets A4 Paper', 'http://www.hobbycraft.co.uk/supplyimages/584769_1000_1_800.jpg', '500 Sheets of A4 Paper'),
	(3, 4, '100 Sheets A5 Paper', 'https://www.eco-craft.co.uk/media/amasty/amoptmobile/catalog/product/cache/02377500426d9591f331e95f49ddcdb6/n/a/natural-a4_1_1_2_1_png.webp', '100 Sheets of A5 printer paper'),
	(4, 4, '500 Sheets A5 Paper', 'https://www.eco-craft.co.uk/media/amasty/amoptmobile/catalog/product/cache/02377500426d9591f331e95f49ddcdb6/n/a/natural-a4_1_1_2_1_png.webp', '500 Sheets of A5 printer paper'),
	(5, 4, 'Sabre Tablet', 'https://pbs.twimg.com/ext_tw_video_thumb/1140889158291820544/pu/img/VrAcUSe3WLWhOYwE.jpg', 'Sabre tablet, close competitor to the ipad of course'),
	(6, 1, '1 Cardboard Box', 'https://www.packaging2buy.co.uk/images/detailed/2/sustainable-loop-boxes1.jpg', 'Box for packing items into'),
	(7, 1, '10 Cardboard Boxes', 'https://www.stormtrading.co.uk/ekmps/shops/stgltd/images/small-single-wall-cardboard-boxes-4901-p.jpg', 'Many boxes for packing items into'),
	(8, 1, 'Bending Unit Blueprint', 'https://res.cloudinary.com/teepublic/image/private/s--jNFzrPhy--/c_crop,x_10,y_10/c_fit,h_1109/c_crop,g_north_west,h_1260,w_945,x_-93,y_-76/co_rgb:ffffff,e_colorize,u_Misc:One%20Pixel%20Gray/c_scale,g_north_west,h_1260,w_945/fl_layer_apply,g_north_west,x_-93,y_-76/bo_126px_solid_white/e_overlay,fl_layer_apply,h_1260,l_Misc:Art%20Print%20Bumpmap,w_945/e_shadow,x_6,y_6/c_limit,h_1134,w_1134/c_lpad,g_center,h_1260,w_1260/b_rgb:eeeeee/c_limit,f_jpg,h_630,q_90,w_630/v1548411784/production/designs/3547226_2.jpg', 'Blue print for your very own bending unit');
/*!40000 ALTER TABLE `vendor_item` ENABLE KEYS */;

DROP TABLE IF EXISTS `vendor_user`;
CREATE TABLE IF NOT EXISTS `vendor_user` (
  `VendorUserID` int(11) NOT NULL AUTO_INCREMENT,
  `VendorID` int(11) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Firstname` varchar(200) NOT NULL,
  `Lastname` varchar(200) NOT NULL,
  PRIMARY KEY (`VendorUserID`),
  KEY `FK_Vendor_User_Vendor` (`VendorID`),
  CONSTRAINT `FK_Vendor_User_Vendor` FOREIGN KEY (`VendorID`) REFERENCES `vendor` (`VendorID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

DELETE FROM `vendor_user`;
/*!40000 ALTER TABLE `vendor_user` DISABLE KEYS */;
INSERT INTO `vendor_user` (`VendorUserID`, `VendorID`, `Email`, `Firstname`, `Lastname`) VALUES
	(2, 4, 'jim.halpert@dundermifflin.com', 'Jim', 'Halpert'),
	(3, 4, 'dwight.schrute@dundermifflin.com', 'Dwight', 'Schrute'),
	(4, 1, 'fry@pe.com', 'Philip', 'J.Fry');
/*!40000 ALTER TABLE `vendor_user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
