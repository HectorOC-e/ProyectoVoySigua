
--Elimina la base de datos--
drop database Delivery ;
go


--Se crea la base de datos--
create database Delivery
go


--Se crea el esquema Clientes--
create schema Clientes
go


--Se usa la base de datos--
use Delivery
go


--Tabla de los usuarios--
create table Clientes.Usuarios(
Identidad char(13) primary key not null,
NombreCompleto char(45) not null,
Direccion char(100) not null,
Edad int not null,
Genero varchar(9)
)


--Tabla de Motoristas--
create table Clientes.Motoristas(
NombreMotorista char(45) primary key not null,
EstadoMotorista char(45) not null
)

--Tabla de Tipo de mandado--
create table Clientes.TipoMandado(
TipoMandado char(45) primary key not null
)

--Tabla de mandados--
create table Clientes.Mandados(
idClientes char(13) FOREIGN KEY REFERENCES Clientes.Usuarios(Identidad),
idMotoristas char (45) FOREIGN KEY REFERENCES Clientes.Motoristas(NombreMotorista),
idTipoMandado char(45) FOREIGN KEY REFERENCES Clientes.TipoMandado(TipoMandado),
Precio money,
Recorrido decimal,
HistorialMandados int
)

--Procedimiento que Registra la informacion de un Usuario--
ALTER PROCEDURE InsertarUsuario
@Identidad char(13),
@NombreCompleto char(45),
@Direccion char(100),
@Edad int,
@Genero varchar(9)
AS 
BEGIN 

insert into Clientes.Usuarios(identidad, NombreCompleto, Direccion, Edad, Genero) 
values(@Identidad, @NombreCompleto, @Direccion, @Edad, @Genero);

insert into Clientes.Mandados (idClientes, idMotoristas,idTipoMandado, HistorialMandados, Precio, Recorrido)
values (@Identidad, '--', '--', 0 , 0, 0);

END

exec InsertarUsuario '1208200100571','Hector Eduardo Osorio Castellanos', 'Barrio la tejera  Marala, La Paz', 19, 'Masculino';
exec InsertarUsuario '1503200200112','Samuel Isaac Oviedo Sanchez', 'Siguatepeque, Comayagua' , 18 , 'Masculino';
exec InsertarUsuario '1608200200031','David Mejía', 'Santa Barbara', 19, 'Masculino'


--Procedimiento que Elimina la informacion de un Usuario--
CREATE PROCEDURE EliminarUsuario(@Identidad Char(13))
AS
BEGIN
DELETE FROM Clientes.Mandados where idClientes = @Identidad
END

exec EliminarUsuario '1208200100571'


--Procedimiento que Actualiza la informacion de un Usuario--
CREATE PROCEDURE ActualizarUsuario 
@Identidad char(13),
@NombreCompleto char(45), 
@Edad int, 
@Direccion char(100)
AS 
BEGIN
UPDATE Clientes.Usuarios 
set NombreCompleto = @NombreCompleto, Edad = @Edad, Direccion = @Direccion
where Identidad = @Identidad
END

execute ActualizarUsuario '1208200100571', 'Hector Eduardo Osorio Castellanos', 18, 'Barrio La tejera, Marcala, La paz'

--Procedimiento que Consulta la base de datos--
CREATE PROCEDURE ConsultarBase
AS
BEGIN 
select U.Identidad, U.NombreCompleto, U.Direccion, U.Edad, U.Genero, M.NombreMotorista, M.EstadoMotorista, TP.TipoMandado, HistorialMandados, Precio, Recorrido  from Clientes.Mandados C
inner join Clientes.Usuarios U
on C.idClientes = U.Identidad
inner join Clientes.Motoristas M
on C.idMotoristas = M.NombreMotorista
inner join Clientes.TipoMandado TP
on C.idTipoMandado = TP.TipoMandado
END

exec ConsultarBase

--Procedimiento que busca un usuario--
Create PROCEDURE BuscarUsuario
@identidad char(13)
AS
BEGIN 
select U.Identidad, U.NombreCompleto, U.Direccion, U.Edad, U.Genero, M.NombreMotorista, M.EstadoMotorista, TP.TipoMandado, HistorialMandados, Precio, Recorrido  from Clientes.Mandados C
inner join Clientes.Usuarios U
on C.idClientes = U.Identidad
inner join Clientes.Motoristas M
on C.idMotoristas = M.NombreMotorista
inner join Clientes.TipoMandado TP
on C.idTipoMandado = TP.TipoMandado
where Identidad = @identidad
END

exec BuscarUsuario '1503200200112'

--Procedimiento que actualiza el estado de un motorista--
CREATE PROCEDURE ActualizarEstadoMotorista(@NombreMotorista char(45), @EstadoMotorista char(45))
AS
BEGIN
UPDATE Clientes.Motoristas
set EstadoMotorista = @EstadoMotorista
where NombreMotorista = @NombreMotorista
END

--Procedimiento que actualiza un mandado a un cliente--
CREATE PROCEDURE ActualizarMandado 
@Identidad char(13),
@TipoMandado char(45),
@motorista char(45), 
@HistorialMandados int, 
@Precio money, 
@Recorrido Decimal
AS
BEGIN
UPDATE Clientes.Mandados
set idMotoristas = @motorista, idTipoMandado = @TipoMandado, HistorialMandados = @HistorialMandados, Precio = @Precio, Recorrido = @Recorrido 
where idClientes = @Identidad
END

exec ActualizarEstadoMotorista 'Motorista 1', 'Haciendo el viaje'
exec ConsultarBase

insert into Clientes.TipoMandado (TipoMandado)
values('--');

insert into Clientes.Motoristas (NombreMotorista, EstadoMotorista)
values('--','--');

select * from Clientes.Motoristas

insert into Clientes.Mandados (idClientes, idMotoristas,idTipoMandado, HistorialMandados, Precio, Recorrido)
values ('1503200200112', 'Motorista 2', 'Otros', 3 ,20, 2000);

exec ActualizarMandado '1503200200112','--','--', 0, 0, 0

exec ConsultarBase

exec ActualizarMandado