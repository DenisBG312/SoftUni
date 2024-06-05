INSERT INTO Users(Username, [Password])
	VALUES('Denis', 'pass123'),
			('Dragan', '1223111'),
			('Martin', '913891389'),
			('Ivan', '91239191111'),
			('Kristian', 'kris99111')

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC070D547F93

ALTER TABLE Users
ADD CONSTRAINT PK_UsersTable PRIMARY KEY(Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CHK_PassowrdIsAtLeastFiveSymbols
	CHECK(LEN([Password]) >= 5)

ALTER TABLE Users
DROP CONSTRAINT PK_UsersTable

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameIsAtLeastThreeSymbols
	CHECK(LEN(Username) >= 3)

SELECT * FROM Users
