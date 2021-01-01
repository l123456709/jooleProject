CREATE TABLE [dbo].[SubCategory]
(
	[SubCategory_ID] INT NOT NULL PRIMARY KEY, 
    [Category_ID] INT NULL, 
    [SubCategory_Name] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY ([Category_ID]) REFERENCES [dbo].[Category]([Category_ID])
)
