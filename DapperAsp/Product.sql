create database gadgetstore_db

use gadgetstore_db

create table [Gadget] 
(
 [ID] int identity primary key,
 [Name] varchar(25),
 [Price] float
)

create table [Category]
(
 [ID] int identity primary key,
 [NAME_PRODUCT] varchar(100)
);

CREATE TRIGGER Gadget_Insert
ON [Gadget]
AFTER INSERT
AS
SELECT * FROM inserted;
ENABLE TRIGGER Gadget_Insert ON [Gadget];

CREATE TRIGGER Gadget_Delete
ON [Gadget]
AFTER Delete
AS
SELECT [ID] FROM deleted;
ENABLE TRIGGER Gadget_Delete ON [Gadget];

CREATE TRIGGER Gadget_Update
ON [Gadget]
AFTER UPDATE
AS
SELECT * FROM inserted;
ENABLE TRIGGER Gadget_Update ON [Gadget];

SELECT [Category].[NAME_PRODUCT] FROM [Category] JOIN [Gadget] on [Category].[ID] = [Gadget].[ID]

insert into [Category] ([NAME_PRODUCT]) values ('Car'), ('Phone'), ('Foods')

insert into [Gadget] ([Name], [Price]) values ('Apple',12.5), ('Orange', 16.35), ('Kiwi',6.25), ('Mango',18.12)