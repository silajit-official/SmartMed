create table active_patient(Sno bigint identity(1,1) primary key,bed_number varchar(20),[name] varchar(30),description varchar(200),Date_of_arrival date,expected_date_of_discharge date,bill numeric(9),medicine_name varchar(60),phone_no numeric(12),medicine_cost numeric(8),doctorId bigint references doctor(doctor_id))

insert into active_patient values('G101','silajit','asa','10/2/19',getdate(),2000,'Metrogyl',123654,100,1)
select * from active_patient
select * from doctor

--delete from active_patient where sno=3
--insert into doctor values('asas','chest',456987)
--select * from doctor


create table non_active_patient(unique_id varchar(15) primary key,[name] varchar(30),description varchar(300),Date_of_arrival date,expected_date_of_discharge date,medicine_name varchar(60),doctorId bigint references doctor(doctor_id))


create table expense(sno bigint identity(1,1) primary key,field varchar(50),expense numeric(10),dates date)

create table income(sno bigint identity(1,1) primary key,field varchar(50),income numeric(10),dates date)

create table medicine(medicine_name varchar(60) primary key,quantity numeric(8),[expiry_date] date,cost numeric(8))

create table doctor(doctor_id bigint identity(1,1) primary key,doctor_name varchar(20),certified_in varchar(200),phone_no numeric(12))

create table bill(sno bigint identity(1,1) primary key,bed_number varchar(20),amount numeric(8),reason varchar(50),dates date)

create table [credential](email varchar(50) primary key,[name] varchar(50),phone_number numeric(12),Job_Role numeric(2))
insert into doctor values('Zoe','Cardio',9830705655)