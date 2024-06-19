CREATE DATABASE  IF NOT EXISTS `acougue` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `acougue`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: acougue
-- ------------------------------------------------------
-- Server version	8.0.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cadastrocliente`
--

DROP TABLE IF EXISTS `cadastrocliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cadastrocliente` (
  `idcliente` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `endereco` varchar(65) DEFAULT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idcliente`)
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cadastrocliente`
--

LOCK TABLES `cadastrocliente` WRITE;
/*!40000 ALTER TABLE `cadastrocliente` DISABLE KEYS */;
INSERT INTO `cadastrocliente` VALUES (25,'Patricia ','itamar franco 984/703',''),(26,'Diego Miriam','Antonio Carlos 383/900',''),(27,'Vania Osso','','32122053'),(28,'Lurdes','Antonio Carlos 465/302 bloco A',''),(29,'Aline Carioca','Antonio carlos 347/1200',''),(30,'Marcelo ','Rua jonas bastos 123/401','998224460'),(31,'Dr Carlos','sampaio 465/902',''),(32,'Marcos','Itamar franco 1575/901',''),(33,'Endel salsa parrila','','33138218'),(34,'Angela Pacine','Rio Branco 2993/601','32135160'),(35,'Auria','Oscar vidal 469',''),(36,'Andreia sampaio','sampaio 346/801',''),(37,'Albina ','oscar vidal 280/301',''),(38,'Bete vizinha','batista de oliveira 1037/52',''),(39,'Beatriz','Rio branco 2644/1701',''),(40,'Maria Cicilha ','Antonio Carlos 354/1300',''),(41,'Debora','Antonio Carlos 297/1202',''),(42,'Heloiza','Antonio Carlos 354/800',''),(43,'Ieda','Gil horta 101/1202 B',''),(44,'Irani','Oscar vidal 144/501',''),(45,'Jackson','sampaio 444/403 bloco c2',''),(46,'Lila Carrão ','sampaio 360/404',''),(47,'Leia da hora','sampaio 412/203',''),(48,'Leda Caiçaras','Rua caisaras 444',''),(49,'Maria Helena ','sampaio 360/402',''),(50,'Professor Lucio ','Rio Branco 2929/ 701',''),(51,'Rozana','rio branco 3008/301 edifico magui ',''),(52,'Adão','sampaio 938/1004',''),(53,'Terezinha','Rio branco 2827/303',''),(54,'Sonia guedes','itamar franco 1460/1501','32168797'),(55,'Aieda','Rio Branco 2644/501',''),(56,'Tarcisio Vizinho','Rio Branco 3165/1202',''),(57,'Alline','Itamar franco 1566/301',''),(58,'Raquel','Sampaio 330/1202','');
/*!40000 ALTER TABLE `cadastrocliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pedidos`
--

DROP TABLE IF EXISTS `pedidos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pedidos` (
  `idpedidos` int NOT NULL AUTO_INCREMENT,
  `pedido` mediumtext NOT NULL,
  `nome` varchar(35) DEFAULT NULL,
  `endereco` varchar(45) DEFAULT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  `data` datetime NOT NULL,
  `pagamento` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idpedidos`)
) ENGINE=InnoDB AUTO_INCREMENT=105 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedidos`
--

LOCK TABLES `pedidos` WRITE;
/*!40000 ALTER TABLE `pedidos` DISABLE KEYS */;
INSERT INTO `pedidos` VALUES (98,'2k costelinha caldo','Rozangela','Francisco vale 197/101','999728380','2024-06-12 00:00:00','Maquina de cartão'),(99,'1 file mig ','Lidia','Vem buscar','','2024-06-18 00:00:00',''),(100,'teste 1 ','sla ','não sei ','2132123','2024-06-18 00:00:00','Troco'),(101,'','','','','2024-06-18 00:00:00','Troco'),(102,'teste 2','dkçpdslk','rapido ','','2024-06-18 00:00:00','Troco'),(103,'1k lombo bif\r\n1k alcatra bif\r\n0,5 moida 1°','D.Leda','','','2024-06-18 00:00:00','Maquina de cartão'),(104,'0,7 pernil ao ponto ','Jackson','rio branco 3165','','2024-06-18 00:00:00','Assinar notinha');
/*!40000 ALTER TABLE `pedidos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pedidosagendados`
--

DROP TABLE IF EXISTS `pedidosagendados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pedidosagendados` (
  `idpedidosagendados` int NOT NULL AUTO_INCREMENT,
  `pedido` mediumtext NOT NULL,
  `nome` varchar(45) DEFAULT NULL,
  `endereco` varchar(45) DEFAULT NULL,
  `telefone` varchar(45) DEFAULT NULL,
  `data` datetime DEFAULT NULL,
  `pagamento` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idpedidosagendados`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedidosagendados`
--

LOCK TABLES `pedidosagendados` WRITE;
/*!40000 ALTER TABLE `pedidosagendados` DISABLE KEYS */;
INSERT INTO `pedidosagendados` VALUES (32,'1k picanha p grelha \r\n1k cotrafile bif para grelha ','Carlinho amigo ilhan','','999387289','2024-06-12 00:00:00',''),(33,'1k coxinha /2\r\n1k pele picada ','Rosana(patricia)','Itamar franco 984/703','','2024-06-14 00:00:00','Assinar notinha'),(34,'1 file mig ','Raquel','Sampaio 330/1202','','2024-06-19 00:00:00','Maquina de cartão'),(35,'1 file mig','Lidia ','Vem buscar','','2024-06-18 00:00:00',''),(36,'1,5 chouriço ','Maria Aparecida','','','2024-06-20 00:00:00',''),(37,'1k chouriço ','Leo Salão','','','2024-06-20 00:00:00','');
/*!40000 ALTER TABLE `pedidosagendados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'acougue'
--

--
-- Dumping routines for database 'acougue'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-19 16:00:13
