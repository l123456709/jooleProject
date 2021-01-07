CREATE TABLE [dbo].[Property]
(
	[Property_ID] INT NOT NULL PRIMARY KEY, 
    [Property_Name] NVARCHAR(50) NULL, 
    [IsType] BIT NULL, 
    [IsTechSpec] BIT NULL
)
