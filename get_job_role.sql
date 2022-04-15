alter procedure get_job_role(@email varchar(50))
as
begin
begin try
	if not exists(select * from credential where email=@email)
		return 0
	else
	begin
		declare @job numeric(2)
		select @job=job_role from credential where email=@email
		return @job
	end
end try
begin catch
	return -1
end catch

end

insert into credential values('st@gmail.com','SB',74536,2)
select * from credential


declare @ret numeric(2)
exec @ret=get_job_role 'st@gmail.com'
select @ret

select * from active_patient