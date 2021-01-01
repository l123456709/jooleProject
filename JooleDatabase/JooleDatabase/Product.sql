CREATE TABLE [dbo].[Product]
(
	[Product_ID] INT NOT NULL PRIMARY KEY, 
    [SubCategory_ID] INT NULL, 
    [Product_Name] NVARCHAR(200) NULL, 
    [Product_Image] NVARCHAR(50) NULL, 
    [Series] NVARCHAR(50) NULL, 
    [Model] NVARCHAR(50) NULL, 
    [Model_Year] NVARCHAR(50) NULL, 
    [Series_Info] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Product_SubCategory] FOREIGN KEY ([SubCategory_ID]) REFERENCES [dbo].[SubCategory]([SubCategory_ID])
)
