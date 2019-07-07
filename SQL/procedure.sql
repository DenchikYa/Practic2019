CREATE PROCEDURE addUser
	@ID int OUTPUT,
	@FullName varchar(250),
	@DateOfBrith DATETIME,
	@age int,
	@sex char,
	@login varchar(20),
	@password varchar(20),
	@date_registration DATETIME
	AS
	INSERT INTO users ([fullName],[age],[date_brith],[sex],[login],[password],[date_registration])
	VALUES 
		(@FullName,@age,@DateOfBrith,@sex,@login,@password,@date_registration)

CREATE PROCEDURE addSkill
	@ID int OUTPUT,
	@ID_user int,
	@name varchar(250),
	@desctiorion varchar(250),
	@type varchar(10),
	@date_creation DATETIME
	AS
	INSERT INTO skills([ID_user],[name],[description],[type],[date_creation])
		VALUES 
		(@ID_user,@name,@desctiorion,@type,@date_creation)

CREATE PROCEDURE findForLogin
	@Login varchar(20)
	as
	SELECT ID FROM users WHERE login = @Login

CREATE PROCEDURE authorizationUser
	@Login varchar(20),
	@Password varchar(20)
	as
	SELECT ID FROM users WHERE login = @Login and password = @Password

CREATE PROCEDURE getUserById
	@ID int
	as
	SELECT * FROM users WHERE ID = @ID

CREATE PROCEDURE getSkillsByIDUser
	@ID int
	as
	SELECT * FROM skills WHERE ID_user = @ID

CREATE PROCEDURE editFullNameUser
	@ID int,
	@FullName varchar(250)
	as
	Update users SET fullName = @FullName WHERE ID = @ID

CREATE PROCEDURE editPasswordUser
	@ID int,
	@Password varchar(250)
	as
	Update users SET password = @Password WHERE ID = @ID

CREATE PROCEDURE editNameSkill
	@ID int,
	@Name varchar(250)
	as
	Update skills SET name = @Name WHERE ID = @ID

CREATE PROCEDURE editDescriptionSkill
	@ID int,
	@Description varchar(250)
	as
	Update skills SET description = @Description WHERE ID = @ID

CREATE PROCEDURE deleteSkill
	@ID int
	as
	Delete skills WHERE ID = @ID

CREATE PROCEDURE findSkill
    @ID int,
	@Name varchar(20)
	as
	SELECT * FROM skills WHERE name LIKE @Name+'%' and ID_user = @ID