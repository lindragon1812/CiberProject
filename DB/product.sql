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

 Date: 27/04/2023 09:29:51
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS `product`;
CREATE TABLE `product`  (
  `ProductId` int NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_as_ci NULL DEFAULT NULL,
  `CategoryId` int NULL DEFAULT NULL,
  `Price` decimal(22, 4) NULL DEFAULT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_as_ci NULL DEFAULT NULL,
  `Quantity` int NULL DEFAULT NULL,
  PRIMARY KEY (`ProductId`) USING BTREE,
  INDEX `CategoryId`(`CategoryId` ASC) USING BTREE,
  CONSTRAINT `product_ibfk_1` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`CategoryId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_as_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of product
-- ----------------------------
INSERT INTO `product` VALUES (1, 'Sữa', 1, 100000.0000, NULL, 4);
INSERT INTO `product` VALUES (2, 'Thăng Long', 2, 200000.0000, NULL, 5);

SET FOREIGN_KEY_CHECKS = 1;
