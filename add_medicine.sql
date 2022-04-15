alter procedure add_medicine(@bed_no varchar(20),@new_medicine_name varchar(50),@quantity numeric(3))
as
begin
begin try
	if exists(select * from active_patient where bed_number=@bed_no)	
	begin
		if not exists(select * from medicine where medicine_name=@new_medicine_name and quantity>=@quantity)
			return 2
		declare @med_name varchar(200)
		declare @med_cost numeric(8)
		declare @qty numeric(8)
		select @med_name=medicine_name from active_patient where bed_number=@bed_no
		if @med_name is null
		begin
			update active_patient set medicine_name=@new_medicine_name where bed_number=@bed_no
			
			select @med_cost=cost,@qty=quantity from medicine where medicine_name=@new_medicine_name
			set @med_cost*=@quantity
		    insert into income values('MEDICINE',@med_cost,GETDATE())
			update active_patient set medicine_cost=@med_cost where bed_number=@bed_no
			
			set @qty-=@quantity
			update medicine set quantity=@qty where medicine_name=@new_medicine_name
			return 1
		
		end
		
		else
		begin
			set @med_name+=', '+@new_medicine_name
			update active_patient set medicine_name=@med_name where bed_number=@bed_no
			declare @prev_med_cost numeric(8)
			select @prev_med_cost=medicine_cost from active_patient where bed_number=@bed_no

			select @med_cost=cost,@qty=quantity from medicine where medicine_name=@new_medicine_name
			set @med_cost*=@quantity
			insert into income values('MEDICINE',@med_cost,GETDATE())
			set @prev_med_cost+=@med_cost
			update active_patient set medicine_cost=@prev_med_cost where bed_number=@bed_no
			
			set @qty-=@quantity
			update medicine set quantity=@qty where medicine_name=@new_medicine_name
			return 1
		end
	end

	else
		return 0
end try
begin catch
	return -1
end catch
end

declare @m_name varchar(20)
exec @m_name=add_medicine 'G103','zomato',3
select @m_name

select * from active_patient
delete from active_patient where bed_number='G103'

select * from income
update active_patient set medicine_cost=100 where bed_number='G102'
select * from medicine
insert into medicine values('zomato',70,'2020/03/3',30)