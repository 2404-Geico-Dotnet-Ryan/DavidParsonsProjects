CREATE TABLE Customer (
	Id int,
	Username varchar(50),
	Password varchar(50),
	FirstName varchar(50),
	LastName varchar(50),
	Role varchar(50),
);

CREATE TABLE Account (
	Id int,
	AccountName varchar(50),
	Balance decimal(22, 2),
	AccountType varchar(50),
	OwnerId int,
);

INSERT INTO Customer VALUES 
(1, 'user1', '12345', 'John', 'Johnson', 'user'),
(2, 'user2', '123456', 'Sara', 'Reed', 'user'),
(3, 'user3', '1234567', 'Bailey', 'Mae', 'user'),
(4, 'user4', '12345678', 'Adam', 'Strong', 'user'),
(5, 'admin', '11111', 'admin', 'admin', 'admin');

INSERT INTO Account VALUES 
(1, 'JJohnsonChecking', 10000.99, 'Checking', 1),
(2, 'SaraSavings', 550.00, 'Saving', 2),
(3, 'MaeAccount', 5000.90, 'Checking', 3),
(4, 'AdamsChecking', 25000.00, 'Checking', 4);