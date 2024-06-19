CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

INSERT INTO Users(Username, [Password])
	VALUES('Denis', 'pass123'),
			('Dragan', '1223111'),
			('Martin', '913891389'),
			('Ivan', '91239191111'),
			('Kristian', 'kris99111')
