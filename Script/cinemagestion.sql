-- phpMyAdmin SQL Dump
-- version 4.5.2
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Sam 27 Août 2016 à 11:49
-- Version du serveur :  5.7.9
-- Version de PHP :  5.6.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `cinemagestion`
--

CREATE DATABASE IF NOT EXISTS `cinemagestion`;
USE cinemagestion;

-- --------------------------------------------------------

--
-- Structure de la table `address`
--

DROP TABLE IF EXISTS `address`;
CREATE TABLE IF NOT EXISTS `address` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `path` longtext,
  `number` int(11) NOT NULL,
  `street` longtext,
  `city` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Contenu de la table `address`
--

INSERT INTO `address` (`id`, `path`, `number`, `street`, `city`) VALUES
(1, 'Quai', 2, 'Jacques Brel', 'Val-André'),
(2, 'Quai', 3, '18 mai', 'Erquy'),
(3, 'Rue', 10, 'Mansart', "Sable d'or"),
(4, 'Avenue', 6, 'Théodore Monod', 'Saint-Malo');

-- --------------------------------------------------------

--
-- Structure de la table `cinema`
--

DROP TABLE IF EXISTS `cinema`;
CREATE TABLE IF NOT EXISTS `cinema` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `credit` decimal(18,2) NOT NULL,
  `finance` decimal(18,2) NOT NULL,
  `name` longtext,
  `address_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Contenu de la table `cinema`
--

INSERT INTO `cinema` (`id`, `credit`, `finance`, `name`, `address_id`) VALUES
(1, '0.00', '100000.00', 'Cinéma La Rotonde', 1),
(2, '0.00', '150000.00', 'Cinéma Eden', 2),
(3, '0.00', '105000.00', 'Armor Cinema', 3),
(4, '0.00', '200000.00', 'Cinéma Le Vauban', 4);

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `money` decimal(18,2) NOT NULL,
  `Firstname` longtext,
  `Lastname` longtext,
  `BirthDate` datetime NOT NULL,
  `Address_id` int(11) NOT NULL,
  `Cinema_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `drinkable`
--

DROP TABLE IF EXISTS `drinkable`;
CREATE TABLE IF NOT EXISTS `drinkable` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `liter` decimal(18,2) NOT NULL,
  `Name` longtext,
  `Price` decimal(18,2) NOT NULL,
  `Number` int(11) NOT NULL,
  `BuyDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Cinema_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Contenu de la table `drinkable`
--

INSERT INTO `drinkable` (`id`, `liter`, `Name`, `Price`, `Number`, `BuyDate`, `Cinema_id`) VALUES
(1, '0.5', 'Coca-Cola', '3.00', 500, '2016-08-18 14:00:00', 1),
(2, '0.33', 'Coca-Cola', '2.50', 700, '2016-08-18 14:00:00', 2),
(3, '0.2', 'Café', '3.00', 300, '2016-08-18 14:00:00', 3),
(4, '0.5', "Jus d'orange", '2.00', 300, '2016-08-18 14:00:00', 4),
(5, '0.5', 'Jus de pomme', '2.00', 500, '2016-08-18 14:00:00', 1),
(6, '0.33', 'Coca-Cola', '2.50', 700, '2016-08-18 14:00:00', 4),
(7, '0.3', 'Café', '3.00', 300, '2016-08-18 14:00:00', 2),
(8, '0.33', "Jus d'orange", '1.50', 300, '2016-08-18 14:00:00', 3);

-- --------------------------------------------------------

--
-- Structure de la table `eatable`
--

DROP TABLE IF EXISTS `eatable`;
CREATE TABLE IF NOT EXISTS `eatable` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Weight` decimal(18,2) NOT NULL,
  `Name` longtext,
  `Price` decimal(18,2) NOT NULL,
  `Number` int(11) NOT NULL,
  `BuyDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Cinema_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `eatable`
--

INSERT INTO `eatable` (`id`, `Weight`, `Name`, `Price`, `Number`, `BuyDate`, `Cinema_id`) VALUES
(1, '0.5', 'Pop-Corn', '5.00', 500, '2016-08-18 14:00:00', 1),
(2, '0.33', 'Barre chocolatée', '2.50', 700, '2016-08-18 14:00:00', 2),
(3, '0.2', 'Pop-Corn', '3.00', 300, '2016-08-18 14:00:00', 3),
(4, '0.3', "Pop-Corn", '3.00', 300, '2016-08-18 14:00:00', 4),
(5, '0.5', 'Pomme', '0.80', 500, '2016-08-18 14:00:00', 1),
(6, '0.33', 'Chocolat', '2.50', 700, '2016-08-18 14:00:00', 4),
(7, '0.3', 'Choclat', '3.00', 300, '2016-08-18 14:00:00', 2),
(8, '0.33', 'Pomme', '1.50', 300, '2016-08-18 14:00:00', 3);

-- --------------------------------------------------------

--
-- Structure de la table `employee`
--

DROP TABLE IF EXISTS `employee`;
CREATE TABLE IF NOT EXISTS `employee` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Firstname` longtext,
  `Lastname` longtext,
  `BirthDate` datetime NOT NULL,
  `Address_id` int(11) NOT NULL,
  `Cinema_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `movie`
--

DROP TABLE IF EXISTS `movie`;
CREATE TABLE IF NOT EXISTS `movie` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` longtext,
  `author` longtext,
  `length` int(11) NOT NULL,
  `releaseDate` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `movieroom`
