USE TeamChat
GO


--SELECT u.UserId	
--	, u.UserName
--	, m.MessageId
--	, m.SenderId
--	, m.ReceiverId
--	, m.MessageRead
--	, m.[Message]
--	, m.DateSend
--	, m.TimeSend
--FROM Users AS u
--LEFT JOIN Messages AS m ON u.UserId = m.SenderId

ALTER VIEW MessageInformation
AS

SELECT NEWID() AS id
	, u.UserId	
	, u.UserName
	, m.MessageId
	, m.SenderId
	, m.ReceiverId
	, m.MessageRead
	, m.[Message]
	, m.DateSend
	, m.TimeSend
	, 'sender' as MessageType
FROM Users AS u
INNER JOIN Messages AS m 
	ON u.userId = m.SenderId

UNION

SELECT NEWID()
	, u.UserId	
	, u.UserName
	, m.MessageId
	, m.SenderId
	, m.ReceiverId
	, m.MessageRead
	, m.[Message]
	, m.DateSend
	, m.TimeSend
	, 'receiver'
FROM Users AS u
INNER JOIN Messages AS m 
	ON u.userId = m.ReceiverId
GO

select *
from Messages
where ReceiverId = 5