CREATE TABLE [dbo].[User] (
    [User_ID]      INT           IDENTITY (1, 1) NOT NULL,
    [User_Name]       NVARCHAR (50) NULL,
    [User_Email]       NVARCHAR (50) NULL,
    [User_Image]       NVARCHAR(50)      NULL,
    [User_Password]    NVARCHAR (50) NULL,
    [Credential_ID]    INT           NOT NULL,

    PRIMARY KEY CLUSTERED ([User_ID] ASC), 
    CONSTRAINT [FK_User_Credential] FOREIGN KEY ([Credential_ID]) REFERENCES [dbo].[Credential]([Credential_ID]) 
)