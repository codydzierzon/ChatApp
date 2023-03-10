USE master
GO
--drop database if it exists
IF DB_ID('TeamChat') IS NOT NULL
BEGIN
	ALTER DATABASE TeamChat SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE TeamChat
END
GO

CREATE DATABASE TeamChat
GO
PRINT 'TeamChat database created'

USE TeamChat
GO
PRINT ''
PRINT '---------------'
PRINT 'Creating tables'
PRINT '---------------'
PRINT ''

CREATE TABLE dbo.Users
(
	UserId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserName NVARCHAR(200) NOT NULL,
	HashedPassword NVARCHAR(2000) NOT NULL,
	Salt NVARCHAR(2000) NOT NULL
)

CREATE TABLE Messages
(
	MessageId INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	, SenderId INT
	, ReceiverId INT
	, MessageRead BIT DEFAULT(0)
	, [Message] NVARCHAR(MAX)
	, DateSend DATE DEFAULT CURRENT_TIMESTAMP
	, TimeSend TIME DEFAULT GETDATE()
)

GO
PRINT 'Users table created.'


PRINT ''
PRINT '--------------------'
PRINT 'Populating tables'
PRINT '--------------------'
PRINT ''
GO

-- all passwords are password
SET IDENTITY_INSERT Users ON
GO
INSERT INTO Users (UserId, UserName, HashedPassword, Salt)
VALUES (1, 'autumn', N'��r���rp�ӽ!$ץ��TG�σ��3P#fuR',N'^l}.��h�P��}�B�/�t��;�m��')
     , (2, 'christoph', N'��r���rp�ӽ!$ץ��TG�σ��3P#fuR',N'^l}.��h�P��}�B�/�t��;�m��')
     , (3, 'cody', N'��r���rp�ӽ!$ץ��TG�σ��3P#fuR',N'^l}.��h�P��}�B�/�t��;�m��')
     , (4, 'manuel', N'��r���rp�ӽ!$ץ��TG�σ��3P#fuR',N'^l}.��h�P��}�B�/�t��;�m��')
     , (5, 'gregor', N'��r���rp�ӽ!$ץ��TG�σ��3P#fuR',N'^l}.��h�P��}�B�/�t��;�m��')
GO
SET IDENTITY_INSERT Users OFF
GO

INSERT INTO Messages (SenderId, ReceiverId, [Message])
VALUES (1, 5, 'Hello')
	, (5, 1, 'Hi')
	, (1, 5, 'How are you?')




ALTER TABLE Messages
ADD CONSTRAINT FK_Messages_SenderId
FOREIGN KEY (SenderId)
REFERENCES Users(UserId)

