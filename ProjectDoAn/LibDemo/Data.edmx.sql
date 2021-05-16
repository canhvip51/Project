
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2021 12:55:28
-- Generated from EDMX file: C:\Users\ADMIN\Desktop\web\ProjectFireTool\LibDemo\Data.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SHOESSHOP];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Cart_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cart] DROP CONSTRAINT [FK_Cart_User];
GO
IF OBJECT_ID(N'[dbo].[FK_District_Province]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[District] DROP CONSTRAINT [FK_District_Province];
GO
IF OBJECT_ID(N'[dbo].[FK_Import_ImportUnit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Import] DROP CONSTRAINT [FK_Import_ImportUnit];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_User];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderDetail_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetail] DROP CONSTRAINT [FK_OrderDetail_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductImg_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductImg] DROP CONSTRAINT [FK_ProductImg_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_Ward_District]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ward] DROP CONSTRAINT [FK_Ward_District];
GO
IF OBJECT_ID(N'[dbo].[FK_Warehouse_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Warehouse] DROP CONSTRAINT [FK_Warehouse_Product];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BanList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BanList];
GO
IF OBJECT_ID(N'[dbo].[Brand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brand];
GO
IF OBJECT_ID(N'[dbo].[Cart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cart];
GO
IF OBJECT_ID(N'[dbo].[Config]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Config];
GO
IF OBJECT_ID(N'[dbo].[District]', 'U') IS NOT NULL
    DROP TABLE [dbo].[District];
GO
IF OBJECT_ID(N'[dbo].[Import]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Import];
GO
IF OBJECT_ID(N'[dbo].[ImportUnit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImportUnit];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[OrderDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderDetail];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[ProductImg]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductImg];
GO
IF OBJECT_ID(N'[dbo].[Province]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Province];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TypeShoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeShoes];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Ward]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ward];
GO
IF OBJECT_ID(N'[dbo].[Warehouse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Warehouse];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BanLists'
CREATE TABLE [dbo].[BanLists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [Phone] nchar(20)  NULL,
    [Email] nvarchar(255)  NULL,
    [Facebook] nvarchar(255)  NULL,
    [Amount] int  NULL,
    [Status] int  NULL,
    [IsDelete] int  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'Brands'
CREATE TABLE [dbo].[Brands] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NULL,
    [IsDelete] int  NULL,
    [CreateDate] datetime  NULL
);
GO

-- Creating table 'Carts'
CREATE TABLE [dbo].[Carts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [WarehouseId] int  NULL,
    [Amount] int  NULL,
    [IsDelete] int  NULL,
    [Status] int  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'Configs'
CREATE TABLE [dbo].[Configs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Value] nvarchar(max)  NULL
);
GO

-- Creating table 'Districts'
CREATE TABLE [dbo].[Districts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Type] nvarchar(200)  NOT NULL,
    [ProvinceId] int  NOT NULL
);
GO

-- Creating table 'Imports'
CREATE TABLE [dbo].[Imports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WarehouseId] int  NULL,
    [Price] int  NULL,
    [Amount] int  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [IsDelete] int  NULL,
    [Status] int  NULL,
    [ImportUnitId] int  NULL
);
GO

-- Creating table 'ImportUnits'
CREATE TABLE [dbo].[ImportUnits] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProvinceId] int  NULL,
    [DistrictId] int  NULL,
    [WardId] int  NULL,
    [Address] nvarchar(max)  NULL,
    [CreateDate] datetime  NULL,
    [IsDelete] int  NULL,
    [IsUpdate] datetime  NULL,
    [Phone] nchar(20)  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Total] int  NULL,
    [Discount] int  NULL,
    [UserId] int  NULL,
    [SaleId] int  NULL,
    [Code] nchar(20)  NULL,
    [IsDelete] int  NULL,
    [Status] int  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [AddressTo] nvarchar(max)  NULL,
    [Phone] nchar(10)  NULL,
    [AccountNumber] nchar(10)  NULL,
    [AddressFrom] nvarchar(max)  NULL
);
GO

-- Creating table 'OrderDetails'
CREATE TABLE [dbo].[OrderDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderId] int  NULL,
    [ProductId] int  NULL,
    [Price] int  NULL,
    [Amount] int  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BrandId] int  NULL,
    [Name] nvarchar(255)  NULL,
    [TypeShoeId] int  NULL,
    [Describe] nvarchar(max)  NULL,
    [Status] int  NULL,
    [Origin] nvarchar(255)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [IsDelete] int  NULL,
    [Price] nvarchar(255)  NULL
);
GO

-- Creating table 'ProductImgs'
CREATE TABLE [dbo].[ProductImgs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Url] nvarchar(max)  NULL,
    [ProductId] int  NULL
);
GO

-- Creating table 'Provinces'
CREATE TABLE [dbo].[Provinces] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Type] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TypeShoes'
CREATE TABLE [dbo].[TypeShoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [CreateDate] datetime  NULL,
    [IsDelete] int  NULL,
    [Status] int  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(255)  NULL,
    [Password] nchar(100)  NULL,
    [Email] nvarchar(255)  NULL,
    [Phone] varchar(20)  NULL,
    [Facebook] nvarchar(255)  NULL,
    [Role] int  NULL,
    [ProvinceId] int  NULL,
    [DistrictId] int  NULL,
    [WardId] int  NULL,
    [Status] int  NULL,
    [IsDelete] int  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [FullName] nvarchar(255)  NULL
);
GO

-- Creating table 'Wards'
CREATE TABLE [dbo].[Wards] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] nvarchar(30)  NOT NULL,
    [DistrictId] int  NOT NULL
);
GO

