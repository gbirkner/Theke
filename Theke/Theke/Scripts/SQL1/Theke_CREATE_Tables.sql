--Database Create Script for Th[e]ke
USE Theke;

IF Object_id('theke.DeliverySlip','U') is not Null drop table theke.DeliverySlip;
IF Object_id('theke.Storage','U') is not Null drop table theke.Storage;
IF Object_id('theke.Supplier','U') is not Null drop table theke.Supplier;
IF Object_id('theke.ZipCode','U') is not Null drop table theke.ZipCode;
IF Object_id('theke.Reservation','U') is not Null drop table theke.Reservation;
IF Object_id('theke.BarOrderBarTable','U') is not Null drop table theke.BarOrderBarTable;
IF Object_id('theke.BarOrder','U') is not Null drop table theke.BarOrder;
IF Object_id('theke.BarTable','U') is not Null drop table theke.BarTable;
IF Object_id('theke.Waiter','U') is not Null drop table theke.Waiter;
IF Object_id('theke.OrderPosition','U') is not Null drop table theke.OrderPosition;
IF Object_id('theke.PriceHistory','U') is not Null drop table theke.PriceHistory;
IF Object_id('theke.Product','U') is not Null drop table theke.Product;
IF Object_id('theke.Category','U') is not Null drop table theke.Category;
IF Object_id('theke.ProductUnit','U') is not Null drop table theke.ProductUnit;
IF Object_id('theke.AgeRating','U') is not Null drop table theke.AgeRating;
IF Object_id('theke.NutriantContent','U') is not Null drop table theke.NutriantContent;
IF Object_id('theke.Producer','U') is not Null drop table theke.Producer;



CREATE TABLE [theke].[Producer] (
	ProducerID 	int 			NOT NULL Identity(0,1),
	Name 		nvarchar(250)	NOT NULL,

	CONSTRAINT pk_manufacturerID PRIMARY KEY(ProducerID),
);

CREATE TABLE [theke].[NutriantContent] (
	NutrinantContentID 	int 	NOT NULL Identity(0,1),
	Energy 				float	NULL,
	Fat 				float	NULL,
	SutartedFat 		float	NULL,
	Carbohydrate 		float	NULL,
	Sugar 				float	NULL,
	Albumen				float	NULL,
	Salt 				float	NULL,

	CONSTRAINT pk_nutrinantContentID PRIMARY KEY (nutrinantContentID),
);

CREATE TABLE [theke].[AgeRating] (
	AgeRatingID		int NOT NULL Identity(0,1),
	Age				int	NOT NULL,
	
	CONSTRAINT pk_AgeRating PRIMARY KEY (AgeRatingID),
);

CREATE TABLE [theke].[ProductUnit] (
	ProductUnitID		int 			NOT NULL Identity(0,1),
	Name				nvarchar(250) 	NOT NULL,
	SName				nvarchar(5) 	NOT NULL,
	Volume				int				NOT NULL,
	LitreAmount			float			NOT NULL,
	
	CONSTRAINT pk_ProductUnit PRIMARY KEY (ProductUnitID),
);

CREATE TABLE [theke].[Category] (
	CategoryID 	int 			NOT NULL Identity(0,1),
	Name 		varchar(250) 	NOT NULL,
	SName 		varchar(250) 	NOT NULL,

	CONSTRAINT categoryID PRIMARY KEY(categoryID),
);

