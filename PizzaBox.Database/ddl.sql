-- data definition language

use PizzaStoreDb;
go

create schema Pizza; -- namespace
go

-- CREATE 

create table Pizza.Crust
(
    CrustId int identity (1,1) not null,
    [Name] nvarchar(100) not null,
    Active bit not null,
    constraint PK_Crust primary key (CrustId)
);

create table Pizza.Size
(
    SizeId int identity (1,1) not null,
    [Name] nvarchar(100) not null,
    Active bit not null,
    constraint PK_Size primary key (SizeId)
);

create table Pizza.Topping
(
    ToppingId int identity (1,1) not null,
    [Name] nvarchar(100) not null,
    Active bit not null,
    constraint PK_Topping primary key (ToppingId)
);

create table Pizza.Pizza
(
    PizzaId int identity (1,1) not null,
    CrustId int not null,
    SizeId int not null,
    [Name] nvarchar(250) not null,  
    DateModified datetime2(0) not null,
    Active bit not null,
    constraint PK_Pizza primary key (PizzaId), 
    constraint FK_Crust foreign key (CrustId) references Pizza.Crust(CrustId),
    constraint FK_Size foreign key (SizeId) references Pizza.Size(SizeId)
);

create table Pizza.PizzaTopping
(
    PizzaToppingId int identity (1,1) not null,
    PizzaId int not null,
    ToppingId int not null,
    Active bit not null,
    constraint PK_PizzaTopping primary key (PizzaToppingId),
    constraint FK_Topping foreign key (ToppingId) references Pizza.Topping(ToppingId),
    constraint FK_PizzaToppping foreign key (PizzaId) references Pizza.Pizza(PizzaId)

);
go

-- END CREATE

-- ALTER

-- END ALTER

-- DROP

drop table Pizza.Pizza; -- tables are typically archived rather than dropped
drop table Pizza.Crust;
drop table Pizza.Size;
drop table Pizza.Toppings;
drop table Pizza.PizzaTopping;
-- drop schema Pizza; -- schema are typically archived rather than dropped
-- drop database PizzaStoreDb; -- occurs in development

-- END DROP

-- TRUNCATE
    
-- truncate table Pizza.Crust;
-- truncate table Pizza.Toppings;

-- END TRUNCATE