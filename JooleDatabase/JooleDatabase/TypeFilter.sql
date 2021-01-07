CREATE TABLE [dbo].[TypeFilter]
(
	[Property_ID] INT NOT NULL , 
    [SubCategory_ID]INT NOT NULL ,
    [Type_Name] NVARCHAR (50) NULL, 
    [Type_Options] NVARCHAR (50) NULL, 
    CONSTRAINT [PK_TypeFilter] PRIMARY KEY NONCLUSTERED ([Property_ID], [SubCategory_ID]),
    CONSTRAINT [FK_TypeFilter_Property] FOREIGN KEY ([Property_ID]) REFERENCES [dbo].[Property]([Property_ID]), 
    CONSTRAINT [FK_TypeFilter_SubCategory] FOREIGN KEY ([SubCategory_ID]) REFERENCES [dbo].[SubCategory]([SubCategory_ID])
)
