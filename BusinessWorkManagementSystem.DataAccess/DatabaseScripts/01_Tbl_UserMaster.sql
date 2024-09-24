USE [BusinessWorkManagementSystem]
GO

CREATE TABLE [dbo].[Tbl_UserMaster](
	[UserId] [int] NOT NULL,
	[UserFirstName] [nvarchar](200) NULL,
	[UserLastName] [nvarchar](200) NULL,
	[UserEmailAddress] [nvarchar](500) NULL,
	[UserMobileNumber] [nvarchar](20) NULL,
	[CountryId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[Active] [bit] NULL,
	[UserPassword] [nvarchar](20) NULL,
 CONSTRAINT [PK_Tbl_UserMaster] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [BusinessWorkManagementSystem]
GO

INSERT INTO [dbo].[Tbl_UserMaster]
           ([UserId]
           ,[UserFirstName]
           ,[UserLastName]
           ,[UserEmailAddress]
           ,[UserMobileNumber]
           ,[CountryId]
           ,[CreatedBy]
           ,[CreatedOn]
           ,[UpdateBy]
           ,[UpdatedOn]
           ,[Active]
           ,[UserPassword])
     VALUES
           (1
           ,'Saisha'
           ,'Shinde'
           ,'gorakhshankarshinde@gmail.com'
           , '9923731039'
           ,91
           ,1
           ,null
           ,1
           ,null
           ,1
           ,'Saisha')
GO


