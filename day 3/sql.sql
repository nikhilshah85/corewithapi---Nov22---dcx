create database shoppingDB

create table ProductDetails
(
	pId int primary key,
	pName varchar(20),
	pCategory varchar(20),
	pPrice int,
	pIsInStock bit
	)

	insert into ProductDetails values(101,'Pepsi','Cold-Drink',50,1)
	insert into ProductDetails values(102,'Iphone','Electronics',50,1)
	insert into ProductDetails values(103,'Coke','Cold-Drink',50,1)
	insert into ProductDetails values(104,'Maggie','Fast-Food',50,0)
	insert into ProductDetails values(105,'Pasta','Fast-Food',50,1)
	insert into ProductDetails values(106,'Boat','Electronics',50,1)
	insert into ProductDetails values(107,'Air-Pods','Electronics',50,0)


	select * from productdetails

	delete from productdetails where pid =0



