
--1 for success full insertion in bill table
--0 from not having bed_no in active_patient table
-- -1 from any exception

alter procedure add_bill(@bed_no varchar(20),@money numeric(8),@reason varchar(50))
as
begin
begin try
	if not exists(select * from active_patient where bed_number=@bed_no)
		return 0
	insert into bill values(@bed_no,@money,@reason,GETDATE())
	declare @ret_value numeric(10)
	exec @ret_value=get_bill @bed_no
	update active_patient set bill=@ret_value where bed_number=@bed_no
		return 1
end try
begin catch
	return -1
end catch
end

declare @ret_value numeric(2)
exec @ret_value=add_bill 'G102',100000,'Star'
select @ret_value

select * from bill
select * from active_patient
