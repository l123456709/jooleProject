CREATE TABLE [dbo].[TechSpecFilter]
(
	[Property_ID] INT NOT NULL PRIMARY KEY, 
    [SubCategory_ID] INT NULL, 
    [Min_Value] DECIMAL NULL, 
    [MAx_Value] DECIMAL NULL,
    CONSTRAINT [FK_TechSpecFilter_Property] FOREIGN KEY ([Property_ID]) REFERENCES [dbo].[Property]([Property_ID]), 
    CONSTRAINT [FK_TechSpecFilter_SubCategory] FOREIGN KEY ([SubCategory_ID]) REFERENCES [dbo].[SubCategory]([SubCategory_ID])
)
