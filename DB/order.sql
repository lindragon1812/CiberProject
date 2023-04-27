/*
 Navicat MySQL Data Transfer

 Source Server         : localhost_3306
 Source Server Type    : MySQL
 Source Server Version : 80033 (8.0.33)
 Source Host           : localhost:3306
 Source Schema         : ciber

 Target Server Type    : MySQL
 Target Server Version : 80033 (8.0.33)
 File Encoding         : 65001

 Date: 27/04/2023 09:29:45
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for order
-- ----------------------------
DROP TABLE IF EXISTS `order`;
CREATE TABLE `order`  (
  `OrderId` int NOT NULL AUTO_INCREMENT,
  `ProductId` int NULL DEFAULT NULL,
  `CustomerId` int NULL DEFAULT NULL,
  `Amount` int NULL DEFAULT NULL,
  `CreatedDate` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`OrderId`) USING BTREE,
  INDEX `ProductId`(`ProductId` ASC) USING BTREE,
  INDEX `CustomerId`(`CustomerId` ASC) USING BTREE,
  CONSTRAINT `order_ibfk_1` FOREIGN KEY (`ProductId`) REFERENCES `product` (`ProductId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `order_ibfk_2` FOREIGN KEY (`CustomerId`) REFERENCES `customer` (`CustomerId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 15 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_as_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of order
-- ----------------------------
INSERT INTO `order` VALUES (13, 1, 1, 2, '2023-04-02 00:00:00');
INSERT INTO `order` VALUES (14, 2, 1, 5, '2023-04-02 00:00:00');

SET FOREIGN_KEY_CHECKS = 1;
