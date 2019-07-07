CREATE TABLE "users" (
	[ID] int NOT NULL IDENTITY(1,1),
	[fullName] varchar(250) NOT NULL,
	[date_brith] DATETIME NOT NULL,
	[age] int NOT NULL,
	[sex] char NOT NULL,
	[login] varchar(20) NOT NULL,
	[password] varchar(20) NOT NULL,
	[date_registration] DATETIME NOT NULL,
	PRIMARY KEY ([ID]),
	UNIQUE ([login],[password])
);
CREATE TABLE "skills" (
	[ID] int NOT NULL IDENTITY(1,1),
	[ID_user] int NOT NULL,
	[name] varchar(250) NOT NULL,
	[description] varchar(250) NOT NULL,
	[type] varchar(10) NOT NULL,
	[date_creation] DATETIME NOT NULL,
	PRIMARY KEY ([ID]),
	UNIQUE ([ID_user],[name])
);

INSERT INTO users ([fullName],[age],[date_brith],[sex],[login],[password],[date_registration])
	VALUES 
	('Емельянов Денис Олегович','20','27-07-1998','M','Denchik','270798','20-06-2019'),
	('Сергеев Александр Иванович','50','21-09-1968','M','Ivan','ivanich','23-06-2019'),
	('Улыбина Татьяна Сергеевна','22','12-11-1996','W','Tanya','qwerty','25-06-2019')

INSERT INTO skills([ID_user],[name],[description],[type],[date_creation])
	VALUES 
	('1','Программист','Работаю на C#,JAVA,NODE.JS','Hard','20-06-2019'),
	('2','Строитель','Маляр-штукатур, облицовщик, каменщик','Hard','23-06-2019'),
	('3','Коммуникабельность','Ведение переговоров, убеждение и аргументация, командная работа, клиенториентированность','Soft','25-06-2019')