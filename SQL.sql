create table Ordenes(
idOrden nvarchar(9) not null,
detalle nvarchar(200),
estado int,
tipo int,
primary key (idOrden)
)

create table Interrupciones(
idInte int identity(1,1) not null,
diaIni datetime not null,
horaIni datetime not null,
diaFin datetime ,
horaFin datetime ,
motivoBase nvarchar(200),
motivo nvarchar(300),
idOrden nvarchar(9) not null,
primary key (idInte),
foreign key (idOrden) references Ordenes(idOrden)
)

create table Maestro(
idMaestro int identity(1,1) not null,
codigo nvarchar(40),
valor int,
texto nvarchar(200)
)

insert into Ordenes values ('000000001','detalle1',1,1)
insert into Ordenes values ('000000002','detalle2',2,1)
insert into Ordenes values ('000000003','detalle3',3,2)
insert into Ordenes values ('000000004','detalle4',4,2)
insert into Ordenes values ('000000005','detalle5',1,1)
insert into Ordenes values ('000000006','detalle6',1,1)

insert into Maestro values ('[TIPO]',1,'Armado')
insert into Maestro values ('[TIPO]',2,'Desarme')


insert into Maestro values ('[ESTADO]',1,'Aprobado')
insert into Maestro values ('[ESTADO]',2,'En proceso')
insert into Maestro values ('[ESTADO]',3,'Detenido')
insert into Maestro values ('[ESTADO]',4,'Finalizado')

insert into Maestro values ('[PLANINTERRUPCION]',1,'Por priorizacion')
insert into Maestro values ('[PLANINTERRUPCION]',2,'Falta de base')

insert into Maestro values ('[NOPLANINTERRUPCION]',1,'Inspeccion')
insert into Maestro values ('[NOPLANINTERRUPCION]',2,'Prueba de flexion')

