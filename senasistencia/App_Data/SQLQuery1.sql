use Senasistencia
go
create table centro_formacion(
                              ID_Centro bigint primary key not null identity (1,1),
							  Nombre_Centro varchar (60) not null,
							  Direccion_Centro varchar (60),
							  Telefono_Centro bigint,
							  Estado_Centro  bit not null,
							  FechaDeCreacion_Centro date not null,
							  FechaDeInactivacion_Centro date not null
							  )

go
create table sede ( ID_Sede bigint primary key not null identity (1,1), 
                    Nombre_Sede varchar (60) not null,
					Direccion_Sede varchar(60),
					Telefono bigint,
					ID_Centro bigint foreign key (ID_Centro) references centro_formacion (ID_Centro) not null,
					Estado_sede bit not null,
					FechaDeCreacion date not null,
					FechaDeInactivacion date not null
					)
go 
create table trimestre(ID_Trimestre bigint primary key not null identity (1,1),
                       Num_Trimestre bigint not null,
					   Estado_Trimestre bigint not null
					   )
go
create table ambiente_formacion(ID_Ambiente bigint primary key not null identity (1,1),
                                Num_Ambiente bigint not null,
								ID_Sede bigint foreign key (ID_Sede) references sede (ID_Sede) not null,
								Estado_Ambiente bit not null,
								FechaDeCreacion bit not null,
								FechaDeInactivacion bit not null
								)
go
create table jornada(ID_Jornada bigint primary key not null identity (1,1),
                     Descripcion_Jornada varchar (60) not null,
					 Estado bit not null
					 )
go

create table ficha(ID_Ficha bigint primary key not null identity(1,1),
                   Num_Ficha bigint not null,
				   ID_Ambiente bigint foreign key(ID_Ambiente) references ambiente_formacion (ID_Ambiente) not null,
				   ID_Trimestre bigint foreign key (ID_Trimestre) references trimestre (ID_Trimestre) not null,
				   ID_Programa bigint foreign key (ID_Programa) references programa_formacion (ID_Programa) not null,
				   ID_Jornada bigint foreign key (ID_Jornada) references jornada (ID_Jornada) not null,
                   Estado bit not null
				   )			       
go
create table programa_formacion(ID_Programa bigint primary key not null identity (1,1),
                                Nombre varchar (60) not null,
								Estado bit not null 
								)	

go
create table tipo_documento(ID_Tipo_Documento bigint primary key not null identity (1,1),
                            Nombre_Doc varchar (30) not null,
							Estado_Doc bit not null, 
							Nomenclatura_Doc varchar (3) not  null,
							FechaDeCreacion_Doc date not null,
							FechaDeInactivacion date not null 
							)
go
create table perfiles(ID_Perfil bigint primary key not null identity (1,1),
                      Perfil varchar (60) not null,
					  Estado bit not null
					  )
go 
create table cargo(ID_Cargo bigint primary key not null identity (1,1),
                   Tipo_Cargo varchar (60) not null,
				   Estado bit not null
				   )
go
create table notificacion (ID_Notificacion bigint primary key not null identity (1,1),
                           Mensaje varchar(500) not null,
						   Fecha date not null,
						   Documento_Cliente bigint foreign key (Documento_Cliente) references cliente (Documento_Cliente) not null,
						   Documento_Aprendiz bigint foreign key (Documento_Aprendiz) references aprendiz (Documento_Aprendiz) not null, 
						   )

						  
go
create table password_token(ID_Token bigint primary key not null identity (1,1),
                            Token_Hash varchar (60) not null,
							ID_Usuario bigint foreign key (ID_Usuario) references usuarios (ID_Usuario) not null,
							Usuarios_Usuario varchar (60) not null,
							Estado bit not null
							)
go
create table usuarios(ID_Usuario bigint primary key not null identity (1,1),
                      Password_Hash varchar(100) not null,
					  Caducidad_Password date not null,
					  Documento_Cliente bigint foreign key (Documento_Cliente) references cliente (Documento_Cliente) not null,
					  Estado bit not null
					  )
go
create table excusa(ID_Excusa bigint primary key not null identity (1,1),
                    Fecha_Excusa date not null,
					Periodo_Excusa date not null,
					Documento_Aprendiz bigint foreign key (Documento_Aprendiz) references aprendiz (Documento_Aprendiz) not null,
					Estado bit not null
					)

go
create table asistencia(ID_Asistencia bigint primary key not null identity (1,1),
                        Descripcion_Asistencia tinyint not null,
						Fecha date not null,
						Estado bit not null,
						Documento_Aprendiz  bigint foreign key  (Documento_Aprendiz) references aprendiz (Documento_Aprendiz) not null,
						)     
go
create table aprendiz (Documento_Aprendiz bigint primary key not null,
                       Nombre_Aprendiz varchar (60) not null,
					   Apellido_Aprendiiz varchar (60) not null,
					   Correo_Aprendiz varchar (60) not null,
					   Telefono_Aprendiz bigint ,
					   ID_Ficha bigint foreign key (ID_Ficha) references ficha (ID_ficha) not null,
                       ID_Tipo_Documento bigint foreign key (ID_Tipo_Documento) references tipo_documento (ID_Tipo_Documento) not null,
					   Estado_Aprendiz bit not null
					   )
go
create table cliente(Documento_Cliente bigint primary key not null,
                     PrimerNombre_Cliente varchar(60) not null,
					 SegundoNombre_Cliente varchar (60)not null,
					 PrimerApellido_Cliente varchar(60)not null,
					 SegundoApellido_Cliente varchar (60) not  null,
					 Correo_Cliente varchar (60) not null,
					 Telefono_Cliente bigint not null,
					 ID_Tipo_Documento bigint foreign key (ID_Tipo_Documento) references tipo_documento (ID_Tipo_Documento) not null,
					 Estado_Cliente bit not null,
					 ID_Cargo bigint foreign key (ID_Cargo) references cargo (ID_Cargo) not null
					 )



