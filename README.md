# WebCasinoHex
This is an application that administrate the players of a casino, the web application is created in ASP.NET WebForms using a sql server connection to see, add, update and delete the players. To use the application is fundamental to use the below scripts on SQL Server to create the connection and to handle the project with the DB:  


create database WebCasinoHex;

create table Players	(
    IdPlayer int not null identity(1,1) PRIMARY KEY,
    Name varchar(30) not null,
    LastName varchar(30) not null,
    MoneyAccount decimal not null,
	DateCreation date not null,
	LastDateModificacion date
	);

	BEGIN TRANSACTION;   
COMMIT TRANSACTION;   

create table Games	(
    IdGame int not null identity(1,1) PRIMARY KEY,
    Name varchar(30),
    Description varchar(500));

		BEGIN TRANSACTION;   
COMMIT TRANSACTION;   


      INSERT INTO Players(Name, LastName, MoneyAccount,DateCreation)VALUES('Robin', 'Rodriguez', 10000, GETDATE());

create procedure SP_GET_PLAYERS
as
begin

Select IdPlayer, Name, LastName as "Last name", MoneyAccount as "Money account", CONVERT(varchar(12),DateCreation, 103) AS "Date creation",  CONVERT(varchar(12),LastDateModificacion, 103) AS "Last date modification"
 from Players Order by Name
end;
BEGIN TRANSACTION;   
COMMIT TRANSACTION;



CREATE PROCEDURE SP_ADD_PLAYERS
 @VName varchar(50),
 @VLastName varchar(50), 
 @VMoneyAccount decimal
as BEGIN  
BEGIN TRY
     BEGIN TRANSACTION
          
      INSERT INTO Players(Name, LastName, MoneyAccount,DateCreation)VALUES(@VName, @VLastName, @VMoneyAccount, GETDATE());

     COMMIT TRANSACTION
END TRY
BEGIN CATCH
     ROLLBACK TRANSACTION
END CATCH
END;


CREATE PROCEDURE SP_UPDATE_PLAYERS
 @VIdPlayer int,
 @VName varchar(50),
 @VLastName varchar(50), 
 @VMoneyAccount decimal
as BEGIN  
BEGIN TRY
     BEGIN TRANSACTION
          
      UPDATE Players SET Name = @VName, LastName = @VLastName, MoneyAccount = @VMoneyAccount, LastDateModificacion = GETDATE() WHERE IdPlayer = @VIdPlayer;

     COMMIT TRANSACTION
END TRY
BEGIN CATCH
     ROLLBACK TRANSACTION
END CATCH
END;



BEGIN TRANSACTION;   
COMMIT TRANSACTION;



CREATE PROCEDURE SP_DELETE_PLAYERS
 @VIdPlayer int
as BEGIN  
BEGIN TRY
     BEGIN TRANSACTION
          DELETE FROM Players where IdPlayer = @VIdPlayer;

     COMMIT TRANSACTION
END TRY
BEGIN CATCH
     ROLLBACK TRANSACTION
END CATCH
END;

BEGIN TRANSACTION;   
COMMIT TRANSACTION;
