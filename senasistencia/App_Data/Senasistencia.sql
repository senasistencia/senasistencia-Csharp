Create Database Senasistencia
use Senasistencia

--tabla fuerte--
go
create table centro_formacion(
					ID_Centro bigint primary key not null identity (1,1),
					Nombre_Centro varchar (60) not null,
					Direccion_Centro varchar (60),
					Telefono_Centro bigint,
					Estado_Centro  bit not null,
					FechaDeCreacion_Centro date not null,
					FechaDeInactivacion_Centro date
					)


--tabla fuerte--
go 
create table trimestre(
					ID_Trimestre bigint primary key not null identity (1,1),
					Num_Trimestre bigint not null,
					Estado_Trimestre bigint not null,
					FechaDeCreacion_Trimestre date not null,
					FechaDeInactivacion_Trimestre date
					)


--tabla fuerte--
go
create table jornada(
					ID_Jornada bigint primary key not null identity (1,1),
					Descripcion_Jornada varchar (60) not null,
					Estado_Jornada bit not null,
					FechaDeCreacion_Jornada date not null,
					FechaDeInactivacion_Jornada date
					)

--tabla fuerte--								       
go
create table programa_formacion(
					ID_Programa bigint primary key not null identity (1,1),
					Nombre varchar (60) not null,
					Estado_Programa bit not null,
					FechaDeCreacion_Programa date not null,
					FechaDeInactivacion_Programa date
					)


--tabla fuerte--	
go
create table tipo_documento(
					ID_Tipo_Documento bigint primary key not null identity (1,1),
					Nombre_TipoDeDocumento varchar (30) not null,
					Nomenclatura_TipoDeDocumento varchar (3) not  null,
					Estado_TipoDeDocumento bit not null, 
					FechaDeCreacion_Doc date not null,
					FechaDeInactivacion_Doc date
					)


--tabla fuerte--	
go
create table perfil(
					ID_Perfil bigint primary key not null identity (1,1),
					Perfil varchar (60) not null,
					Estado_Perfil bit not null,
					FechaDeCreacion_Perfil date not null,
					FechaDeInactivacion_Perfil date
					)


--tabla fuerte--
go 
create table cargo(
					ID_Cargo bigint primary key not null identity (1,1),
					Tipo_Cargo varchar (60) not null,
					Estado_Cargo bit not null,
					FechaDeCreacion_Cargo Date not null,
					FechaDeInactivacion_Cargo Date
					)


--tabla debil--
go
create table sede(
					ID_Sede bigint primary key not null identity (1,1), 
        			Nombre_Sede varchar (60) not null,
					Direccion_Sede varchar(60),
					Telefono bigint,
					ID_Centro bigint foreign key (ID_Centro) references centro_formacion (ID_Centro) not null,
					Estado_sede bit not null,
					FechaDeCreacion_Sede date not null,
					FechaDeInactivacion_Sede date
					)


--tabla debil--
go
create table ambiente_formacion(
					ID_Ambiente bigint primary key not null identity (1,1),
					Num_Ambiente bigint not null,
					ID_Sede bigint foreign key (ID_Sede) references sede (ID_Sede) not null,
					Estado_Ambiente bit not null,
					FechaDeCreacion_Ambiente date not null,
					FechaDeInactivacion_Ambiente date
					)


--tabla debil--
go
create table ficha(
					ID_Ficha bigint primary key not null identity(1,1),
					Num_Ficha bigint not null,
					ID_Ambiente bigint foreign key(ID_Ambiente) references ambiente_formacion (ID_Ambiente) not null,
					ID_Trimestre bigint foreign key (ID_Trimestre) references trimestre (ID_Trimestre) not null,
					ID_Programa bigint foreign key (ID_Programa) references programa_formacion (ID_Programa) not null,
					ID_Jornada bigint foreign key (ID_Jornada) references jornada (ID_Jornada) not null,
					Estado bit not null,
					FechaDeCreacion_Ficha date not null,
					FechaDeInactivacion_Ficha date
					)