-- Creating table 'Warehouses'
CREATE TABLE [dbo].[Warehouses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] int  NULL,
    [Size] int  NULL,
    [Color] nchar(10)  NULL,
    [ProductId] int  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [Status] nchar(10)  NULL,
    [IsDelete] nchar(10)  NULL,
    [Price] int  NULL,
    [Discount] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BanLists'
ALTER TABLE [dbo].[BanLists]
ADD CONSTRAINT [PK_BanLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Brands'
ALTER TABLE [dbo].[Brands]
ADD CONSTRAINT [PK_Brands]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [PK_Carts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Configs'
ALTER TABLE [dbo].[Configs]
ADD CONSTRAINT [PK_Configs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Districts'
ALTER TABLE [dbo].[Districts]
ADD CONSTRAINT [PK_Districts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Imports'
ALTER TABLE [dbo].[Imports]
ADD CONSTRAINT [PK_Imports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ImportUnits'
ALTER TABLE [dbo].[ImportUnits]
ADD CONSTRAINT [PK_ImportUnits]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [PK_OrderDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductImgs'
ALTER TABLE [dbo].[ProductImgs]
ADD CONSTRAINT [PK_ProductImgs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Provinces'
ALTER TABLE [dbo].[Provinces]
ADD CONSTRAINT [PK_Provinces]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeShoes'
ALTER TABLE [dbo].[TypeShoes]
ADD CONSTRAINT [PK_TypeShoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Wards'
ALTER TABLE [dbo].[Wards]
ADD CONSTRAINT [PK_Wards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Warehouses'
ALTER TABLE [dbo].[Warehouses]
ADD CONSTRAINT [PK_Warehouses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [FK_Cart_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cart_User'
CREATE INDEX [IX_FK_Cart_User]
ON [dbo].[Carts]
    ([UserId]);
GO

-- Creating foreign key on [ProvinceId] in table 'Districts'
ALTER TABLE [dbo].[Districts]
ADD CONSTRAINT [FK_District_Province]
    FOREIGN KEY ([ProvinceId])
    REFERENCES [dbo].[Provinces]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_District_Province'
CREATE INDEX [IX_FK_District_Province]
ON [dbo].[Districts]
    ([ProvinceId]);
GO

-- Creating foreign key on [DistrictId] in table 'Wards'
ALTER TABLE [dbo].[Wards]
ADD CONSTRAINT [FK_Ward_District]
    FOREIGN KEY ([DistrictId])
    REFERENCES [dbo].[Districts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Ward_District'
CREATE INDEX [IX_FK_Ward_District]
ON [dbo].[Wards]
    ([DistrictId]);
GO

-- Creating foreign key on [ImportUnitId] in table 'Imports'
ALTER TABLE [dbo].[Imports]
ADD CONSTRAINT [FK_Import_ImportUnit]
    FOREIGN KEY ([ImportUnitId])
    REFERENCES [dbo].[ImportUnits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Import_ImportUnit'
CREATE INDEX [IX_FK_Import_ImportUnit]
ON [dbo].[Imports]
    ([ImportUnitId]);
GO

-- Creating foreign key on [UserId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Order_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_User'
CREATE INDEX [IX_FK_Order_User]
ON [dbo].[Orders]
    ([UserId]);
GO

-- Creating foreign key on [OrderId] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK_OrderDetail_Order]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderDetail_Order'
CREATE INDEX [IX_FK_OrderDetail_Order]
ON [dbo].[OrderDetails]
    ([OrderId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductImgs'
ALTER TABLE [dbo].[ProductImgs]
ADD CONSTRAINT [FK_ProductImg_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductImg_Product'
CREATE INDEX [IX_FK_ProductImg_Product]
ON [dbo].[ProductImgs]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'Warehouses'
ALTER TABLE [dbo].[Warehouses]
ADD CONSTRAINT [FK_Warehouse_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Warehouse_Product'
CREATE INDEX [IX_FK_Warehouse_Product]
ON [dbo].[Warehouses]
    ([ProductId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------