--

DROP TABLE IF EXISTS `movieroom`;
CREATE TABLE IF NOT EXISTS `movieroom` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `movie_id` int(11) NOT NULL,
  `room_id` int(11) NOT NULL,
  `cinema_id` int(11) NOT NULL,
  `rentTime` int(11) NOT NULL,
  `StartDate` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `owner`
--

DROP TABLE IF EXISTS `owner`;
CREATE TABLE IF NOT EXISTS `owner` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `money` decimal(18,2) NOT NULL,
  `Firstname` longtext,
  `Lastname` longtext,
  `BirthDate` datetime NOT NULL,
  `Address_id` int(11) NOT NULL,
  `Cinema_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `room`
--

DROP TABLE IF EXISTS `room`;
CREATE TABLE IF NOT EXISTS `room` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `capacity` int(11) NOT NULL,
  `number` int(11) NOT NULL,
  `cinema_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Contenu de la table `room`
--

INSERT INTO `room` (`id`, `capacity`, `number`, `cinema_id`) VALUES
(1, 150, 1, 2),
(2, 170, 2, 2),
(3, 100, 3, 2),
(4, 100, 1, 3),
(5, 120, 2, 3),
(6, 100, 1, 4),
(7, 200, 2, 4),
(8, 120, 1, 1),
(9, 100, 2, 1),
(10, 200, 3, 1);

-- --------------------------------------------------------

--
-- Structure de la table `__migrationhistory`
--

DROP TABLE IF EXISTS `__migrationhistory`;
CREATE TABLE IF NOT EXISTS `__migrationhistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ContextKey` varchar(300) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `__migrationhistory`
--

