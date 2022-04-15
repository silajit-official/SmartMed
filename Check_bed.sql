create procedure check_bed(@bed_no varchar(20))
as
begin
begin try
if exists(select * from active_patient where bed_number=@bed_no)
	return 1
else
	return 0
end try

begin catch
return 0
end catch
end

declare @temp varchar(20)
exec @temp=check_bed 'G102'
select @temp