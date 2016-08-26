-- phpMyAdmin SQL Dump
-- version 4.5.2
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Ven 26 Août 2016 à 15:03
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
(1, 'rue', 2, 'Paix', 'Paris');

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
(1, '0.00', '10000.00', 'cinema 1', 1),
(2, '0.00', '150000.00', 'cinema 2', 1),
(3, '0.00', '105000.00', 'cinema 3', 1),
(4, '0.00', '200000.00', 'cinema 4', 1);

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
  `BuyDate` datetime NOT NULL,
  `Cinema_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Contenu de la table `drinkable`
--

INSERT INTO `drinkable` (`id`, `liter`, `Name`, `Price`, `Number`, `BuyDate`, `Cinema_id`) VALUES
(1, '1.00', 'Coca-Cola', '4.00', 100, '2016-08-26 17:02:51', 4);

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
  `BuyDate` datetime NOT NULL,
  `Cinema_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
  `MovieProvider_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_MovieProvider_Id` (`MovieProvider_Id`) USING HASH
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `movieprovider`
--

DROP TABLE IF EXISTS `movieprovider`;
CREATE TABLE IF NOT EXISTS `movieprovider` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyName` longtext,
  `Firstname` longtext,
  `Lastname` longtext,
  `BirthDate` datetime NOT NULL,
  `Address_id` int(11) NOT NULL,
  `Cinema_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Contenu de la table `movieprovider`
--

INSERT INTO `movieprovider` (`id`, `CompanyName`, `Firstname`, `Lastname`, `BirthDate`, `Address_id`, `Cinema_id`) VALUES
(1, 'Gaumont', 'Jean', 'Moineau', '0001-01-01 00:00:00', 1, 0);

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
-- Structure de la table `productprovider`
--

