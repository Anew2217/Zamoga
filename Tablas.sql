Create Table Usuario(
	Id int Identity primary key,
	Usuario varchar(255) unique,
	Rol varchar(20),
	Clave varchar(255)
)

insert into Usuario values('Assistant', 'Assistant', '19-51-3F-DC-9D-A4-FB-72-A4-A0-5E-B6-69-17-54-8D-3C-90-FF-94-D5-41-9E-1F-23-63-EE-A8-9D-FE-E1-DD') --Password1
insert into Usuario values('Manager', 'Manager', '19-51-3F-DC-9D-A4-FB-72-A4-A0-5E-B6-69-17-54-8D-3C-90-FF-94-D5-41-9E-1F-23-63-EE-A8-9D-FE-E1-DD') --Password1
insert into Usuario values('Superintendent', 'Superintendent', '19-51-3F-DC-9D-A4-FB-72-A4-A0-5E-B6-69-17-54-8D-3C-90-FF-94-D5-41-9E-1F-23-63-EE-A8-9D-FE-E1-DD') --Password1
insert into Usuario values('Administrator', 'Administrator', '19-51-3F-DC-9D-A4-FB-72-A4-A0-5E-B6-69-17-54-8D-3C-90-FF-94-D5-41-9E-1F-23-63-EE-A8-9D-FE-E1-DD') --Password1

Create Table Transaccion(
	Id int Identity primary key,
	NombreDest varchar(255),	
	Fecha Date,
	IsFraud bit
)

