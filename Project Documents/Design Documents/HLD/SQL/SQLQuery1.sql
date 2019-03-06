--------------------------------------------Buyer-----------------------------------------------------------------------

			
--------------------------------------------/*Add Buyer*/--------------------------------------------(execute)
alter proc Project1.uspAddBuyer
(
	@UserName varchar(25),
	@FirstName varchar(25),
	@LastName varchar(25),
	@DateOfBirth date,
	@PhoneNumber varchar(10),
	@EmailId varchar(50),
	@Adress varchar(max)
	
	
)
as

	INSERT INTO Project1.Buyer VALUES
	(@UserName,@FirstName,@LastName,@DateOfBirth,@PhoneNumber,@EmailId,@Adress)
return 1


--------------------------------------------/*Get Buyer Id*/---------------------------------------------(execute)
go
alter proc Project1.uspGetBuyerId
(
	@UserName varchar(25)
)
as 
begin 
	select BuyerId from Project1.Buyer where UserName=@UserName
end





--------------------------------------------/*Add Cart*/--------------------------------------------
go
alter proc Project1.uspAddCart
(

@BuyerId int ,
@PropertyId int 
)
as
begin
	insert into Project1.Cart
	values(@BuyerId,@PropertyId )
	
end
--------------------------------------------/*Delete Cart*/--------------------------------------------
go
alter proc Project1.uspDeletecart
(
@PropertyName varchar(30)
)
as
begin
	DELETE FROM Project1.Cart WHERE CartId in(select CartId from Project1.Cart where 
	PropertyId in(select PropertyId from Project1.Property where PropertyName=@PropertyName))
end
--------------------------------------------/*Display Cart*/--------------------------------------------
go
alter proc Project1.uspDisplaycart

as
begin
	SELECT Project1.Cart.PropertyId,PropertyName,PropertyType,Descript,Adress,PriceRange,InitialDeposit,Landmark FROM Project1.Cart join Project1.Property on Project1.Property.PropertyId=Project1.Cart.PropertyId	
	
end

--------------------------------------------/*Add Seller*/--------------------------------------------

go
alter proc Project1.uspAddSeller
(
@UserName varchar(30),
@FirstName varchar(30),
@LastName varchar(30),
@DateofBirth date,
@PhoneNo varchar(30),
@Address varchar(300),
@StateId int,
@CityId int,
@EmailId varchar(50)
)
as
begin
	INSERT INTO Project1.Seller values
	(@UserName,@FirstName,@LastName,@DateofBirth,@PhoneNo,@Address,@StateId,@CityId,@EmailId)
end

--------------------------------------------/*Get State Id*/--------------------------------------------
go
alter proc Project1.uspGetStateId
(
	@StateName varchar(20)
)
as
begin
SELECT StateId FROM Project1.States WHERE StateName= @StateName
end

exec Project1.uspGetStateId 'Karnataka' 

--------------------------------------------/*Get City Id*/--------------------------------------------
go
alter proc Project1.uspGetCityId
(
	@cityName varchar(20)
)
as
begin
SELECT CityId FROM Project1.City WHERE CityName=@cityName
end

exec Project1.uspGetCityId 'Hyderabad' 



--------------------------------------------/*Add image*/--------------------------------------------
go
alter proc Project1.uspAddImage
(

	@propertyId int,
	@img varchar(50)
)
as
 begin
 INSERT INTO Project1.Images VALUES
	(@propertyId,@img)
end

--------------------------------------------/*Display Image*/--------------------------------------------
go
alter proc Project1.uspDisplayImage
(@PropertyId int)
as
begin
	Select ImageId, Image from Project1.Images where PropertyId=@PropertyId
	
end

--------------------------------------------/*Add User*/--------------------------------------------
go
alter proc Project1.uspAddUser
(
@UserName varchar(25),
@Pasword varchar(35),
@UserType varchar(15)  
)
as
begin
	INSERT INTO Project1.Users VALUES
	(@UserName,@Pasword,@UserType)
	
end
exec  Project1.uspAddUser 'Madhavi','hema@1234','Buyer'
--------------------------------------------/*Get User Password*/--------------------------------------------
go
alter PROCEDURE Project1.uspGetPassword
(
	@UserName NVARCHAR(25),
	@UserType  NVARCHAR(15)	
)
as
SELECT Pasword FROM Project1.Users WHERE UserName=@UserName and UserType=@UserType
exec Project1.uspGetPassword 'Hema','Buyer'

