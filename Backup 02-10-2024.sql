CREATE DATABASE  IF NOT EXISTS `acougue` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `acougue`;
-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: localhost    Database: acougue
-- ------------------------------------------------------
-- Server version	8.0.38

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
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cadastrocliente`
--

LOCK TABLES `cadastrocliente` WRITE;
/*!40000 ALTER TABLE `cadastrocliente` DISABLE KEYS */;
INSERT INTO `cadastrocliente` VALUES (25,'Patricia ','itamar franco 984/703',''),(26,'Diego Miriam','Antonio Carlos 383/900',''),(27,'Vania Osso','Rio Branco 2722/301','32122053'),(28,'Lurdes','Antonio Carlos 465/302 bloco A',''),(29,'Aline Carioca','Antonio carlos 347/1200',''),(30,'Marcelo ','Rua jonas bastos 123/401','998224460'),(31,'Dr Carlos','sampaio 465/902',''),(32,'Marcos','Itamar franco 1575/901',''),(33,'Endel salsa parrila','','33138218'),(34,'Angela Pacine','Rio Branco 2993/601','32135160'),(35,'Auria','Oscar vidal 469',''),(36,'Andreia sampaio','sampaio 346/801',''),(37,'Albina ','oscar vidal 280/301',''),(38,'Bete vizinha','batista de oliveira 1037/52',''),(40,'Maria Cicilha ','Antonio Carlos 354/1300',''),(41,'Debora','Antonio Carlos 297/1202',''),(42,'Heloiza','Antonio Carlos 354/800',''),(43,'Ieda','Gil horta 101/1202 B',''),(44,'Irani','Oscar vidal 144/501',''),(45,'Jackson','sampaio 444/403 bloco c2',''),(46,'Lila Carrão ','sampaio 360/404','32134006'),(47,'Leia da hora','sampaio 412/203',''),(48,'Leda Caiçaras','Rua caisaras 444',''),(49,'Maria Helena ','sampaio 360/402',''),(50,'Professor Lucio ','Rio Branco 2929/ 701',''),(51,'Rozana','rio branco 3008/301 edifico magui ',''),(52,'Adão','sampaio 938/1004',''),(53,'Terezinha','Rio branco 2827/303',''),(54,'Sonia guedes','itamar franco 1460/1501','32168797'),(55,'Aieda','Rio Branco 2644/501',''),(56,'Tarcisio Vizinho','Rio Branco 3165/1202',''),(57,'Alline','Itamar franco 1566/301',''),(58,'Raquel','Sampaio 330/1206',''),(59,'Geraldo','Oscar Vidal 519/404 bloco C',''),(60,'Julia ','Antonio Carlos 465/2032',''),(61,'José Carlos ','Rio branco 2662',''),(62,'D. Rosa','Itamar Franco 1575',''),(63,'Suzana Junquera ','Rio Branco 3165/ 1402',''),(64,'Tarcisio Vizinho ','Rio Branco 3165/ 1202',''),(65,'Ema ','Santo Antonio 1495/201',''),(66,'Graciana','Rio Branco 2772/702',''),(67,'Elizana ','antonio carlos 297/602',''),(68,'D. Dilma','Sampaio 360/802','32120839'),(69,'Angela Gravine ','Oscar Vidal 293/501','99771823'),(70,'D.Beatriz','Rio Branco 2644/1701','32120450'),(71,'Irani','Oscar Vidal 144/501',''),(72,'Rozana','Francisco Vale 197/302',''),(73,'Helio','Sampaio 360/701',''),(74,'Zeina ','Sampaio 336/101',''),(75,'Bruno Costa','Itamar franco 832/902',''),(76,'Vinicios','Itamar 1585/1203',''),(77,'Silvana','São Mateus 1235/302',''),(78,'Daniela','Itamar franco 1430/302','988545748'),(79,'Zelandia','santo antonio 1098/602 bloco 2',''),(80,'Sr Geraldo ','Oscar vidal 519/404 bloco c','');
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
) ENGINE=InnoDB AUTO_INCREMENT=268 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedidos`
--

LOCK TABLES `pedidos` WRITE;
/*!40000 ALTER TABLE `pedidos` DISABLE KEYS */;
INSERT INTO `pedidos` VALUES (260,'40k costela \r\n4k moida 1°','Churrasquera','','','2024-10-01 00:00:00',''),(261,'6 pacotes 0,5 moida 1°\r\n5 // file frang bif\r\n1/2 peito frango 3 coxas (2x)\r\n','Debora','','','2024-10-01 00:00:00',''),(262,'1k pernil moido\r\n1k pernil picado \r\n13 bif pernil fino \r\n','Zelandia','santo antonio 1098/602 bloco 2','','2024-10-01 00:00:00',''),(263,'1,5 mooida 2° ','Xororo','','','2024-10-01 00:00:00',''),(264,'2k mão de porco\r\n2k rabinho suino \r\n2 orelha ','Felipe(Amigo serrote)','','','2024-10-01 00:00:00',''),(265,'1,5 alcatra bif pequeno\r\n1k musculo cubo \r\n8 bif role \r\n','Professor Lucio ','','','2024-10-01 00:00:00',''),(266,'1 file mig bif \r\n1 picanha\r\n1k costelinha picada ','Leda caiçaras ','','','2024-10-02 00:00:00',''),(267,'1k bif role \r\n1k moida 2°','Leia da hora','Sampaio 412/203','','2024-10-02 00:00:00','');
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
) ENGINE=InnoDB AUTO_INCREMENT=69 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedidosagendados`
--

LOCK TABLES `pedidosagendados` WRITE;
/*!40000 ALTER TABLE `pedidosagendados` DISABLE KEYS */;
INSERT INTO `pedidosagendados` VALUES (58,'2k pe porco ','Luzia ','','','2024-09-27 00:00:00',''),(59,'1,5 couriço /2','Daniele(Coronel Alvim)','','','2024-09-26 00:00:00',''),(60,'Osso de canela','Alexandra ','','','2024-09-26 00:00:00',''),(61,'24k ling grossa','Jerferson','Santa Rita 221','','2024-09-27 00:00:00','Pix'),(62,'1k torresmo','Mexicana ','','','2024-09-27 00:00:00',''),(63,'1 file mig ','D. Soria','Oscar vidal 293/401','','2024-09-27 00:00:00','Não especificado'),(64,'4 bif de alcatra','D. Dizenia','','','2024-09-27 00:00:00',''),(65,'2 coxa assada ','D.Lurdes','Vem buscar','','2024-09-26 00:00:00',''),(66,'1 file mig pequeno ','Carmen ','','','2024-10-01 00:00:00',''),(67,'5K MOIDA 1°\r\nVEM PEGAR 7:30','JACKSON','','','2024-10-02 00:00:00',''),(68,'2k mão de porco\r\n2k rabinho suino \r\n2 orelha','Felipe (Amigo Serrote)','','','2024-10-04 00:00:00','');
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

-- Dump completed on 2024-10-02 11:39:24
