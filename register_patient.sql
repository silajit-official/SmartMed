alter procedure register_patient(@bed_no varchar(20),@name varchar(50),@description varchar(200),@arrival_date date,@discharge_date date,@bill numeric(10),@medicine_name varchar(60),@phone_no numeric(12),@medicine_cost numeric(8),@doctor_id bigint)
as
begin
begin try

	declare @ret_value int
	exec @ret_value=check_bed @bed_no
	if @ret_value=0
	begin
		insert into active_patient values(@bed_no,@name,@description,@arrival_date,@discharge_date,@bill,@medicine_name,@phone_no,@medicine_cost,@doctor_id)
		return 1
	end
	else
	return 0
end try
begin catch
	return 0
end catch

end

declare @val int
exec @val=register_patient 'G103','Rohan karmakar','PetKharap','2019-02-15','2019-05-26',200000,null,89658458,null,1
select @val

select * from active_patient