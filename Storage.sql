create table Shipper
(ID_Shipper integer not null constraint PK_ID_Shipper primary key identity(1,1),
Name_Shipper varchar(100) not null,
Address_Shipper varchar(100) not null,
Phone_Shipper varchar(100) not null
);

create table Client
(ID_Client integer not null constraint PK_ID_Client primary key identity(1,1),
Login varchar(100) not null,
Password varchar(100) not null,
Name_Client varchar(100) not null,
Address_Client varchar(100) not null,
Phone_Client varchar(100) not null
);

create table Storage
(ID_Storage integer not null constraint PK_ID_Storage primary key identity(1,1),
Name_Storage varchar(100) not null,
Maker_Storage varchar(100) not null,
Type_Storage varchar(100) not null,
Price_Storage numeric(10,2) not null,
Amount_Storage varchar(100) not null
);

create table Buy
(
ID_Buy integer not null constraint PK_ID_Buy primary key identity(1,1),
ID_Storage integer not null constraint FK_ID_Storage_Buy foreign key (ID_Storage) references Storage(ID_Storage) on update cascade on delete cascade,
ID_Shipper integer not null constraint FK_ID_Shipper_Buy foreign key (ID_Shipper) references Shipper(ID_Shipper) on update cascade on delete cascade,
Name_Buy varchar(100) not null,
Maker_Buy varchar(100) not null,
Type_Buy varchar(100) not null,
Price_Buy numeric(10,2) not null,
Amount_Buy varchar(100) not null,
Data_Buy date not null
);

create table Sell
(ID_Sell integer not null constraint PK_ID_Sell primary key identity(1,1),
ID_Storage integer not null constraint FK_ID_Storage_Sell foreign key (ID_Storage) references Storage(ID_Storage) on update cascade on delete cascade,
ID_Client integer not null constraint FK_ID_Client_Sell foreign key (ID_Client) references Client(ID_Client) on update cascade on delete cascade,
Name_Sell varchar(100) not null,
Maker_Sell varchar(100) not null,
Type_Sell varchar(100) not null,
Price_Sell numeric(10,2) not null,
Amount_Sell varchar(100) not null,
Data_Sell date not null
);

