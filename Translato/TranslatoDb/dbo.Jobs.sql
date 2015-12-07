﻿CREATE TABLE [dbo].[Jobs]
(
	[JobId] INT IDENTITY(1000000,1) NOT NULL,
    [JobName] NVARCHAR(50) NOT NULL,
    [DateCreated] DATETIMEOFFSET(0) DEFAULT SYSDATETIMEOFFSET() NOT NULL,
    [DurationInDays] INT NOT NULL,
    [Reward] DECIMAL(13, 2) DEFAULT 0 NOT NULL,
	[DateAwarded] DATETIMEOFFSET(0) DEFAULT NULL NULL,
    [LanguageFrom] INT NOT NULL,
	[LanguageTo] INT NOT NULL,
	[UserId] INT NOT NULL,
	[UploadId] INT NOT NULL,
	PRIMARY KEY ([JobId]),
	FOREIGN KEY ([LanguageFrom]) REFERENCES [dbo].[Languages]([LanguageId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([LanguageTo]) REFERENCES [dbo].[Languages]([LanguageId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([UploadId]) REFERENCES [dbo].[Uploads]([UploadId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT CK_Jobs_Unique_FileId UNIQUE([UploadId])
)
