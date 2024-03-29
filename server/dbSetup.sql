CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE houses (
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  sqft INT NOT NULL,
  bedrooms INT NOT NULL,
  bathrooms DOUBLE NOT NULL,
  imgURL VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  price INT NOT NULL,
  creatorId VARCHAR(255),
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
)

DROP TABLE houses;

SELECT id, name FROM accounts;

INSERT INTO houses(sqft, bedrooms, bathrooms, imgURL, description, price, creatorId) VALUES(2000, 4, 2.5, "https://images.unsplash.com/photo-1570129477492-45c003edd2be?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Just a very nice looking house", 5000000, "65d6301b1eed6e98942ed964")