Create Table [theke].[Product] (
	ProductID 			int 			NOT NULL Identity(0,1),
	IsActive 			tinyint		NULL,
	Name 				nvarchar(250) 	NOT NULL,
	Note 				nvarchar(250)	NULL,
	AgeRatingID			int 			NOT NULL,
	ProductUnitID		int				NOT NULL,
	ProducerID 			int				NOT NULL,
	AlcoholAmount 		int 			NOT NULL,
	NutriantContentID 	int 			NOT NULL,
	EanNumber 			int				NULL,
	Deposit 			int 			NOT NULL,
	ItemAmount 			int 			NOT NULL,
	CategorieID 		int 			NOT NULL,
	MinPrice 			float 			NOT NULL,
	MaxPricce 			float 			NOT NULL,
	AveragePurchasePrice int			NULL,
	CreatedByID 		nvarchar(128)	NOT NULL,
	ModifiedByID 		nvarchar(128)	NOT NULL,
	CreatedDate 		datetime 		NOT NULL Default GETDate(),
	ModfiedDate 		datetime 		NOT NULL Default GETDate(),
		
	CONSTRAINT pk_Product PRIMARY KEY(ProductID),
	
	CONSTRAINT fk_Product_AgeRating FOREIGN KEY(AgeRatingID) REFERENCES theke.AgeRating(AgeRatingID),
	CONSTRAINT fk_Product_ProductUnit FOREIGN KEY(ProductUnitID) REFERENCES theke.ProductUnit(ProductUnitID),
	CONSTRAINT fk_Product_Producer FOREIGN KEY(ProducerID) REFERENCES theke.Producer(ProducerID),
	CONSTRAINT fk_Product_NutriantContent FOREIGN KEY(NutriantContentID) REFERENCES theke.NutriantContent(NutrinantContentID),
	CONSTRAINT fk_Product_Category FOREIGN KEY(CategorieID) REFERENCES theke.Category(CategoryID),
	CONSTRAINT fk_Product_AspNetUsers_CreatedBy FOREIGN KEY (CreatedByID) REFERENCES dbo.AspNetUsers(Id),
	CONSTRAINT fk_Product_AspNetUsers_ModifiedBy FOREIGN KEY (ModifiedByID) REFERENCES dbo.AspNetUsers(Id),
	
);


CREATE TABLE [theke].[PriceHistory] (
	PriceHistoryID 	int 		NOT NULL Identity(0,1),
	ProductID 		int 		NOT NULL,
	CreatedDate 	datetime 	NOT NULL,
	Price 			float 		NOT NULL Default 0,

	CONSTRAINT pk_PriceHistory PRIMARY KEY (PriceHistoryID),

	CONSTRAINT fk_PriceHistoryProduct FOREIGN KEY (ProductID) REFERENCES theke.Product(ProductID)
);


CREATE TABLE [theke].[OrderPosition] (
	OrderPositionID	int		NOT NULL Identity(0,1),
	PriceHistoryID		int		NOT NULL,
	Amount				int		NOT NULL,
	
	CONSTRAINT pk_OrderPosition PRIMARY KEY (OrderPositionID),
	
	CONSTRAINT fk_OrderPosition_PriceHistory FOREIGN KEY (PriceHistoryID) REFERENCES theke.PriceHistory(PriceHistoryID),
	
);


CREATE TABLE [theke].[Waiter] (
	WaiterID	int		NOT NULL Identity(0,1),
	VName		nvarchar(150) NOT NULL,
	LName		nvarchar(150)	NOT NULL,
	Nicname		nvarchar(20)	NOT NULL,
	UserID		nvarchar(128)	NOT NULL,
	
	CONSTRAINT pk_Waiter PRIMARY KEY (WaiterID),
	
	CONSTRAINT fk_Waiter_AspNetUsers FOREIGN KEY (UserID) REFERENCES dbo.AspNetUsers(Id),
);




CREATE TABLE [theke].[BarTable] (
	BarTableID		int		NOT NULL Identity(1,1),
	PositionX		int 	NULL,
	PositionY		int		NULL,
	Width			int		NULL,
	Height			int		NULL,
	SeatAmount		int		NULL,
	TableName		nvarchar(150)	NULL,
	
	CONSTRAINT pk_BarTable	PRIMARY KEY (BarTableID),
);


CREATE TABLE [theke].[BarOrder] (
	BarOrderID				int			NOT NULL Identity(0,1),
	PaymentStatus		tinyint 	NOT NULL,
	BarOrderBarTableID		int			NOT NULL,
	Datetime			datetime	NOT NULL,
	PoitionID			int			NOT NULL,
	WaiterID			int			NOT NULL,
	
	CONSTRAINT pk_BarOrder PRIMARY KEY (BarOrderID),
	
	CONSTRAINT fk_BarOrder_Waiter FOREIGN KEY (WaiterID) REFERENCES theke.Waiter(WaiterID),
	
	
);


CREATE TABLE [theke].[BarOrderBarTable] (
	BarOrderID		int NOT NULL,
	BarTableID	int NOT NULL,
	
	CONSTRAINT pk_BarOrderBarTable PRIMARY KEY (BarOrderID, BarTableID),
	CONSTRAINT fk_BarOrderBarTable_BarOrder FOREIGN KEY (BarOrderID) REFERENCES theke.BarOrder(BarOrderID),
	CONSTRAINT fk_BarOrderBarTable_BarTable FOREIGN KEY (BarTableID) REFERENCES theke.BarTable(BarTableID),
);