--------------------------------------------/*Add Property*/--------------------------------------------

go
--alter proc Project1.uspAddProperty
--(

--@PropertyName varchar(50),
--@PropertyType Varchar(15),

--@Desc varchar(250),
--@Adress varchar(250),
--@PriceRange Money,
--@InitialDeposit Money,
--@LandMark varchar(25),
--@IsActive Bit,
--@SellerId int out
--)
--as
--begin
--	INSERT INTO Project1.Property VALUES
--	(@PropertyName,@PropertyType,@Desc,@Adress,@PriceRange,@InitialDeposit,@LandMark,@IsActive,@SellerId)

--end



alter proc Project1.uspAddProperty
(

@PropertyName varchar(50),
@PropertyType Varchar(15),

@Desc varchar(250),
@Adress varchar(250),
@PriceRange Money,
@InitialDeposit Money,
@LandMark varchar(25),
@IsActive Bit,
@SellerId int output
)
as
begin
	insert into Project1.Property
	values(@PropertyName,@PropertyType,@Desc,@Adress,@PriceRange,@InitialDeposit,@LandMark,@IsActive)
	set @SellerId = Scope_Identity()
end

--------------------------------------------/*Get Property By Region*/--------------------------------------------
go
alter PROCEDURE project1.uspGetPropertyByRegion(
@CityName NVARCHAR(30))
AS
BEGIN
	select * from Project1.Property join Project1.City on City.CityName=Property.Adress where Property.Adress=@CityName
END
exec project1.uspGetPropertyByRegion 'Vijay Layout'

												
--------------------------------------------/*Get Property By Owner*/--------------------------------------------
go
alter proc project1.uspGetPropertyByOwner(
@sellerName varchar(20)
)
as
begin
select p.PropertyId,p.PropertyName,p.PropertyType,p.Descript,p.Adress,p.PriceRange,p.InitialDeposit,p.LandMark,p.IsActive,p.SellerId from Project1.Property p inner join Project1.Seller s on p.SellerId=s.SellerId where s.UserName=@sellerName
end

exec project1.uspGetPropertyByOwner 'Hema'

--------------------------------------------/*Edit Property*/--------------------------------------------

go
alter proc Project1.uspEditProperty
(
@PropertyId int ,
@PropertyName varchar(50),
@PropertyType Varchar(15),

@Desc varchar(250),
@Adress varchar(250),
@PriceRange Money,
@InitialDeposit Money,
@LandMark varchar(25),

@SellerId int
)
as
begin
	update Project1.Property
	set PropertyName=@PropertyName,
	PropertyType=@PropertyType,
	
	Descript=@Desc,
	Adress=@Adress,
	PriceRange=@PriceRange,
	InitialDeposit=@InitialDeposit,
	LandMark=@LandMark,
	
	SellerId=@SellerId

	where PropertyId = @Propertyid
end

--------------------------------------------/*Search Property*/--------------------------------------------

go
alter proc Project1.uspSearchProperty
(
@pId int
)
as
begin
	select * from Project1.Property
	where PropertyId = @pId
end

--------------------------------------------/*Get Property Details*/--------------------------------------------

go
alter proc Project1.uspGetProperty
as
begin
	select * from project1.Property
end

--------------------------------------------/*Delete Property*/--------------------------------------------

go
alter proc Project1.uspDeleteProperty
(
@propertyId int
)
as
begin
	delete from project1.Property
	where PropertyId = @propertyid
end

--------------------------------------------/*Display Verified Property*/--------------------------------------------

GO
alter proc Project1.uspDisplayVerifiedProperty
AS
BEGIN
	Select * from project1.Property where IsActive =1
END

--------------------------------------------/*Get Deactivated Property*/--------------------------------------------
go
alter PROCEDURE Project1.uspGetDeactivatedProperty

AS
BEGIN
	Select * from project1.Property where IsActive =0
END

--------------------------------------------/*Deactivate Property*/--------------------------------------------

GO
alter PROCEDURE Project1.uspDeactivateProperty
@PropertyId int

AS
BEGIN
	update project1.Property set IsActive = 0 where PropertyId=@PropertyId
END

-----------------------------------------/*Verify Property*/---------------------------------------------------
go
alter PROCEDURE Project1.uspVerifyProperty
@PropertyId int

AS
BEGIN
	update project1.Property set IsActive =1 where PropertyId=@PropertyId
END


