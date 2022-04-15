-- >0 succesfully get sum of bill
-- 0 bed_no dont exist in bill table
-- -1 exceptions


create procedure get_bill(@bed_no varchar(20))
as
begin
	begin try
		if not exists(select * from bill where bed_number=@bed_no)
			return 0
		declare @sum numeric(9)
		select @sum=sum(amount) from bill where bed_number=@bed_no
		return @sum
	end try	

	begin catch
		return -1
	end catch
end

declare @ret_value numeric(10)
exec @ret_value=get_bill 'G102'
select @ret_value