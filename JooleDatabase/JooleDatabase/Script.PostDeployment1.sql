﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO Category AS Target 
USING (VALUES 
        (2, 'Stational')
) 
AS Source (Category_ID, Category_Name) 
ON Target.Category_ID = Source.Category_ID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Category_ID, Category_Name) 
VALUES (Category_ID, Category_Name);


MERGE INTO SubCategory AS Target 
USING (VALUES 
        (4, 2, 'Power Supply Cords'),
        (5, 2, 'Motors'),
        (6, 2, 'Locking Connectors')
) 
AS Source (SubCategory_ID, Category_ID, SubCategory_Name) 
ON Target.SubCategory_ID = Source.SubCategory_ID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (SubCategory_ID, Category_ID, SubCategory_Name) 
VALUES (SubCategory_ID, Category_ID, SubCategory_Name);


MERGE INTO Product AS Target 
USING (VALUES 
        (7, 4, 'Pig Tail Power Supply Cord 4', '', 'B07QYR9C9K', 'WF4629', '2019', 'B07QYR9C9K'),
        (8, 4, 'Pig Tail Power Supply Cord 8', '', 'B07RQNZJB7', 'WF4631', '2019', 'B07RQNZJB7'),
        (9, 5, 'Marathon® TEFC General Purpose Motors For High Torque Applications 4.4AMP', '', 'B007ZQLG3W', 'MR3320', '2010', 'B007ZQLG3W'),
        (10, 5, 'Marathon® TEFC Electronic Starting Direct Drive Feed Auger Motors', '', 'B007ZQNZ6I', 'MR4005', '2011', 'B007ZQNZ6I'),
        (11, 6, 'Single Phase Locking Connector 15 Amps, 125 Volts', '', 'B0137HKRHS', 'LJ5412', '2015', 'B0137HKRHS'),
        (12, 6, 'Three Phase Locking Connector 20 Amps, 250 Volts', '', 'B00E2Y5VWM', 'LJ5262', '2014', 'B00E2Y5VWM')
) 
AS Source (Product_ID, SubCategory_ID, Product_Name, Product_Image, Series, Model, Model_Year, Series_Info) 
ON Target.Product_ID = Source.Product_ID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Product_ID, SubCategory_ID, Product_Name, Product_Image, Series, Model, Model_Year, Series_Info) 
VALUES (Product_ID, SubCategory_ID, Product_Name, Product_Image, Series, Model, Model_Year, Series_Info);

MERGE INTO Property AS Target 
USING (VALUES 
        (1, 'Commercial', 1, 0),
        (2, 'Application', 1, 0),

) 
AS Source (Category_ID, Category_Name) 
ON Target.Category_ID = Source.Category_ID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Category_ID, Category_Name) 
VALUES (Category_ID, Category_Name);