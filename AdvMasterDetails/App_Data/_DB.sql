CREATE TABLE [dbo].[Categories] (
    [CategoryID]   INT          IDENTITY (1, 1) NOT NULL,
    [CategoryName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);

CREATE TABLE [dbo].[Products] (
    [ProductID]   INT          IDENTITY (1, 1) NOT NULL,
    [CategoryID]  INT          NOT NULL,
    [ProductName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

CREATE TABLE [dbo].[OrderMaster] (
    [OrderID]     INT           NOT NULL PRIMARY KEY IDENTITY,
    [OrderNo]     VARCHAR (50)  NOT NULL,
    [OrderDate]   DATETIME      NOT NULL,
    [Description] VARCHAR (300)
);

CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetailsID] INT             NOT NULL PRIMARY KEY IDENTITY,
    [OrderID]        INT             NOT NULL,
    [ProductID]      INT             NOT NULL,
    [Rate]           NUMERIC (12, 2) NOT NULL,
    [Quantity]       INT             NOT NULL,
    CONSTRAINT [FK_OrderDetails_OrderMaster] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[OrderMaster] ([OrderID])
);






1	Ebook
2	Electronics


1	1	ASP.NET MVC5
2	1	AngularJS 2.0
3	2	DELL Ins.M0012 Leaptop
5	2	Logitech Mouse
6	2	Logitech Keyboard