--tabla debil--
go
create table aprendiz(
					ID_DocumentoAprendiz bigint primary key not null,
					ID_Tipo_Documento bigint foreign key (ID_Tipo_Documento) references tipo_documento (ID_Tipo_Documento) not null,
					Nombre_Aprendiz varchar (60) not null,
					Apellido_Aprendiiz varchar (60) not null,
					Correo_Aprendiz varchar (60) not null,
					Telefono_Aprendiz bigint ,
					ID_Ficha bigint foreign key (ID_Ficha) references ficha (ID_ficha) not null,
					Estado_Aprendiz bit not null,
					FechaDeCreacion_Aprendiz Date not null,
					FechaDeInactivacion_Aprendiz Date
					)


--tabla debil--
go
create table asistencia(
					ID_Asistencia bigint primary key not null identity (1,1),
					ID_DocumentoAprendiz  bigint foreign key  (ID_DocumentoAprendiz) references aprendiz (ID_DocumentoAprendiz) not null,
					Descripcion_Asistencia bit not null,
					Fecha_Asistencia date not null,
					Estado_Asistencia bit not null,
					FechaDeCreacion_Asistencia Date not null,
					FechaDeInactivacion_Asistencia Date
					)


--tabla debil--					  
go
create table Formato_Ftp(
					ID_formato bigint primary key not null identity (1,1),
					Nombre_Formato varchar (60),
					Url_Ftp Varchar (500),
					ID_Asistencia bigint foreign key (ID_Asistencia) references asistencia (ID_Asistencia) not null,
					Estado_Formato bit not null,
					FechaDeCreacion_Formato Date not null,
					FechaDeInactivacion_Formato Date
					)

--tabla debil--
go
create table cliente(
					ID_DocumentoCliente bigint primary key not null,
					ID_Tipo_Documento bigint foreign key (ID_Tipo_Documento) references tipo_documento (ID_Tipo_Documento) not null,
					PrimerNombre_Cliente varchar(60) not null,
					SegundoNombre_Cliente varchar (60)not null,
					PrimerApellido_Cliente varchar(60)not null,
					SegundoApellido_Cliente varchar (60) not  null,
					Correo_Cliente varchar (60) not null,
					Telefono_Cliente bigint not null,
					ID_Cargo bigint foreign key (ID_Cargo) references cargo (ID_Cargo) not null,
					ID_Perfil bigint foreign key (ID_Perfil) references perfil (ID_Perfil) not null,
					Estado_Cliente bit not null,
					FechaDeCreacion_Cliente Date not null,
					FechaDeInactivacion_Cliente Date
					)

--tabla debil--    
go
create table notificacion (
					ID_Notificacion bigint primary key not null identity (1,1),
					Mensaje_Notificacion varchar(500) not null,
					Fecha date not null,
					ID_formato bigint foreign key (ID_formato) references Formato_Ftp (ID_formato) not null,
					ID_DocumentoAprendiz bigint foreign key (ID_DocumentoAprendiz) references aprendiz (ID_DocumentoAprendiz) not null,
					ID_DocumentoCliente bigint foreign key (ID_DocumentoCliente) references cliente (ID_DocumentoCliente) not null,
					FechaDeCreacion_Notificacion Date not null,
					FechaDeInactivacion_Notificacion Date
					)


--tabla debil--
go
create table excusa(
					ID_Excusa bigint primary key not null identity (1,1),
					ID_DocumentoAprendiz bigint foreign key (ID_DocumentoAprendiz) references aprendiz (ID_DocumentoAprendiz) not null,
					Fecha_Excusa date not null,
					Periodo_Excusa date not null,
					Estado_Excusa bit not null,
					FechaDeCreacion_Excusa Date not null,
					FechaDeInactivacion_Excusa Date
					)

--tabla debil--
go
create table usuario(
					ID_Usuario bigint primary key not null identity (1,1),
					ID_DocumentoCliente bigint foreign key (ID_DocumentoCliente) references cliente (ID_DocumentoCliente) not null,
					Password_Hash varchar(100) not null,
					Caducidad_Password date not null,
					Estado_Usuario bit not null,
					FechaDeCreacion_Usuario Date not null,
					FechaDeInactivacion_Usuario Date
					)


--tabla debil--
go
create table password_token(
					ID_Token bigint primary key not null identity (1,1),
					Token_Hash varchar (60) not null,
					ID_Usuario bigint foreign key (ID_Usuario) references usuario (ID_Usuario) not null,
					Estado_Token bit not null,
					FechaDeCreacion_Token Date not null,
					FechaDeInactivacion_Token Date
					)



