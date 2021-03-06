﻿CREATE TABLE [dbo].[Submissions]
(
	[SubmissionId] INT IDENTITY(1000000,1) NOT NULL,
	[DateSubmitted] DATETIMEOFFSET(0) DEFAULT SYSDATETIMEOFFSET() NOT NULL,
	[IsAwarded] BIT NOT NULL DEFAULT 0,
	[UserId] INT NOT NULL,
	[UploadId] INT NOT NULL,
	[JobId] INT NOT NULL,
    PRIMARY KEY ([SubmissionId]),
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([UploadId]) REFERENCES [dbo].[Uploads]([UploadId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY ([JobId]) REFERENCES [dbo].[Jobs]([JobId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT CK_Submissions_Unique_UploadId UNIQUE([UploadId])
)
