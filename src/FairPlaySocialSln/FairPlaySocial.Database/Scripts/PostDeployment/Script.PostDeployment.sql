﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
BEGIN TRANSACTION
--START OF DEFAULT APPLICATION ROLES
SET IDENTITY_INSERT [dbo].[ApplicationRole] ON
DECLARE @ROLE_USER NVARCHAR(50)  = 'User'
IF NOT EXISTS (SELECT * FROM [dbo].[ApplicationRole] AR WHERE [AR].[Name] = @ROLE_USER)
BEGIN 
    INSERT INTO [dbo].[ApplicationRole]([ApplicationRoleId],[Name],[Description]) VALUES(1, @ROLE_USER, 'Normal Users')
END
SET @ROLE_USER = 'Admin'
IF NOT EXISTS (SELECT * FROM [dbo].[ApplicationRole] AR WHERE [AR].[Name] = @ROLE_USER)
BEGIN 
    INSERT INTO [dbo].[ApplicationRole]([ApplicationRoleId],[Name],[Description]) VALUES(3, @ROLE_USER, 'Admin Users')
END
SET IDENTITY_INSERT [dbo].[ApplicationRole] OFF
--END OF DEFAULT APPLICATION ROLES
--START OF DEFAULT POST VISIBILITY
SET IDENTITY_INSERT [dbo].[PostVisibility] ON
DECLARE @POST_VISIBILITY_ID SMALLINT = 1
IF NOT EXISTS (SELECT * FROM [dbo].[PostVisibility] PV WHERE [PV].[Name] = 'Public')
BEGIN
    INSERT INTO [dbo].[PostVisibility]([PostVisibilityId],[Name],[Description])
    VALUES (@POST_VISIBILITY_ID, 'Public', 'Visible to everyone')
END
SET @POST_VISIBILITY_ID = 2
IF NOT EXISTS (SELECT * FROM [dbo].[PostVisibility] PV WHERE [PV].[Name] = 'Subscribers')
BEGIN
    INSERT INTO [dbo].[PostVisibility]([PostVisibilityId],[Name],[Description])
    VALUES (@POST_VISIBILITY_ID, 'Subscribers', 'Visible to subscribers only')
END
SET IDENTITY_INSERT [dbo].[PostVisibility] OFF
--END OF DEFAULT POST VISIBILITY
COMMIT