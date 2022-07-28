use master 
go
alter database STP set single_user with rollback immediate
drop database STP

Create database STP
go
create table STP.dbo.Manager(
id_manager int identity(1,1) primary key,
name_manager varchar(50) not null)
go
insert into STP.dbo.Manager(name_manager)
values('manager1')
go
insert into STP.dbo.Manager(name_manager)
values('manager2')
go
create table STP.dbo.ProductType(
id_productType int identity(1,1) primary key,
name_productType varchar(30) not null)
go
insert into STP.dbo.ProductType(name_productType)
values('подписка')
go
insert into STP.dbo.ProductType(name_productType)
values('постоянная лицензия')
go
create table STP.dbo.Product(
id_product int identity(1,1) primary key,
name_product varchar(100) not null,
price_product money not null,
type_product int foreign key references STP.dbo.ProductType(id_productType) on delete cascade,
sub_expiring_product Date)
go
insert into STP.dbo.Product(name_product, price_product,type_product,sub_expiring_product)
values('Товар1', 100.00, 1, '2023-12-01')
go
insert into STP.dbo.Product(name_product, price_product,type_product,sub_expiring_product)
values('Товар2', 200.00, 2, '1900-01-01') 
go
create table STP.dbo.ClientStatus(
id_clientStatus int identity(1,1) primary key,
name_clientStatus varchar(30) not null)
go
insert into STP.dbo.ClientStatus(name_clientStatus)
values('Ключевой клиент')
go
insert into STP.dbo.ClientStatus(name_clientStatus)
values('Обычный клиент')
go
create table STP.dbo.Client(
id_client int identity(1,1) primary key,
name_client varchar(50) not null,
status_client int foreign key references STP.dbo.ClientStatus(id_clientStatus) on delete cascade not null,
manager_client int foreign key references STP.dbo.Manager(id_manager) on delete cascade)
go
insert into STP.dbo.Client(name_client, status_client, manager_client)
values('Клиент1', 1, 1)
go
insert into STP.dbo.Client(name_client, status_client, manager_client)
values('Клиент2', 2, 2)
go
insert into STP.dbo.Client(name_client, status_client, manager_client)
values('Клиент3', 1, 2)
go
create table STP.dbo.ClientProducts(
id_clientProducts int identity(1,1) primary key,
id_client int foreign key references STP.dbo.Client(id_client) on delete cascade,
id_product int foreign key references STP.dbo.Product(id_product) on delete cascade)
go
insert into STP.dbo.ClientProducts(id_client, id_product)
values(1, 1)
go
insert into STP.dbo.ClientProducts(id_client, id_product)
values(1, 2)
go
insert into STP.dbo.ClientProducts(id_client, id_product)
values(2, 1)
go
insert into STP.dbo.ClientProducts(id_client, id_product)
values(2, 2)
go
use STP
go
Create view ProductView as
select 
STP.dbo.Product.name_product as 'Name', 
STP.dbo.Product.price_product as 'Price',
STP.dbo.ProductType.name_productType as 'Type',
STP.dbo.Product.sub_expiring_product as 'Expiring date'
from STP.dbo.Product,STP.dbo.ProductType
where  STP.dbo.Product.type_product = STP.dbo.ProductType.id_productType
go
Create view ClientView as
select
STP.dbo.Client.name_client as 'Name',
STP.dbo.ClientStatus.name_clientStatus as 'Status',
STP.dbo.Manager.name_manager as 'Manager'
from STP.dbo.Client, STP.dbo.Manager, STP.dbo.ClientStatus
where STP.dbo.Client.manager_client = STP.dbo.Manager.id_manager and STP.dbo.Client.status_client = STP.dbo.ClientStatus.id_clientStatus
go
Create view BoughtProductsView as
SELECT STP.dbo.Client.name_client as 'Client',
       STUFF((SELECT ','+ STP.dbo.Product.name_product
               FROM STP.dbo.Product
               JOIN STP.dbo.ClientProducts ON STP.dbo.ClientProducts.id_product = STP.dbo.Product.id_product
              WHERE STP.dbo.ClientProducts.id_client = STP.dbo.Client.id_client
           GROUP BY STP.dbo.Product.name_product
            FOR XML PATH(''), TYPE).value('.','VARCHAR(max)'), 1, 1, '') as 'Products'
FROM STP.dbo.Client
go
Create view ManagerClientsView as
SELECT STP.dbo.Manager.name_manager as 'Manager',
       STUFF((SELECT ','+ STP.dbo.Client.name_client
               FROM STP.dbo.Client
              WHERE STP.dbo.Manager.id_manager = STP.dbo.Client.manager_client
           GROUP BY STP.dbo.Client.name_client
            FOR XML PATH(''), TYPE).value('.','VARCHAR(max)'), 1, 1, '') as 'Clients'
FROM STP.dbo.Manager
go
Create view StatusClientsView as
SELECT STP.dbo.ClientStatus.name_clientStatus as 'Status',
       STUFF((SELECT ','+ STP.dbo.Client.name_client
               FROM STP.dbo.Client
              WHERE STP.dbo.ClientStatus.id_clientStatus = STP.dbo.Client.status_client
           GROUP BY STP.dbo.Client.name_client
            FOR XML PATH(''), TYPE).value('.','VARCHAR(max)'), 1, 1, '') as 'Clients'
FROM STP.dbo.ClientStatus