CREATE TABLE [User] (
	UserId INT IDENTITY(1, 1) PRIMARY KEY,
	Username VARCHAR(50) UNIQUE NOT NULL,
	Password VARCHAR(50) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Role VARCHAR(50) NOT NULL,
);

CREATE TABLE Account (
	Id INT IDENTITY(1000, 1) PRIMARY KEY,
	AccountName VARCHAR(50) NOT NULL,
	Balance DECIMAL(22,2) NOT NULL,
	AccountType VARCHAR(50) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES [User](UserId),
);

INSERT INTO [User] (Username, Password, FirstName, LastName, Role) VALUES 
('user1', '12345', 'John', 'Johnson', 'user'),
('user2', '123456', 'Sara', 'Reed', 'user'),
('user3', '1234567', 'Bailey', 'Mae', 'user'),
('user4', '12345678', 'Adam', 'Strong', 'user'),
('admin', '11111', 'admin', 'admin', 'admin');


INSERT INTO Account (AccountName, Balance, AccountType, UserId) VALUES 
('JJohnsonChecking', 10000.99, 'Checking', 1),
('SaraSavings', 550.00, 'Saving', 2),
('MaeAccount', 5000.90, 'Checking', 3),
('AdamsChecking', 25000.00, 'Checking', 4);