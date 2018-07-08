1. Скрипты создания таблиц
CREATE TABLE [dbo].[Departments]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NULL
)


CREATE TABLE [dbo].[People]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(5000) NULL, 
    [Age] INT NOT NULL DEFAULT 0, 
    [Position] VARCHAR(5000) NULL, 
    [Grade] INT NOT NULL DEFAULT 0, 
    [Salary] INT NOT NULL DEFAULT 0, 
    [Department] INT NULL, 
    CONSTRAINT [FK_People_ToDepartments] FOREIGN KEY ([Department]) REFERENCES [Departments]([id])
)

2. Для заполнения тестовыми данными Нажать кнопку Set test data