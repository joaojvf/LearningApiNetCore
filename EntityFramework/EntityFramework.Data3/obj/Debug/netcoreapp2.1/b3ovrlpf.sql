CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NULL,
    `LastName` longtext NULL,
    `UrlPhoto` longtext NULL,
    `Sex` int NOT NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200408183924_Init', '2.1.14-servicing-32113');

ALTER TABLE `Users` MODIFY COLUMN `UrlPhoto` varchar(400) NOT NULL;

ALTER TABLE `Users` MODIFY COLUMN `Name` varchar(400) NOT NULL;

ALTER TABLE `Users` MODIFY COLUMN `LastName` varchar(400) NOT NULL;

ALTER TABLE `Users` ADD `DateBirth` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000';

ALTER TABLE `Users` ADD `Email` varchar(400) NOT NULL DEFAULT '';

ALTER TABLE `Users` ADD `Password` varchar(400) NOT NULL DEFAULT '';

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200408194252_AddUserConfig', '2.1.14-servicing-32113');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200408194559_AddUserConfigNovo', '2.1.14-servicing-32113');

CREATE TABLE `Posts` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DatePublish` datetime(6) NOT NULL,
    `Text` longtext NULL,
    CONSTRAINT `PK_Posts` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200408200710_AddPostagem', '2.1.14-servicing-32113');

CREATE TABLE `RelationshipStatus` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Description` longtext NULL,
    CONSTRAINT `PK_RelationshipStatus` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200408202607_AddStatusRelationship', '2.1.14-servicing-32113');

