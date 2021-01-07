CREATE TABLE [dbo].[TechSpecFilter]
(
	[Property_ID] INT NOT NULL,
    [SubCategory_ID] INT NOT NULL, 
    [Min_Value] DECIMAL NULL, 
    [Max_Value] DECIMAL NULL,
    CONSTRAINT [PK_TechSpecFilter] PRIMARY KEY NONCLUSTERED ([Property_ID], [SubCategory_ID]),
    CONSTRAINT [FK_TechSpecFilter_Property] FOREIGN KEY ([Property_ID]) REFERENCES [dbo].[Property]([Property_ID]), 
    CONSTRAINT [FK_TechSpecFilter_SubCategory] FOREIGN KEY ([SubCategory_ID]) REFERENCES [dbo].[SubCategory]([SubCategory_ID])
)