INSERT INTO `__migrationhistory` (`MigrationId`, `ContextKey`, `Model`, `ProductVersion`) VALUES
('201608271148068_InitialCreate', 'GroupeCinema.Database.FullDb', 0x1f8b0800000000000400ed5cdd929b3614beef4cdf81e13e66934c3be98e9dccc6ce66328dbd3beb4d7ad991e1d86602828248d7cfd68b3e525fa1e2472040d84280e338bed9c107e9d3dfa72389a36ffffbe7dff19b27d7d1be4210da1e9ee8cf4757ba06d8f42c1b6f267a44d6cf5ee96f5efffcd3f89de53e699f59ba97713a9a1387137d4b887f6d18a1b905178523d736032ff4d664647aae812ccf787175f59bf1fcb9011442a7589a367e8830b15d487ed09f530f9be093083973cf0227ccecf4cd3241d516c885d047264cf4f78117f930b531b58f6688a0150a41d76e1c1bd1ca2cc159eb1ac2d82388d0aa5e7f0a6149020f6f963e3520e771e7034db7464e9c2b69c275915cb635572fe2d6184546a5ded0f376d296bea33d427671f592d64ef41bcb0a200cf94434d9efb02b19a8e93ef07c08c8ee01d659d60f96ae19e57c4635639e8dcb13974e9f3079f942d71691e3a09503796771bdba245e00ef0143800858f7881008708c01492b6aa557caa219b6ac343a3a946bba36474f1f016fc876a2d3475dbbb59fc06296ac069fb04da9493391208243852c227705c1a146edc7a09503208357759af459af858c8d82507b6996cea47364d93400cbce076f06a6ed2247d7ee03fa94b9bb57bab634515c7a7b6edcda1851b735187efc7770e6654ee64ffbe0b8a891cbb1e9589d23b9e61e86dd80dc0a42828f41808fe84805bdb503b2a5eb753161e8f3a31d97dcb273d4382bf2bab1e71b8afa33da8f5f62987364ff479b144bebf7e9f9ee037b48e7ddc3e6e36db4eb65be0ccbf377f116fc3c59fe07d89bed701b880bcdbf279abbbee3ede02c797ed96d7cf7bb8db9f7d53e4b6e1ee7141491ad170ccffe246f371a3d80032804056ab7e3d283e7b9e7c8a7a4719d2773dc3bdfc623881881493afcddbe74a1800cc9aabbbfe9909d27a32e5f022e6bf31ee69fab2b9d221f99dc976bb5beefe30831c0f84d3d4c10850dd83ca450b3556518d3a44b20ec9bcf8a3eb3b88d56c0a771a951fec69080c9becbd751d80b2990f4fbab00247b2103527cc9aae370ef64a0d8c7823a50fe460a861dc60438f92b19a074db5c47c9ecd210c9146f8049dfc940a54b641d26b3cb403454a45e07c6fe9ce745ccd54883ae2c386b344467c773e4fb7485e0a2b599455ba6a1dae9b365fbb8a89b62186628088fe6b5cd4ba22e0c6da0f296164d6b9a2c9d4584786ab9b564fb67352b4430b9abdebbe87196297e4e330a23d6a306a4a2176f69c35c3a499336425ea986c0709637de67a040b0284c3d277271fadbae2d2cfb72a7c15a3ebf9f58e411988be7317066934761b1581e25cc6cf22869a895c730054b5d4afcca4054c7dca80d7a65b1ae12499e66a2a0ac12cbc44012246bca380cc758a8b6342e994d1e258fc8f2306b666cc1d764175c626b629147e037a63c0ee2ec27c63841a4568d71422019c635641c8671d9a98d077053531bbee567331e8733cb6315a72f1eaab0ca2371c72b1e8a3377e7f1cd5e1e37fbde7c9bce8371e6d39a130d215ca569d188253133f6e41d667264e15d1ec0494d5d9ce8a22591b3d0150f9199ba6d3d16adb71e7988aa34a198f17c278030b6ab44ff062409f237e61c86fa2ce6cb2330db85fc3f14f985115f35f63740c9d0bf31eb30fcbfec69ce7b4f2308142b515a8823c1e7867cc390b987835c16192e1de2325b8b8990057e4b1baacc268f520afdf25001ffe204e9560f80a8534e84254b3b71dea1ce972cce5c3e62326b8b6167b1e6d2903363674f65eef354cd546431e7320f99b5cd57bd3ceecc4371e6d322b4208cad4466218e04911bf25d3e925c3614df6642f4e4dc15fdfa315d7a11ef2ef9cfdc7aec80888a431f9429b5986235495e7a1e5bacc410c7593cefb00cb416e04b93c4176fe81a6bc5c1bdf96ef99793306c943cb298374b3147d85e43481ebd2f8027fa2fa35f2b32520549a71186963398aeb33ea6876f84149722ecb8f107ef7cb4bc7ae173524ec7a35b5a78223c88cc85205cba029254b3652dc2924e53b51efc6516398c23a82c4f70cccd92b0d2eafbcadbba2cacec1d3fdd2b74a30aaadd3c3b4cdb23a8264f902c2e7f3db2f7b1ac5d8f541dd0eaed47559cdae5468b3e93e450c4b5f9aa87ab8e2a7eb27651ae47d676123c9e20711d5ee3d83b71173d70ada4edeabf869d57e58ab2aba7993024873b88194f90c165fde285c23f06853b08154f90c39705fe6498a5ac313c415af5720628a90655519c92285065cc83ba24508993c711089e2019dc8a26506910ca8a401508b3fddc1591a1ac0654c1a8690187a593b232f024a97439edfe108be119b93fb3a2e353e9eaee9f7015bc5f3b055f5d12d410e4aa7ca7dfa3e34b630e94f52b8fd63aada7acc8efa0be4f046eca69ff0ecafe84d89292403935a0a8044b5a2c28a11314150092224229fda0b0005975e10161a108db95d21c4aca0d1b0b9052231e10228ac03d298de25e79a20836e8225cac0713c706ff9f67c73308ed4d0111ff1f5a0c66ac8d2e40599a0f78ed3197451bc4d78825a9de9e0082e87a886e0262af9149e86b937a864454ff19395142c415581ff05d44fc88dc8421b82ba714491e1bfbcb4fd499e53a8feffcf857d847136835ed7849bfc36f23dbb1f27adf0a9c710344ec76b3c58ad66a49e2456bb3cb911674c324079475df0c7cc0f152f7184f460a16dee125fa0acd753bdc87e51e1bcf6cb409901b6618457efa93d2cf729f5eff0f016fd5293b590000, '6.0.0-20911');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