DROP TABLE IF EXISTS `productprovider`;
CREATE TABLE IF NOT EXISTS `productprovider` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyName` longtext,
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
('201608261502215_InitialCreate', 'GroupeCinema.Database.FullDb', 0x1f8b0800000000000400ed5ddd6edb3816be1f60df41d0e50263a51dec60b67066903acda098e6077166f6b26024da2146223512958d9f6d2ff691f61596d42f295232454ba9ebeaa6708ec88f7f1f0f8fe8cfa7fffbcf7f97bfbc44a1f30c9314117ceebe599cb90ec43e0910de9ebb19dd7cff93fbcbcf7ffb6ef921885e9c3faa723ff072ac264ecfdd274ae3779e97fa4f3002e922427e4252b2a10b9f441e0888f7f6ecec9fde9b371e64102ec3729ce57d86298a60fe07fb7345b00f639a81f09a04304c4b3b7bb2ce519d1b10c134063e3c777f4d4816c315c2ccbeb804143c8214bace458800ebcc1a861bd70118130a28ebeabbdf53b8a609c1db75cc0c207cd8c59095db8090d7ca87f0ae296e3a9ab3b77c345e53d16a36dc7a9c6ca41fd88cd01def5e3eda73f722081298a6622156ec37b8930ccc749790182674770f3765d58f81eb78723daf5db1ae26d4e1adb34f98fef0d6756eb230048f21ac274b98d5352509fc156298000a833b40294c30c780f92894d65b6db10a4f556b6c7518d75ce71abc7c82784b9fce5df6d175aed00b0c2a4bd983df3162d464956892c17d8ddc64d1234cf60daa1f83750e423a795757f99c8ddac8d26b08d54bb362279d22cb56090c50bd7897d04711085de72e619f4a77f793ebac7dc05b1fce8d2b8401735b93e1f37f27675ee9643ea3bdeb6247ae10b1b53a45725d130c7713722b49297e0d027c02afd4d07b94d027765e371b867d7e40bce5819363c7599dd7e59e6f2aea5fb279fc93c39c22fb3f21da1cad5fa7e7bb4bd094ce7b84e0e37db61b65bf4ccbf30f3c043f4d96ff0ba2edd37401c44cf3af89e6511c921d3c499ecfd1c6571f6d5c93677492dc7c9db7a08c3e91647af6e7750fa3d13d0c2148a11db56fc033dae6cba2bccd30fa30db330ab83b678de4a5d2271417776a8bbcc4e756b9ab8444f724ac00e4c79fd7244bf2b38774977900c9965fb0d893beeecd09927f45a218e0ddabec81f910388d43e09e90e814f742e13d0e5d003e3b5f661575ae1cd3828d875d5183845a90dc9855b7ffc6a7e95de72bbcd99ff6329f3516643e9d238c39c29877447d7c9ee4360031f0852f61ede67e8cdbb051d7ef224d898ff21992a2a8be17a70f38700cdee98a7d55bf19b2bd958514c521e2d378eefe5d19673f6ef51ed8c66dde3565fcb3c5e24d7b0e84d1aa245e114c019bdba472466c3e2f1f95b1f3a26b48abef701ed9e74a87e134735cf6b07ea20c5503537ecfaea2540f8c408aef533520e5031390e69b291547786602555dfeab40f5132398ea725583533f32012ab9a8a09476638886767aa8e6b93164ee3a3be08a6726504530aec2947613887654a38229254c603bc6a71d9ab0531b14ed0d9350b2e722aa7d0099f9b07a183279bc616895e7d2a2754ea1274f81c697d70eab7eb6f40a355c69587a1db2b9e535886316ef0832bad2e2ac0b0dddeafbf570c15a5460787eaad1add5bdad5b620732d8c2d6531e7006300f041be9de2a889462fdeeb96a44e3a5d5c5ab085955e29f8b8a5a29e1a203a999c52b36b08879db7c8c5058f7ce9a0e17328210249a106745c22cc2c5df480993fa6a172a3ab17e9c5bcc11aa8045c4c0a5cd1ca512c98928696933472934702286af09dc0ae2b716a2bde69eb2e8adcdd7269239cd746a392b96e9810c48d655711a8e551a3a695d4a9b394a2d951361369571005ff3773a89adb9c51c417ccd127180603f32c6692474768cd3029930aea3e2348c2b6fe54480a8300de15b7dd320e2086673ace62e41846aace648c265810825980fe7f1452f8fbb7d6ffdd2298209e6e3da131dda3aab6dd18965b0337aea4eb3394add9d081016a6439ce8cd4022979a2211a2341d167adc0c0e3d6aed90b4a12ae3e96e00ade8ce8afe1d4806e4efac390df52b319e8850d966f27f53e4d74af1ecd8df016542ffceaad3f07f8e694e3ba6d128f8ac28adc531e07347bd69c83cc28b5c29d9935ee24adb808d502af2a480aab499a3489a3c112a111f1c21dd7a2e50ad68d785674abfeefa13dd6e88df7e4b5e427c30fbe8d947b7bfc81969c3e8b04c378bbeee54973295f84ebe97a9ac037c6525c093fc64653c983a7e1f75bafd7725c4939d77651d72155e8bf14428c17c5c84d668fbacc8acc531207247bdf96671f6f05f6643f44afeacb6c61e44834db217610e8ee6ad53227dc1ad33525c641912bd6634d4a805a5d0a3b6bef617f036b1d0d44c91f52d325db44a1fa378b95dc9e812830b78b4f1ac56c8a3ce941183642c55ef5acc58dd0fbb2e96ca25cb2eea88d0dba915c101cac5a31f53ae3fadb5a74306de963aa96c51144fed2235574b4bfd77ad782ad546fbb38729f2a3a208ffd947310236a0ddfaaf30e7dd22ff58492bab12d700a30d4ce903f913e273f71f8b1f5bd9c72c328179691a8493a50353177ebffaba1120233ef8bdfaea8132e758c8001612bca5f0858a2026e27b2cc9adf36e0eec452aa5f7b2ed87281c37c37885e45c47b8e6be948f2b18fb07571b391fd7e8f8456479185580f22b8ffdb47d85645b47489648fc71dee86ba9fc14c97641dbbf34b2c5517e4814b0cf34bf7d12c67c36c2cf8a6cfca4f2a39411597b509eac23246e28a6c61a9db83723704d4a09347e0f0f3e955b098146da095372f8801c5847c86039edd54ce16f83c207e4b73a420ecf07fcd130cb3a35d511d26a94770029d9942d4a28e592b259f344cd24351227d52b216d2f0f782f3e38f3d311724b938ac1961cb3f73b2eef679b36e10859da683e0ef03c7212261b087ff892e93ca09c80c9064349bf64c5ece993311d2595e62b9e6fc207f60a18be5afacee7f52972f5848e6abf95d4c866aa0fff8ecde2a49e309d91ac37b0cb34a4a2dae44362d4813c0041205c119cd204205584719720eca31884da31b44a1bf292cf6f8ddb7e7209638839e1a4e19934642280a8d15b1b65df5c0ccceda4e61869af9e9cbfc620c3532113607ef091b0c52e986b9afe696fe6271db86f96156a6f42282db661b228b33c51ba1602e334520619a4740d40c3f4524699a5b40d98e69dda93724a871d1965a31a9888aab3a13bd3344e8669aa3a1b32ca62b52781950e9c18e5b66a07990669ad748dc503735ff5a6bdd235901c4142acf624697e81a57a6fe5cc5374777b945f9a13de20c9952aed62e785f0df47b2232b45db0682abd630f4a593a22ef3116f487574b57a541569df65420a58f00b2e128a36202786cf9c7e9e4ef40f1066b98f7984c1477c9bd138a36cc8307a0c2515283ff8fadacf3379c97d5edec67902fe3186c0ba8978fc7e8bdf67280cea7e5f6922af0e087ea29691295f4bca23d4edae46ba616ff26640e5f4d581c003f7b30c2cbdc56bf00cbbfbb67f0ee5195b5e22b04d409496184d7df627a35f10bdfcfc7f1cda7cb100750000, '6.0.0-20911');

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `movie`
--
ALTER TABLE `movie`
  ADD CONSTRAINT `FK_movie_movieProvider_MovieProvider_Id` FOREIGN KEY (`MovieProvider_Id`) REFERENCES `movieprovider` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