CREATE TABLE [theke].[Reservation] (
	ReservationID	int 			NOT NULL Identity(0,1),
	Date			datetime		NOT NULL,
	FName			nvarchar(250) 	NULL,
	LName			nvarchar(250) 	NOT NULL,
	PersonAmount	int				NOT NULL,
	BarTableID		int 			NOT NULL,
	
	CONSTRAINT pk_Reservation PRIMARY KEY (ReservationID),
	
	CONSTRAINT fk_Reservation_BarTable FOREIGN KEY (BarTableID) REFERENCES theke.BarTable(BarTableID),
);


CREATE TABLE [theke].[ZipCode] (
	ZipCodeID 		int 			NOT NULL,
	ZipCode 		int 			NOT NULL,
	City 			nvarchar(250) 	NOT NULL,
	Country 		nvarchar(250) 	NOT NULL,
	
	CONSTRAINT pk_ZipCodeID PRIMARY KEY (ZipCodeID),

);


CREATE TABLE [theke].[Supplier] (
	SupplierID 		int 			NOT NULL,
	CompanyName 	nvarchar(250) 	NOT NULL,
	StreetName 		nvarchar(250) 	NOT NULL,
	StreetNumber 	int 			NOT NULL,
	ZipCodeID 		int 			NOT NULL,
	OwnCustomerID 	nvarchar(250) 	NOT NULL,
	
	CONSTRAINT pk_SupplierID PRIMARY KEY (SupplierID),
	
	CONSTRAINT fk_ZipCodeID FOREIGN KEY (ZipCodeID) REFERENCES theke.ZipCode(ZipCodeID),
);


CREATE TABLE [theke].[Storage] (
	StorageID		int 		NOT NULL Identity(0,1),
	ProductID		int 		NOT NULL,
	Amount			int 		NOT NULL,
	ExpirationDate	datetime 	NOT NULL,
	
	CONSTRAINT pk_Storage PRIMARY KEY (StorageID),
	
	CONSTRAINT fk_Storage_Product FOREIGN KEY (ProductID) REFERENCES theke.Product(ProductID),
);

CREATE TABLE [theke].[DeliverySlip] (
	DeliverySlipID 		int 			NOT NULL,
	SupplierID 			int 			NOT NULL,
	DeliverySlipNumber 	nvarchar(250) 	NOT NULL,
	BillID 				int 			NOT NULL,
	StorageID			int 			NOT NULL,
	
	CONSTRAINT pk_DeliverySlipID PRIMARY KEY (DeliverySlipID),
	
	CONSTRAINT fk_DeliverySlip_Supplier FOREIGN KEY (SupplierID) REFERENCES theke.Supplier(SupplierID),
	CONSTRAINT fk_DeliverySlip_Storage FOREIGN KEY (StorageID) REFERENCES theke.Storage(StorageID),
);


if Object_id('theke.InvoicePosition','U') is not Null drop table theke.InvoicePosition;
if Object_id('theke.Invoice','U') is not Null drop table theke.Invoice;
if Object_id('theke.InvoiceAddress','U') is not Null drop table theke.InvoiceAddress;

create table [theke].[InvoiceAddress] (
	InvoiceAddressID int not null identity,
	Titel nvarchar(250) not null,
	Street nvarchar(250) null,
	Zipcode int null,
	City nvarchar(250),
	Country nvarchar(250),
	Email nvarchar(250),

	constraint pk_InvoiceAddress primary key (InvoiceAddressID)
)

create table [theke].[Invoice](
	InvoiceID int not null identity(100,100),
	InvoiceDate	Datetime not null,
	InvoiceAddressID int null,	
	Storno tinyint null,

	constraint pk_Invoice Primary Key (invoiceID),

	constraint fk_InvoiceInvoiceAddressID foreign key (InvoiceAddressID) references theke.InvoiceAddress(InvoiceAddressID)
)

create table [theke].[InvoicePosition] (
	InvoiceID int not null,
	PositionID int not NUll,
	ProductName nvarchar(250) not null,
	Price float not NUll default(0),
	Amount int not NUll,

	constraint pk_InvoicePosition primary key (InvoiceID, PositionID),

	constraint fk_InvoicePositionInvoiceID foreign key (InvoiceID) references theke.Invoice(InvoiceID)
)

