CREATE TABLE [dbo].[PropertyValue]
(
	[Property_ID] INT NOT NULL , 
    [Product_ID] INT NOT NULL , 
    [Value] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_PrpertyValue] PRIMARY KEY NONCLUSTERED ([Property_ID], [Product_ID]),
    CONSTRAINT [FK_PropertyValue_Property] FOREIGN KEY ([Property_ID]) REFERENCES [dbo].[Property]([Property_ID]), 
    CONSTRAINT [FK_PropertyValue_Product] FOREIGN KEY ([Product_ID]) REFERENCES [dbo].[Product]([Product_ID]) 
)
