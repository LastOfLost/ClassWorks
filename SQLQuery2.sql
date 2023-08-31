USE [master]
GO

CREATE DATABASE [31.08.23_Cw]

use [31.08.23_Cw]
go

drop table if exists Provider
go
create table Provider(
Id int primary key IDENTITY(1,1),
Name nvarchar(max) not null,
);
go

drop table if exists Storage
go
create table Storage(
Id int primary key IDENTITY(1,1),
Name nvarchar(max) not null,
);
go

drop table if exists Product
go
create table Product(
Id int primary key IDENTITY(1,1),
Name nvarchar(max) not null,
Type nvarchar(max) not null,
Count int not null,
Price int not null,
DateOfReceiving date not null,
ProviderId int not null REFERENCES Provider(Id) ON DELETE CASCADE ON UPDATE CASCADE,
StorageId int not null REFERENCES Storage(Id) ON DELETE CASCADE ON UPDATE CASCADE,
);
go


delete from Provider
insert into Provider
values
('Provider 1'),
('Provider 2');
go

delete from Storage
insert into Storage
values
('Storage 1');
go

delete from Product
insert into Product
values
('steel', 'solid', 45, 3, '2023-08-08', (select top 1 Id from Provider where name = 'Provider 1'), (select top 1 Id from Storage where name = 'Storage 1')),
('cloth', 'solid', 22, 10, '2023-08-08', (select top 1 Id from Provider where name = 'Provider 1'), (select top 1 Id from Storage where name = 'Storage 1')),
('glass', 'fragile', 28, 6, '2023-08-08', (select top 1 Id from Provider where name = 'Provider 2'), (select top 1 Id from Storage where name = 'Storage 1')),
('wood', 'solid', 14, 2, '2023-08-08', (select top 1 Id from Provider where name = 'Provider 2'), (select top 1 Id from Storage where name = 'Storage 1'));
go
