create procedure update_patient(@bed_no varchar(20),@new_description varchar(100),@new_discharge_date date,@new_phone_no numeric(12),@new_doctorid bigint)
as
begin
begin try
	if not exists(select * from active_patient where bed_number=@bed_no)
		return 0
	declare @old_description varchar(300)
	select @old_description=description from active_patient where bed_number=@bed_no
	set @old_description+=', '+@new_description
	update active_patient set description=@old_description,expected_date_of_discharge=@new_discharge_date,phone_no=@new_phone_no,doctorId=@new_doctorid where bed_number=@bed_no
	return 1
end try


begin catch
	return -1
end catch
end

select * from active_patient

declare @ret_value numeric(10)
exec @ret_value=update_patient 'G103','Bichi Karap','2020-03-31',9331331379,1
select @ret_value