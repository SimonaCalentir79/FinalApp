create or alter procedure spGetAllUsers
as begin
	select * from UserAccount u;
end

create or alter procedure spAddUserAccounts
(
	@FirstName varchar(200),
	@LastName varchar(200),
	@Email varchar(200),
	@Username varchar(200),
	@Password varchar(200),
	@ConfirmPassword varchar(200)
)
as begin
	insert into UserAccount(FirstName, LastName, Email, Username, Password, ConfirmPassword) 
	values (@FirstName, @LastName, @Email, @Username, @Password, @ConfirmPassword)
end