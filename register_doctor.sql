create procedure add_doctor(@doc_name varchar(50),@certified_in varchar(100),@phone_no numeric(12))
as
begin
begin try
	insert into doctor values(@doc_name,@certified_in,@phone_no)
	return 1
end try
begin catch
	return -1
end catch
end

declare @ret_val numeric(2)
exec @ret_val=add_doctor 'Pradhan','MBBS in Calcullat University,cancer,Diabtes',9875452569
select @ret_val

select * from doctor