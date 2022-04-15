create procedure add_medicine_quantity(@new_med_name varchar(50),@cost numeric(5),@new_med_quantity numeric(4),@percent numeric(3),@exp_date date)
as
begin
begin try

	if exists(select * from medicine where medicine_name=@new_med_name)
	begin
		declare @old_med_quantity numeric(5),@temp numeric(6)
		select @old_med_quantity=quantity from medicine where medicine_name=@new_med_name
		set @old_med_quantity+=@new_med_quantity
		update medicine set quantity=@old_med_quantity,cost=@cost,expiry_date=@exp_date where medicine_name=@new_med_name
		set @temp=@cost*@new_med_quantity
		set @temp-=(@percent/100)*@temp
		insert into expense values('MEDICINE',@temp,getdate())
		return 1
	end
	
	else
	begin
		insert into medicine values(@new_med_name,@new_med_quantity,@exp_date,@cost)
		declare @temp1 numeric(5)
		set @temp1=@cost*@new_med_quantity
		set @temp1-=(@percent/100)*@temp1
		insert into expense values('MEDICINE',@temp1,getdate())
		return 1
	end
end try
begin catch
	return -1
end catch
end



select * from medicine
select * from expense

declare @ret_val numeric(2)
exec @ret_val=add_medicine_quantity 'uber-eats',400,2,10,'2020-3-4'
select @ret_val









