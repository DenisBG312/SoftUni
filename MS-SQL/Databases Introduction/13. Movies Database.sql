CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DirectorName VARCHAR(150) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	GenreName VARCHAR(150) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(150) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(150),
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME2,
	[Length] INT,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes VARCHAR(MAX),
	FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
	FOREIGN KEY (GenreId) REFERENCES Genres(Id),
	FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
)

ALTER TABLE MOVIES
ADD CONSTRAINT FK_DirectorId 
FOREIGN KEY (DirectorId) REFERENCES Directors(Id)

ALTER TABLE MOVIES
ADD CONSTRAINT FK_GenreId
FOREIGN KEY (GenreId) REFERENCES Genres(Id)

ALTER TABLE MOVIES
ADD CONSTRAINT FK_CategoryId
FOREIGN KEY (CategoryId) REFERENCES Categories(Id)


INSERT INTO Directors (DirectorName, Notes) VALUES
('Steven Spielberg', 'Known for blockbuster films'),
('Christopher Nolan', 'Known for complex narratives'),
('Quentin Tarantino', 'Known for stylized violence and dialogue'),
('Martin Scorsese', 'Known for crime films'),
('James Cameron', 'Known for epic science fiction films');

INSERT INTO Genres (GenreName, Notes) VALUES
('Action', 'Fast-paced, high energy'),
('Drama', 'Focuses on emotional narratives'),
('Comedy', 'Humorous content'),
('Science Fiction', 'Futuristic, speculative content'),
('Horror', 'Intended to scare and thrill');

INSERT INTO Categories (CategoryName, Notes) VALUES
('Feature Film', 'Full-length film'),
('Short Film', 'Brief, less than 40 minutes'),
('Documentary', 'Non-fiction film'),
('Animation', 'Animated content'),
('Series', 'Multiple episodes');

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
					('Inception', 1, '1999-01-03', 148, 1, 1, 8.8, 'A mind-bending thriller'),
					('Pulp Fiction', 2, '1998-02-03', 154, 2, 2, 8.9, 'A classic Tarantino film'),
					('Avatar', 3, '2003-09-01', 162, 3, 3, 7.8, 'A groundbreaking 3D film'),
					('The Godfather', 4, '2006-03-05', 175, 4, 4, 9.2, 'A mafia classic'),
					('Jurassic Park', 5, '2003-02-08', 127, 5, 5, 8.1, 'A dinosaur adventure');

SELECT * FROM Movies
