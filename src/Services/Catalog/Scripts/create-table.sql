create table products (
	Id serial primary key,
	Title varchar(100) not null,
	Description text,
	Quantity INT not null,
	Price numeric not null
);