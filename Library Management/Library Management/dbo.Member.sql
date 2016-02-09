CREATE TABLE [dbo].[Member]
(
	[Member_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [full_name] VARCHAR(50) NOT NULL, 
    [age] INT NOT NULL, 
    [contact] VARCHAR(50) NOT NULL, 
    [email] VARCHAR(50) NOT NULL, 
    [reader_catagory] VARCHAR(50) NOT NULL
)
