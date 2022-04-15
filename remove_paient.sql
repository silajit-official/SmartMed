--1 from succesfull insert into non active and delete from active and bill table
--0 from not having bed_no in active
-- -1 from exception


alter procedure remove_patient(@UID varchar(15),@bed_no varchar(20))
as
begin
begin try
	declare @name varchar(50),@description varchar(200),@arrival_date date,@discharge_date date,@medicine_name varchar(200),@doctor_id bigint
	if not exists(select * from active_patient where bed_number=@bed_no)
		return 0
	select @name=name,@description=description,@arrival_date=Date_of_arrival,@discharge_date=expected_date_of_discharge,@medicine_name=medicine_name,@doctor_id=doctorId from active_patient where bed_number=@bed_no
	insert into non_active_patient values(@UID,@name,@description,@arrival_date,@discharge_date,@medicine_name,@doctor_id)

	delete from active_patient where bed_number=@bed_no
	delete from bill where bed_number=@bed_no
	return 1
end try
begin catch
	return -1
end catch
end


declare @ret_value numeric(2)
exec @ret_value=remove_patient '123456','G101'
select @ret_value

select * from non_active_patient
select * from active_patient