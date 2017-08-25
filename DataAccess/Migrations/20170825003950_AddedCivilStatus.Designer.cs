using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DataAccess.Models;

namespace Football.DataAccess.Migrations
{
    [DbContext(typeof(c__database_futbol_mdfContext))]
    [Migration("20170825003950_AddedCivilStatus")]
    partial class AddedCivilStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Models.Abono", b =>
                {
                    b.Property<int>("IdAbono")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_abono");

                    b.Property<int?>("CodCompeticion")
                        .IsRequired()
                        .HasColumnName("cod_competicion");

                    b.Property<int?>("CodZona")
                        .HasColumnName("cod_zona");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasColumnName("loginName")
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdAbono")
                        .HasName("PK__abono__4CA06362");

                    b.HasIndex("CodZona");

                    b.HasIndex("LoginName", "CodCompeticion")
                        .IsUnique()
                        .HasName("UQ__abono__4D94879B");

                    b.ToTable("abono");
                });

            modelBuilder.Entity("DataAccess.Models.Agenda", b =>
                {
                    b.Property<int>("IdEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_evento");

                    b.Property<int?>("CodCalendario")
                        .HasColumnName("cod_calendario");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnName("descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnName("fecha")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnName("tipo")
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdEvento")
                        .HasName("PK__agenda__3E52440B");

                    b.ToTable("agenda");
                });

            modelBuilder.Entity("DataAccess.Models.Arbitro", b =>
                {
                    b.Property<int>("CodArbitro")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Arbitro");

                    b.Property<int?>("AnosActivo")
                        .HasColumnName("Anos_Activo");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Colegio")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Foto")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("CodArbitro")
                        .HasName("PK__Arbitro__1B0907CE");

                    b.ToTable("Arbitro");
                });

            modelBuilder.Entity("DataAccess.Models.Asiento", b =>
                {
                    b.Property<int>("CodCompeticion")
                        .HasColumnName("cod_competicion");

                    b.Property<int>("RefZona")
                        .HasColumnName("ref_zona");

                    b.Property<int?>("Libres")
                        .HasColumnName("libres");

                    b.Property<float?>("Precio")
                        .HasColumnName("precio");

                    b.HasKey("CodCompeticion", "RefZona")
                        .HasName("PK__asiento__48CFD27E");

                    b.ToTable("asiento");
                });

            modelBuilder.Entity("DataAccess.Models.Calendario", b =>
                {
                    b.Property<int>("CodCalendario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cod_calendario");

                    b.Property<int>("CodCompeticion")
                        .HasColumnName("cod_Competicion");

                    b.Property<int>("CodLocal")
                        .HasColumnName("cod_Local");

                    b.Property<int>("CodVisitante")
                        .HasColumnName("cod_Visitante");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnName("fecha")
                        .HasColumnType("datetime");

                    b.Property<string>("Jornada")
                        .IsRequired()
                        .HasColumnName("jornada")
                        .HasColumnType("varchar(20)");

                    b.HasKey("CodCalendario")
                        .HasName("PK__Calendario__3C69FB99");

                    b.ToTable("Calendario");
                });

            modelBuilder.Entity("DataAccess.Models.Cambio", b =>
                {
                    b.Property<int>("CodCambio")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Cambio");

                    b.Property<int>("CodJugadorEntra")
                        .HasColumnName("Cod_Jugador_Entra");

                    b.Property<int>("CodJugadorSale")
                        .HasColumnName("Cod_Jugador_Sale");

                    b.Property<int>("CodPartido")
                        .HasColumnName("Cod_Partido");

                    b.Property<int>("Minuto");

                    b.HasKey("CodCambio")
                        .HasName("PK__Cambio__2F10007B");

                    b.HasIndex("CodJugadorEntra");

                    b.HasIndex("CodJugadorSale");

                    b.HasIndex("CodPartido");

                    b.ToTable("Cambio");
                });

            modelBuilder.Entity("DataAccess.Models.Clasificacion", b =>
                {
                    b.Property<int>("CodCompeticion")
                        .HasColumnName("Cod_Competicion");

                    b.Property<int>("Jornada")
                        .HasColumnName("jornada");

                    b.Property<int>("CodEquipo")
                        .HasColumnName("Cod_Equipo");

                    b.Property<int>("Posicion")
                        .HasColumnName("posicion");

                    b.Property<int?>("Empatados")
                        .HasColumnName("empatados");

                    b.Property<int?>("Ganados")
                        .HasColumnName("ganados");

                    b.Property<int?>("GolesContra")
                        .HasColumnName("goles_contra");

                    b.Property<int?>("GolesFavor")
                        .HasColumnName("goles_favor");

                    b.Property<int?>("Perdidos")
                        .HasColumnName("perdidos");

                    b.Property<int?>("Puntos")
                        .HasColumnName("puntos");

                    b.HasKey("CodCompeticion", "Jornada", "CodEquipo", "Posicion")
                        .HasName("PK__Clasificacion__33D4B598");

                    b.HasIndex("CodEquipo");

                    b.ToTable("Clasificacion");
                });

            modelBuilder.Entity("DataAccess.Models.Comentario", b =>
                {
                    b.Property<int>("CodComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Comentario");

                    b.Property<string>("Autor")
                        .HasColumnName("autor")
                        .HasColumnType("varchar(30)");

                    b.Property<int>("CodNoticia")
                        .HasColumnName("cod_Noticia");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnName("fecha")
                        .HasColumnType("datetime");

                    b.Property<string>("Texto")
                        .HasColumnName("texto")
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .HasColumnName("titulo")
                        .HasColumnType("varchar(30)");

                    b.HasKey("CodComentario")
                        .HasName("PK__Comentario__403A8C7D");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("DataAccess.Models.Competicion", b =>
                {
                    b.Property<int>("CodCompeticion")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Competicion");

                    b.Property<string>("Campeon")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnName("Fecha_Fin")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnName("Fecha_Inicio")
                        .HasColumnType("datetime");

                    b.Property<string>("Foto")
                        .HasColumnName("foto")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Temporada")
                        .IsRequired()
                        .HasColumnName("temporada")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Tipo")
                        .HasColumnName("tipo")
                        .HasColumnType("varchar(20)");

                    b.HasKey("CodCompeticion")
                        .HasName("PK__Competicion__1920BF5C");

                    b.ToTable("Competicion");
                });

            modelBuilder.Entity("DataAccess.Models.Countries", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasColumnName("countryCode")
                        .HasColumnType("nchar(2)");

                    b.Property<string>("LanguageCode")
                        .HasColumnName("languageCode")
                        .HasColumnType("nchar(2)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnName("countryName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("CountryCode", "LanguageCode")
                        .HasName("PK_Countries");

                    b.HasIndex("LanguageCode");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("DataAccess.Models.Directivo", b =>
                {
                    b.Property<int>("CodIntegrante")
                        .HasColumnName("Cod_Integrante");

                    b.Property<int>("CodEquipo")
                        .HasColumnName("Cod_Equipo");

                    b.Property<int>("VersionIntegrante")
                        .HasColumnName("Version_Integrante");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("CodDirectivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Directivo");

                    b.Property<string>("Profesion")
                        .HasColumnType("varchar(20)");

                    b.HasKey("CodIntegrante", "CodEquipo", "VersionIntegrante")
                        .HasName("PK__Directivo__0AD2A005");

                    b.HasIndex("CodEquipo");

                    b.ToTable("Directivo");
                });

            modelBuilder.Entity("DataAccess.Models.Entrenador", b =>
                {
                    b.Property<int>("CodIntegrante")
                        .HasColumnName("Cod_Integrante");

                    b.Property<int>("CodEquipo")
                        .HasColumnName("Cod_Equipo");

                    b.Property<int>("VersionIntegrante")
                        .HasColumnName("Version_Integrante");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("CodEntrenador")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Entrenador");

                    b.Property<DateTime?>("FechaProfesional")
                        .HasColumnName("Fecha_Profesional")
                        .HasColumnType("datetime");

                    b.HasKey("CodIntegrante", "CodEquipo", "VersionIntegrante")
                        .HasName("PK__Entrenador__07F6335A");

                    b.HasIndex("CodEquipo");

                    b.ToTable("Entrenador");
                });

            modelBuilder.Entity("DataAccess.Models.Equipo", b =>
                {
                    b.Property<int>("CodEquipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Equipo");

                    b.Property<int?>("CodEstadio")
                        .HasColumnName("Cod_Estadio");

                    b.Property<string>("FotoEscudo")
                        .HasColumnName("Foto_Escudo")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FotoPlantilla")
                        .HasColumnName("Foto_Plantilla")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Localidad")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("CodEquipo")
                        .HasName("PK__Equipo__7E6CC920");

                    b.ToTable("Equipo");
                });

            modelBuilder.Entity("DataAccess.Models.EquiposParticipan", b =>
                {
                    b.Property<int>("CodCompeticion")
                        .HasColumnName("Cod_Competicion");

                    b.Property<int>("CodEquipo")
                        .HasColumnName("Cod_Equipo");

                    b.HasKey("CodCompeticion", "CodEquipo")
                        .HasName("PK__EquiposParticipa__37A5467C");

                    b.HasIndex("CodEquipo");

                    b.ToTable("EquiposParticipan");
                });

            modelBuilder.Entity("DataAccess.Models.Estadio", b =>
                {
                    b.Property<int>("CodEstadio")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Estadio");

                    b.Property<int>("Capacidad");

                    b.Property<string>("Direccion")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Foto")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(20)");

                    b.HasKey("CodEstadio")
                        .HasName("PK__Estadio__173876EA");

                    b.ToTable("Estadio");
                });

            modelBuilder.Entity("DataAccess.Models.Gol", b =>
                {
                    b.Property<int>("CodGol")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Gol");

                    b.Property<int>("CodJugador")
                        .HasColumnName("Cod_Jugador");

                    b.Property<int>("CodPartido")
                        .HasColumnName("Cod_Partido");

                    b.Property<int>("Minuto");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Video")
                        .HasColumnName("video")
                        .HasColumnType("text");

                    b.HasKey("CodGol")
                        .HasName("PK__Gol__276EDEB3");

                    b.HasIndex("CodJugador");

                    b.HasIndex("CodPartido");

                    b.ToTable("Gol");
                });

            modelBuilder.Entity("DataAccess.Models.HcoIntegrante", b =>
                {
                    b.Property<int>("CodIntegrante")
                        .HasColumnName("Cod_Integrante");

                    b.Property<int>("CodEquipo")
                        .HasColumnName("Cod_Equipo");

                    b.Property<int>("VersionIntegrante")
                        .HasColumnName("Version_Integrante");

                    b.Property<int?>("Dorsal");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnName("Fecha_Fin")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaFinContrato")
                        .HasColumnName("Fecha_Fin_Contrato")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnName("Fecha_Inicio")
                        .HasColumnType("datetime");

                    b.Property<float?>("Sueldo");

                    b.HasKey("CodIntegrante", "CodEquipo", "VersionIntegrante")
                        .HasName("PK__Hco_Integrante__00551192");

                    b.HasIndex("CodEquipo");

                    b.ToTable("Hco_Integrante");
                });

            modelBuilder.Entity("DataAccess.Models.Integrante", b =>
                {
                    b.Property<int>("CodInt")
                        .HasColumnName("Cod_Int");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime?>("FechaNac")
                        .HasColumnName("Fecha_Nac")
                        .HasColumnType("datetime");

                    b.Property<string>("Foto")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("CodInt")
                        .HasName("PK__Integrante__7C8480AE");

                    b.ToTable("Integrante");
                });

            modelBuilder.Entity("DataAccess.Models.Jugador", b =>
                {
                    b.Property<int>("CodJugador")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Jugador");

                    b.Property<float?>("Altura");

                    b.Property<int?>("CodEquipo")
                        .HasColumnName("Cod_Equipo");

                    b.Property<int?>("CodIntegrante")
                        .HasColumnName("Cod_Integrante");

                    b.Property<bool>("Married");

                    b.Property<string>("Pierna")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Posicion")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("VersionIntegrante")
                        .HasColumnName("Version_Integrante");

                    b.HasKey("CodJugador")
                        .HasName("PK__Jugador__108B795B");

                    b.HasIndex("CodEquipo");

                    b.HasIndex("CodIntegrante");

                    b.ToTable("Jugador");
                });

            modelBuilder.Entity("DataAccess.Models.Languages", b =>
                {
                    b.Property<string>("LanguageCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("languageCode")
                        .HasColumnType("nchar(2)");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnName("languageName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("LanguageCode")
                        .HasName("PK_Languages");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("DataAccess.Models.LineaPedido", b =>
                {
                    b.Property<int>("Idpedido")
                        .HasColumnName("idpedido");

                    b.Property<int>("Idlinea")
                        .HasColumnName("idlinea");

                    b.Property<int>("Cantidad")
                        .HasColumnName("cantidad");

                    b.Property<int>("Disp")
                        .HasColumnName("disp");

                    b.Property<int>("IdProducto")
                        .HasColumnName("idProducto");

                    b.Property<float>("Pvp")
                        .HasColumnName("pvp");

                    b.HasKey("Idpedido", "Idlinea")
                        .HasName("PK__LineaPedido__5535A963");

                    b.ToTable("LineaPedido");
                });

            modelBuilder.Entity("DataAccess.Models.Medico", b =>
                {
                    b.Property<int>("CodMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Medico");

                    b.Property<int>("CodEquipo")
                        .HasColumnName("Cod_Equipo");

                    b.Property<int>("CodIntegrante")
                        .HasColumnName("Cod_Integrante");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("FechaProfesional")
                        .HasColumnName("Fecha_Profesional")
                        .HasColumnType("datetime");

                    b.Property<int>("VersionIntegrante")
                        .HasColumnName("Version_Integrante");

                    b.HasKey("CodMedico")
                        .HasName("PK__Medico__0DAF0CB0");

                    b.HasIndex("CodEquipo");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("DataAccess.Models.Noticia", b =>
                {
                    b.Property<int>("CodNoticia")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Noticia");

                    b.Property<string>("Autor")
                        .HasColumnName("autor")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("CodPartido")
                        .HasColumnName("cod_Partido");

                    b.Property<string>("Cuerpo")
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnName("fecha")
                        .HasColumnType("datetime");

                    b.Property<string>("Foto")
                        .HasColumnName("foto")
                        .HasColumnType("text");

                    b.Property<string>("Resumen")
                        .HasColumnType("text");

                    b.Property<string>("SubCategoria")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Titulo")
                        .HasColumnType("text");

                    b.HasKey("CodNoticia")
                        .HasName("PK__Noticia__3A81B327");

                    b.ToTable("Noticia");
                });

            modelBuilder.Entity("DataAccess.Models.Partido", b =>
                {
                    b.Property<int>("CodPartido")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Partido");

                    b.Property<int?>("Asistencia");

                    b.Property<string>("Clima")
                        .HasColumnType("varchar(10)");

                    b.Property<int>("CodArbitro")
                        .HasColumnName("Cod_Arbitro");

                    b.Property<int>("CodCompeticion")
                        .HasColumnName("Cod_Competicion");

                    b.Property<int>("CodEstadio")
                        .HasColumnName("Cod_Estadio");

                    b.Property<int>("CodLocal")
                        .HasColumnName("Cod_Local");

                    b.Property<int>("CodVisitante")
                        .HasColumnName("Cod_Visitante");

                    b.Property<int>("CornersLocal")
                        .HasColumnName("Corners_Local");

                    b.Property<int>("CornersVisitante")
                        .HasColumnName("Corners_Visitante");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int>("FuerasJuegoLocal")
                        .HasColumnName("Fueras_Juego_Local");

                    b.Property<int>("FuerasJuegoVisitante")
                        .HasColumnName("Fueras_Juego_Visitante");

                    b.Property<int>("GolesLocal")
                        .HasColumnName("Goles_Local");

                    b.Property<int>("GolesVisitante")
                        .HasColumnName("Goles_Visitante");

                    b.Property<string>("Jornada")
                        .HasColumnType("varchar(10)");

                    b.Property<float>("PosesionLocal")
                        .HasColumnName("Posesion_Local");

                    b.Property<float>("PosesionVisitante")
                        .HasColumnName("Posesion_Visitante");

                    b.HasKey("CodPartido")
                        .HasName("PK__Partido__1CF15040");

                    b.HasIndex("CodArbitro");

                    b.HasIndex("CodCompeticion");

                    b.HasIndex("CodEstadio");

                    b.HasIndex("CodLocal");

                    b.HasIndex("CodVisitante");

                    b.ToTable("Partido");
                });

            modelBuilder.Entity("DataAccess.Models.PartidoJugado", b =>
                {
                    b.Property<int>("CodJugador")
                        .HasColumnName("Cod_Jugador");

                    b.Property<int>("CodPartido")
                        .HasColumnName("Cod_Partido");

                    b.Property<int>("Asistencias");

                    b.Property<int>("AsistenciasGol")
                        .HasColumnName("Asistencias_Gol");

                    b.Property<int>("BalonesPerdidos")
                        .HasColumnName("balones_perdidos");

                    b.Property<int>("BalonesRecuperados")
                        .HasColumnName("balones_recuperados");

                    b.Property<int>("Corners")
                        .HasColumnName("corners");

                    b.Property<int>("FaltasCometidas")
                        .HasColumnName("Faltas_Cometidas");

                    b.Property<int>("FaltasRecibidas")
                        .HasColumnName("Faltas_Recibidas");

                    b.Property<int>("FuerasJuego")
                        .HasColumnName("fueras_Juego");

                    b.Property<int>("Minutos");

                    b.Property<int>("PenaltisCometidos")
                        .HasColumnName("penaltis_cometidos");

                    b.Property<int>("PenaltisRecibidos")
                        .HasColumnName("penaltis_recibidos");

                    b.Property<int>("Remates")
                        .HasColumnName("remates");

                    b.Property<int>("RematesPorteria")
                        .HasColumnName("remates_Porteria");

                    b.Property<int>("RematesPoste")
                        .HasColumnName("remates_Poste");

                    b.Property<int>("TarjetasAmarillasProvocadas")
                        .HasColumnName("tarjetas_Amarillas_Provocadas");

                    b.Property<int>("TarjetasRojasProvocadas")
                        .HasColumnName("tarjetas_Rojas_Provocadas");

                    b.Property<string>("Titular")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("CodJugador", "CodPartido")
                        .HasName("PK__Partido_Jugado__239E4DCF");

                    b.HasIndex("CodPartido");

                    b.ToTable("Partido_Jugado");
                });

            modelBuilder.Entity("DataAccess.Models.Pedidos", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idPedido");

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnName("calle")
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Cp")
                        .HasColumnName("cp");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("varchar(10)")
                        .HasDefaultValueSql("'Pendiente'");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnName("fecha")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Fechatarjeta")
                        .HasColumnName("fechatarjeta")
                        .HasColumnType("datetime");

                    b.Property<string>("IdUsuario")
                        .HasColumnName("idUsuario")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Numero")
                        .HasColumnName("numero");

                    b.Property<string>("Puerta")
                        .HasColumnName("puerta")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Tarjeta")
                        .IsRequired()
                        .HasColumnName("tarjeta")
                        .HasColumnType("varchar(17)");

                    b.HasKey("IdPedido")
                        .HasName("PK__pedidos__52593CB8");

                    b.ToTable("pedidos");
                });

            modelBuilder.Entity("DataAccess.Models.Producto", b =>
                {
                    b.Property<int>("ProdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("prodId");

                    b.Property<string>("Categoria")
                        .HasColumnName("categoria")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Descripcion")
                        .HasColumnName("descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAlta")
                        .HasColumnName("fechaAlta")
                        .HasColumnType("datetime");

                    b.Property<string>("Foto")
                        .HasColumnName("foto")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasColumnName("nombre")
                        .HasColumnType("varchar(50)");

                    b.Property<float?>("Precio")
                        .HasColumnName("precio");

                    b.Property<int?>("Stock")
                        .HasColumnName("stock");

                    b.HasKey("ProdId")
                        .HasName("PK__Producto__5070F446");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("DataAccess.Models.Tarjeta", b =>
                {
                    b.Property<int>("CodTarjeta")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Tarjeta");

                    b.Property<int>("CodJugador")
                        .HasColumnName("Cod_Jugador");

                    b.Property<int>("CodPartido")
                        .HasColumnName("Cod_Partido");

                    b.Property<int>("Minuto");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("CodTarjeta")
                        .HasName("PK__Tarjeta__2B3F6F97");

                    b.HasIndex("CodJugador");

                    b.HasIndex("CodPartido");

                    b.ToTable("Tarjeta");
                });

            modelBuilder.Entity("DataAccess.Models.Transpaso", b =>
                {
                    b.Property<int>("CodTranspaso")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Transpaso");

                    b.Property<int>("CodEquipoDestino")
                        .HasColumnName("Cod_Equipo_Destino");

                    b.Property<int>("CodEquipoOrigen")
                        .HasColumnName("Cod_Equipo_Origen");

                    b.Property<int>("CodIntegrante")
                        .HasColumnName("Cod_Integrante");

                    b.Property<float>("Coste");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.HasKey("CodTranspaso")
                        .HasName("PK__Transpaso__0425A276");

                    b.HasIndex("CodEquipoDestino");

                    b.HasIndex("CodEquipoOrigen");

                    b.ToTable("Transpaso");
                });

            modelBuilder.Entity("DataAccess.Models.Trata", b =>
                {
                    b.Property<int>("CodTratamiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cod_Tratamiento");

                    b.Property<int>("CodJugador")
                        .HasColumnName("Cod_Jugador");

                    b.Property<int>("CodMedico")
                        .HasColumnName("Cod_Medico");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnName("Fecha_Fin")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnName("Fecha_Inicio")
                        .HasColumnType("datetime");

                    b.Property<string>("Lesion")
                        .HasColumnType("varchar(20)");

                    b.HasKey("CodTratamiento")
                        .HasName("PK__Trata__1367E606");

                    b.HasIndex("CodJugador");

                    b.HasIndex("CodMedico");

                    b.ToTable("Trata");
                });

            modelBuilder.Entity("DataAccess.Models.UserProfile", b =>
                {
                    b.Property<string>("LoginName")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("loginName")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("country")
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("Cp")
                        .HasColumnName("cp");

                    b.Property<string>("Direccion")
                        .HasColumnName("direccion")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnName("dni")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("EnPassword")
                        .IsRequired()
                        .HasColumnName("enPassword")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FechaTarjeta")
                        .HasColumnName("fechaTarjeta")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("firstName")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnName("language")
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Localidad")
                        .HasColumnName("localidad")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("surname")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Tarjeta")
                        .HasColumnName("tarjeta")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Telefono")
                        .HasColumnName("telefono")
                        .HasColumnType("varchar(50)");

                    b.HasKey("LoginName")
                        .HasName("PK_UserProfile");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("DataAccess.Models.ZonaEstadio", b =>
                {
                    b.Property<int>("IdZona")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_zona");

                    b.Property<int?>("Capacidad")
                        .HasColumnName("capacidad");

                    b.Property<string>("Cubierto")
                        .HasColumnName("cubierto")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Nombre")
                        .HasColumnName("nombre")
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdZona")
                        .HasName("PK__zonaEstadio__4AB81AF0");

                    b.ToTable("zonaEstadio");
                });

            modelBuilder.Entity("DataAccess.Models.Abono", b =>
                {
                    b.HasOne("DataAccess.Models.ZonaEstadio", "CodZonaNavigation")
                        .WithMany("Abono")
                        .HasForeignKey("CodZona");
                });

            modelBuilder.Entity("DataAccess.Models.Cambio", b =>
                {
                    b.HasOne("DataAccess.Models.Jugador", "CodJugadorEntraNavigation")
                        .WithMany("CambioCodJugadorEntraNavigation")
                        .HasForeignKey("CodJugadorEntra");

                    b.HasOne("DataAccess.Models.Jugador", "CodJugadorSaleNavigation")
                        .WithMany("CambioCodJugadorSaleNavigation")
                        .HasForeignKey("CodJugadorSale");

                    b.HasOne("DataAccess.Models.Partido", "CodPartidoNavigation")
                        .WithMany("Cambio")
                        .HasForeignKey("CodPartido");
                });

            modelBuilder.Entity("DataAccess.Models.Clasificacion", b =>
                {
                    b.HasOne("DataAccess.Models.Competicion", "CodCompeticionNavigation")
                        .WithMany("Clasificacion")
                        .HasForeignKey("CodCompeticion");

                    b.HasOne("DataAccess.Models.Equipo", "CodEquipoNavigation")
                        .WithMany("Clasificacion")
                        .HasForeignKey("CodEquipo");
                });

            modelBuilder.Entity("DataAccess.Models.Countries", b =>
                {
                    b.HasOne("DataAccess.Models.Languages", "LanguageCodeNavigation")
                        .WithMany("Countries")
                        .HasForeignKey("LanguageCode");
                });

            modelBuilder.Entity("DataAccess.Models.Directivo", b =>
                {
                    b.HasOne("DataAccess.Models.Equipo", "CodEquipoNavigation")
                        .WithMany("Directivo")
                        .HasForeignKey("CodEquipo");
                });

            modelBuilder.Entity("DataAccess.Models.Entrenador", b =>
                {
                    b.HasOne("DataAccess.Models.Equipo", "CodEquipoNavigation")
                        .WithMany("Entrenador")
                        .HasForeignKey("CodEquipo");
                });

            modelBuilder.Entity("DataAccess.Models.EquiposParticipan", b =>
                {
                    b.HasOne("DataAccess.Models.Equipo", "CodEquipoNavigation")
                        .WithMany("EquiposParticipan")
                        .HasForeignKey("CodEquipo")
                        .HasConstraintName("FK__EquiposPa__Cod_E__38996AB5");
                });

            modelBuilder.Entity("DataAccess.Models.Gol", b =>
                {
                    b.HasOne("DataAccess.Models.Jugador", "CodJugadorNavigation")
                        .WithMany("Gol")
                        .HasForeignKey("CodJugador");

                    b.HasOne("DataAccess.Models.Partido", "CodPartidoNavigation")
                        .WithMany("Gol")
                        .HasForeignKey("CodPartido");
                });

            modelBuilder.Entity("DataAccess.Models.HcoIntegrante", b =>
                {
                    b.HasOne("DataAccess.Models.Equipo", "CodEquipoNavigation")
                        .WithMany("HcoIntegrante")
                        .HasForeignKey("CodEquipo")
                        .HasConstraintName("FK__Hco_Integ__Cod_E__023D5A04");

                    b.HasOne("DataAccess.Models.Integrante", "CodIntegranteNavigation")
                        .WithMany("HcoIntegrante")
                        .HasForeignKey("CodIntegrante");
                });

            modelBuilder.Entity("DataAccess.Models.Jugador", b =>
                {
                    b.HasOne("DataAccess.Models.Equipo", "CodEquipoNavigation")
                        .WithMany("Jugador")
                        .HasForeignKey("CodEquipo")
                        .HasConstraintName("FK__Jugador__Cod_Equ__117F9D94");

                    b.HasOne("DataAccess.Models.Integrante", "CodIntegranteNavigation")
                        .WithMany("Jugador")
                        .HasForeignKey("CodIntegrante")
                        .HasConstraintName("FK_Jugador_Integrante");
                });

            modelBuilder.Entity("DataAccess.Models.LineaPedido", b =>
                {
                    b.HasOne("DataAccess.Models.Pedidos", "IdpedidoNavigation")
                        .WithMany("LineaPedido")
                        .HasForeignKey("Idpedido");
                });

            modelBuilder.Entity("DataAccess.Models.Medico", b =>
                {
                    b.HasOne("DataAccess.Models.Equipo", "CodEquipoNavigation")
                        .WithMany("Medico")
                        .HasForeignKey("CodEquipo")
                        .HasConstraintName("FK__Medico__Cod_Equi__0EA330E9");
                });

            modelBuilder.Entity("DataAccess.Models.Partido", b =>
                {
                    b.HasOne("DataAccess.Models.Arbitro", "CodArbitroNavigation")
                        .WithMany("Partido")
                        .HasForeignKey("CodArbitro")
                        .HasConstraintName("FK__Partido__Cod_Arb__20C1E124");

                    b.HasOne("DataAccess.Models.Competicion", "CodCompeticionNavigation")
                        .WithMany("Partido")
                        .HasForeignKey("CodCompeticion")
                        .HasConstraintName("FK__Partido__Cod_Com__1DE57479");

                    b.HasOne("DataAccess.Models.Estadio", "CodEstadioNavigation")
                        .WithMany("Partido")
                        .HasForeignKey("CodEstadio")
                        .HasConstraintName("FK__Partido__Cod_Est__21B6055D");

                    b.HasOne("DataAccess.Models.Equipo", "CodLocalNavigation")
                        .WithMany("PartidoCodLocalNavigation")
                        .HasForeignKey("CodLocal")
                        .HasConstraintName("FK__Partido__Cod_Loc__1ED998B2");

                    b.HasOne("DataAccess.Models.Equipo", "CodVisitanteNavigation")
                        .WithMany("PartidoCodVisitanteNavigation")
                        .HasForeignKey("CodVisitante")
                        .HasConstraintName("FK__Partido__Cod_Vis__1FCDBCEB");
                });

            modelBuilder.Entity("DataAccess.Models.PartidoJugado", b =>
                {
                    b.HasOne("DataAccess.Models.Jugador", "CodJugadorNavigation")
                        .WithMany("PartidoJugado")
                        .HasForeignKey("CodJugador")
                        .HasConstraintName("FK__Partido_J__Cod_J__24927208");

                    b.HasOne("DataAccess.Models.Partido", "CodPartidoNavigation")
                        .WithMany("PartidoJugado")
                        .HasForeignKey("CodPartido")
                        .HasConstraintName("FK__Partido_J__Cod_P__25869641");
                });

            modelBuilder.Entity("DataAccess.Models.Tarjeta", b =>
                {
                    b.HasOne("DataAccess.Models.Jugador", "CodJugadorNavigation")
                        .WithMany("Tarjeta")
                        .HasForeignKey("CodJugador")
                        .HasConstraintName("FK__Tarjeta__Cod_Jug__2D27B809");

                    b.HasOne("DataAccess.Models.Partido", "CodPartidoNavigation")
                        .WithMany("Tarjeta")
                        .HasForeignKey("CodPartido")
                        .HasConstraintName("FK__Tarjeta__Cod_Par__2C3393D0");
                });

            modelBuilder.Entity("DataAccess.Models.Transpaso", b =>
                {
                    b.HasOne("DataAccess.Models.Equipo", "CodEquipoDestinoNavigation")
                        .WithMany("TranspasoCodEquipoDestinoNavigation")
                        .HasForeignKey("CodEquipoDestino")
                        .HasConstraintName("FK__Transpaso__Cod_E__060DEAE8");

                    b.HasOne("DataAccess.Models.Equipo", "CodEquipoOrigenNavigation")
                        .WithMany("TranspasoCodEquipoOrigenNavigation")
                        .HasForeignKey("CodEquipoOrigen")
                        .HasConstraintName("FK__Transpaso__Cod_E__0519C6AF");
                });

            modelBuilder.Entity("DataAccess.Models.Trata", b =>
                {
                    b.HasOne("DataAccess.Models.Jugador", "CodJugadorNavigation")
                        .WithMany("Trata")
                        .HasForeignKey("CodJugador")
                        .HasConstraintName("FK__Trata__Cod_Jugad__15502E78");

                    b.HasOne("DataAccess.Models.Medico", "CodMedicoNavigation")
                        .WithMany("Trata")
                        .HasForeignKey("CodMedico")
                        .HasConstraintName("FK__Trata__Cod_Medic__145C0A3F");
                });
        }
    }
}
