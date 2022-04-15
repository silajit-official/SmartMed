create procedure add_expense(@field varchar(15),@amount numeric(8))
as
begin
begin try
	insert into expense values(@field,@amount,GETDATE())
	return 1
end try
begin catch
	return 0
end catch
end