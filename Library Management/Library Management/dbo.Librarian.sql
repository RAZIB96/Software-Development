CREATE TABLE [dbo].[Librarian] (
    [librarian_id] INT          NOT NULL,
    [full_name]    VARCHAR (50) NOT NULL,
    [age]          INT          NOT NULL,
    [contact]      VARCHAR (50) NOT NULL,
    [email]        VARCHAR (50) NULL,
    [password]     VARCHAR (50) NOT NULL,
    [admin]        BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([librarian_id] ASC)
);

