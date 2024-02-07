-- Active: 1702942233787@@35.167.34.37@3306@Growth
CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key', createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created', updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update', name varchar(255) COMMENT 'User Name', email varchar(255) COMMENT 'User Email', picture varchar(255) COMMENT 'User Picture', UNIQUE KEY (name)
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS projects (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, createdAt DATETIME DEFAULT CURRENT_TIMESTAMP, updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, name VARCHAR(255) NOT NULL, description VARCHAR(1500) NOT NULL, creatorId VARCHAR(255) NOT NULL, Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS sprints (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, createdAt DATETIME DEFAULT CURRENT_TIMESTAMP, updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, name VARCHAR(255) NOT NULL, isOpen BOOLEAN NOT NULL DEFAULT true, projectId INT NOT NULL, creatorId VARCHAR(255) NOT NULL, Foreign Key (projectId) REFERENCES projects (id) ON DELETE CASCADE, Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS tasks (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, createdAt DATETIME DEFAULT CURRENT_TIMESTAMP, updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, name VARCHAR(500) NOT NULL, weight TINYINT NOT NULL, isCompleted BOOLEAN NOT NULL DEFAULT false, assignedTo VARCHAR(255), projectId INT NOT NULL, creatorId VARCHAR(255) NOT NULL, sprintId INT NOT NULL, Foreign Key (assignedTo) REFERENCES accounts (name), Foreign Key (projectId) REFERENCES projects (id) ON DELETE CASCADE, Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE, Foreign Key (sprintId) REFERENCES sprints (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

-- TODO Need to see how to add completedOn triggered by isCompleted boolean yes

CREATE TABLE IF NOT EXISTS notes (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, createdAt DATETIME DEFAULT CURRENT_TIMESTAMP, updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, body VARCHAR(1500) NOT NULL, taskId INT NOT NULL, projectId INT NOT NULL, creatorId VARCHAR(255) NOT NULL, Foreign Key (taskId) REFERENCES tasks (id) ON DELETE CASCADE, Foreign Key (projectId) REFERENCES projects (id) ON DELETE CASCADE, Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';