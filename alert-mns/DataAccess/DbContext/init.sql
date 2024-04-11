CREATE DATABASE IF NOT EXISTS `alertmns`;

USE `alertmns`;

DROP TABLE IF EXISTS `take`;
DROP TABLE IF EXISTS `notification`;
DROP TABLE IF EXISTS `message`;
DROP TABLE IF EXISTS `channel`;
DROP TABLE IF EXISTS `appointment`;
DROP TABLE IF EXISTS `work_time`;
DROP TABLE IF EXISTS `user`;
DROP TABLE IF EXISTS `profession`;
DROP TABLE IF EXISTS `company`;
DROP TABLE IF EXISTS `role`;
DROP TABLE IF EXISTS `notification_type`;

CREATE TABLE `company` (
    `company_id` BIGINT AUTO_INCREMENT NOT NULL,
    `company_name` VARCHAR(20),
    PRIMARY KEY (`company_id`)
) ENGINE=InnoDB;

CREATE TABLE `profession` (
    `profession_id` BIGINT AUTO_INCREMENT NOT NULL,
    `profession_name` VARCHAR(10),
    PRIMARY KEY (`profession_id`)
) ENGINE=InnoDB;

CREATE TABLE `role` (
    `role_id` BIGINT AUTO_INCREMENT NOT NULL,
    `role_name` VARCHAR(20),
    PRIMARY KEY (`role_id`)
) ENGINE=InnoDB;

CREATE TABLE `notification_type` (
    `notification_type_id` BIGINT AUTO_INCREMENT NOT NULL,
    `notification_type_name` VARCHAR(20),
    PRIMARY KEY (`notification_type_id`)
) ENGINE=InnoDB;

CREATE TABLE `user` (
    `user_id` BIGINT AUTO_INCREMENT NOT NULL,
    `last_name` VARCHAR(20),
    `first_name` VARCHAR(20),
    `email` VARCHAR(255),
    `password` VARCHAR(255),
    `account_creation_date` DATETIME NOT NULL DEFAULT NOW(),
    `last_login_date` DATETIME NOT NULL DEFAULT NOW(),
    `status` BOOLEAN DEFAULT FALSE,
    `profession_id` BIGINT,
    `company_id` BIGINT,
    `role_id` BIGINT,
    PRIMARY KEY (`user_id`),
    FOREIGN KEY (`profession_id`) REFERENCES `profession` (`profession_id`),
    FOREIGN KEY (`company_id`) REFERENCES `company` (`company_id`),
    FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`)
) ENGINE=InnoDB;

CREATE TABLE `channel` (
    `channel_id` BIGINT AUTO_INCREMENT NOT NULL,
    `channel_name` VARCHAR(50),
    `channel_description` VARCHAR(100),
    `channel_creation_date` DATETIME NOT NULL DEFAULT NOW(),
    `user_id` BIGINT,
    PRIMARY KEY (`channel_id`),
    FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB;

CREATE TABLE `message` (
    `message_id` BIGINT AUTO_INCREMENT NOT NULL,
    `message_content` VARCHAR(255),
    `attachment` VARCHAR(255),
    `send_date_time` DATETIME NOT NULL DEFAULT NOW(),
    `channel_id` BIGINT,
    `user_id` BIGINT,
    PRIMARY KEY (`message_id`),
    FOREIGN KEY (`channel_id`) REFERENCES `channel` (`channel_id`),
    FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB;

CREATE TABLE `notification` (
    `notification_id` BIGINT AUTO_INCREMENT NOT NULL,
    `notification_content` VARCHAR(100),
    `send_date_time` DATETIME NOT NULL DEFAULT NOW(),
    `user_id` BIGINT,
    `notification_type_id` BIGINT,
    PRIMARY KEY (`notification_id`),
    FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`),
    FOREIGN KEY (`notification_type_id`) REFERENCES `notification_type` (`notification_type_id`)
) ENGINE=InnoDB;

CREATE TABLE `appointment` (
    `appointment_id` BIGINT AUTO_INCREMENT NOT NULL,
    `subject` VARCHAR(20),
    `status` ENUM('planned', 'in_progress', 'completed'),
    PRIMARY KEY (`appointment_id`)
) ENGINE=InnoDB;

CREATE TABLE `work_time` (
    `work_time_id` BIGINT AUTO_INCREMENT NOT NULL,
    `worker_user_id` BIGINT,
    `work_date` DATE,
    `arrival_time` DATETIME,
    `departure_time` DATETIME,
    `user_id` BIGINT,
    PRIMARY KEY (`work_time_id`),
    FOREIGN KEY (`worker_user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB;
