using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class c__database_futbol_mdfContext : DbContext
    {
        //public c__database_futbol_mdfContext(DbContextOptions options)
        //: base(options)
        //{
        //}

        public virtual DbSet<Abono> Abono { get; set; }
        public virtual DbSet<Agenda> Agenda { get; set; }
        public virtual DbSet<Arbitro> Arbitro { get; set; }
        public virtual DbSet<Asiento> Asiento { get; set; }
        public virtual DbSet<Calendario> Calendario { get; set; }
        public virtual DbSet<Cambio> Cambio { get; set; }
        public virtual DbSet<Clasificacion> Clasificacion { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Competicion> Competicion { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Directivo> Directivo { get; set; }
        public virtual DbSet<Entrenador> Entrenador { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<EquiposParticipan> EquiposParticipan { get; set; }
        public virtual DbSet<Estadio> Estadio { get; set; }
        public virtual DbSet<Gol> Gol { get; set; }
        public virtual DbSet<HcoIntegrante> HcoIntegrante { get; set; }
        public virtual DbSet<Integrante> Integrante { get; set; }
        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<LineaPedido> LineaPedido { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Noticia> Noticia { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<PartidoJugado> PartidoJugado { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }
        public virtual DbSet<Transpaso> Transpaso { get; set; }
        public virtual DbSet<Trata> Trata { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<ZonaEstadio> ZonaEstadio { get; set; }

        public virtual DbSet<GlobalMedia> GlobalMedia { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    //optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=c:\database\futbol.mdf;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abono>(entity =>
            {
                entity.HasKey(e => e.IdAbono)
                    .HasName("PK__abono__4CA06362");

                entity.ToTable("abono");

                entity.HasIndex(e => new { e.LoginName, e.CodCompeticion })
                    .HasName("UQ__abono__4D94879B")
                    .IsUnique();

                entity.Property(e => e.IdAbono).HasColumnName("id_abono");

                entity.Property(e => e.CodCompeticion)
                    .IsRequired()
                    .HasColumnName("cod_competicion");

                entity.Property(e => e.CodZona).HasColumnName("cod_zona");

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasColumnName("loginName")
                    .HasColumnType("varchar(20)");

                entity.HasOne(d => d.CodZonaNavigation)
                    .WithMany(p => p.Abono)
                    .HasForeignKey(d => d.CodZona)
                    .HasConstraintName("FK__abono__cod_zona__4E88ABD4");
            });

            modelBuilder.Entity<Agenda>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__agenda__3E52440B");

                entity.ToTable("agenda");

                entity.Property(e => e.IdEvento).HasColumnName("id_evento");

                entity.Property(e => e.CodCalendario).HasColumnName("cod_calendario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("text");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("text");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Arbitro>(entity =>
            {
                entity.HasKey(e => e.CodArbitro)
                    .HasName("PK__Arbitro__1B0907CE");

                entity.Property(e => e.CodArbitro).HasColumnName("Cod_Arbitro");

                entity.Property(e => e.AnosActivo).HasColumnName("Anos_Activo");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Colegio).HasColumnType("varchar(20)");

                entity.Property(e => e.Foto).HasColumnType("varchar(50)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Asiento>(entity =>
            {
                entity.HasKey(e => new { e.CodCompeticion, e.RefZona })
                    .HasName("PK__asiento__48CFD27E");

                entity.ToTable("asiento");

                entity.Property(e => e.CodCompeticion).HasColumnName("cod_competicion");

                entity.Property(e => e.RefZona).HasColumnName("ref_zona");

                entity.Property(e => e.Libres).HasColumnName("libres");

                entity.Property(e => e.Precio).HasColumnName("precio");
            });

            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.HasKey(e => e.CodCalendario)
                    .HasName("PK__Calendario__3C69FB99");

                entity.Property(e => e.CodCalendario).HasColumnName("cod_calendario");

                entity.Property(e => e.CodCompeticion).HasColumnName("cod_Competicion");

                entity.Property(e => e.CodLocal).HasColumnName("cod_Local");

                entity.Property(e => e.CodVisitante).HasColumnName("cod_Visitante");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Jornada)
                    .IsRequired()
                    .HasColumnName("jornada")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Cambio>(entity =>
            {
                entity.HasKey(e => e.CodCambio)
                    .HasName("PK__Cambio__2F10007B");

                entity.Property(e => e.CodCambio).HasColumnName("Cod_Cambio");

                entity.Property(e => e.CodJugadorEntra).HasColumnName("Cod_Jugador_Entra");

                entity.Property(e => e.CodJugadorSale).HasColumnName("Cod_Jugador_Sale");

                entity.Property(e => e.CodPartido).HasColumnName("Cod_Partido");

                entity.HasOne(d => d.CodJugadorEntraNavigation)
                    .WithMany(p => p.CambioCodJugadorEntraNavigation)
                    .HasForeignKey(d => d.CodJugadorEntra)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Cambio__Cod_Juga__30F848ED");

                entity.HasOne(d => d.CodJugadorSaleNavigation)
                    .WithMany(p => p.CambioCodJugadorSaleNavigation)
                    .HasForeignKey(d => d.CodJugadorSale)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Cambio__Cod_Juga__31EC6D26");

                entity.HasOne(d => d.CodPartidoNavigation)
                    .WithMany(p => p.Cambio)
                    .HasForeignKey(d => d.CodPartido)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Cambio__Cod_Part__300424B4");
            });

            modelBuilder.Entity<Clasificacion>(entity =>
            {
                entity.HasKey(e => new { e.CodCompeticion, e.Jornada, e.CodEquipo, e.Posicion })
                    .HasName("PK__Clasificacion__33D4B598");

                entity.Property(e => e.CodCompeticion).HasColumnName("Cod_Competicion");

                entity.Property(e => e.Jornada).HasColumnName("jornada");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.Property(e => e.Posicion).HasColumnName("posicion");

                entity.Property(e => e.Empatados).HasColumnName("empatados");

                entity.Property(e => e.Ganados).HasColumnName("ganados");

                entity.Property(e => e.GolesContra).HasColumnName("goles_contra");

                entity.Property(e => e.GolesFavor).HasColumnName("goles_favor");

                entity.Property(e => e.Perdidos).HasColumnName("perdidos");

                entity.Property(e => e.Puntos).HasColumnName("puntos");

                entity.HasOne(d => d.CodCompeticionNavigation)
                    .WithMany(p => p.Clasificacion)
                    .HasForeignKey(d => d.CodCompeticion)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Clasifica__Cod_C__34C8D9D1");

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.Clasificacion)
                    .HasForeignKey(d => d.CodEquipo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Clasifica__Cod_E__35BCFE0A");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.CodComentario)
                    .HasName("PK__Comentario__403A8C7D");

                entity.Property(e => e.CodComentario).HasColumnName("Cod_Comentario");

                entity.Property(e => e.Autor)
                    .HasColumnName("autor")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.CodNoticia).HasColumnName("cod_Noticia");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Texto)
                    .HasColumnName("texto")
                    .HasColumnType("text");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<Competicion>(entity =>
            {
                entity.HasKey(e => e.CodCompeticion)
                    .HasName("PK__Competicion__1920BF5C");

                entity.Property(e => e.CodCompeticion).HasColumnName("Cod_Competicion");

                entity.Property(e => e.Campeon).HasColumnType("varchar(20)");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("Fecha_Fin")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("Fecha_Inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Temporada)
                    .IsRequired()
                    .HasColumnName("temporada")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => new { e.CountryCode, e.LanguageCode })
                    .HasName("PK_Countries");

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.LanguageCode)
                    .HasColumnName("languageCode")
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("countryName")
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.LanguageCodeNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.LanguageCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Languages");
            });

            modelBuilder.Entity<Directivo>(entity =>
            {
                entity.HasKey(e => new { e.CodIntegrante, e.CodEquipo, e.VersionIntegrante })
                    .HasName("PK__Directivo__0AD2A005");

                entity.Property(e => e.CodIntegrante).HasColumnName("Cod_Integrante");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.Property(e => e.VersionIntegrante).HasColumnName("Version_Integrante");

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.CodDirectivo)
                    .HasColumnName("Cod_Directivo")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Profesion).HasColumnType("varchar(20)");

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.Directivo)
                    .HasForeignKey(d => d.CodEquipo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Directivo__Cod_E__0BC6C43E");
            });

            modelBuilder.Entity<Entrenador>(entity =>
            {
                entity.HasKey(e => new { e.CodIntegrante, e.CodEquipo, e.VersionIntegrante })
                    .HasName("PK__Entrenador__07F6335A");

                entity.Property(e => e.CodIntegrante).HasColumnName("Cod_Integrante");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.Property(e => e.VersionIntegrante).HasColumnName("Version_Integrante");

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CodEntrenador)
                    .HasColumnName("Cod_Entrenador")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FechaProfesional)
                    .HasColumnName("Fecha_Profesional")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.Entrenador)
                    .HasForeignKey(d => d.CodEquipo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Entrenado__Cod_E__08EA5793");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.CodEquipo)
                    .HasName("PK__Equipo__7E6CC920");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.Property(e => e.CodEstadio).HasColumnName("Cod_Estadio");

                entity.Property(e => e.FotoEscudo)
                    .HasColumnName("Foto_Escudo")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.FotoPlantilla)
                    .HasColumnName("Foto_Plantilla")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Localidad).HasColumnType("varchar(20)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<EquiposParticipan>(entity =>
            {
                entity.HasKey(e => new { e.CodCompeticion, e.CodEquipo })
                    .HasName("PK__EquiposParticipa__37A5467C");

                entity.Property(e => e.CodCompeticion).HasColumnName("Cod_Competicion");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.EquiposParticipan)
                    .HasForeignKey(d => d.CodEquipo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__EquiposPa__Cod_E__38996AB5");
            });

            modelBuilder.Entity<Estadio>(entity =>
            {
                entity.HasKey(e => e.CodEstadio)
                    .HasName("PK__Estadio__173876EA");

                entity.Property(e => e.CodEstadio).HasColumnName("Cod_Estadio");

                entity.Property(e => e.Direccion).HasColumnType("varchar(100)");

                entity.Property(e => e.Foto).HasColumnType("varchar(50)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(30)");

                entity.Property(e => e.Tipo).HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Gol>(entity =>
            {
                entity.HasKey(e => e.CodGol)
                    .HasName("PK__Gol__276EDEB3");

                entity.Property(e => e.CodGol).HasColumnName("Cod_Gol");

                entity.Property(e => e.CodJugador).HasColumnName("Cod_Jugador");

                entity.Property(e => e.CodPartido).HasColumnName("Cod_Partido");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Video)
                    .HasColumnName("video")
                    .HasColumnType("text");

                entity.HasOne(d => d.CodJugadorNavigation)
                    .WithMany(p => p.Gol)
                    .HasForeignKey(d => d.CodJugador)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Gol__Cod_Jugador__29572725");

                entity.HasOne(d => d.CodPartidoNavigation)
                    .WithMany(p => p.Gol)
                    .HasForeignKey(d => d.CodPartido)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Gol__Cod_Partido__286302EC");
            });

            modelBuilder.Entity<HcoIntegrante>(entity =>
            {
                entity.HasKey(e => new { e.CodIntegrante, e.CodEquipo, e.VersionIntegrante })
                    .HasName("PK__Hco_Integrante__00551192");

                entity.ToTable("Hco_Integrante");

                entity.Property(e => e.CodIntegrante).HasColumnName("Cod_Integrante");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.Property(e => e.VersionIntegrante).HasColumnName("Version_Integrante");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("Fecha_Fin")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaFinContrato)
                    .HasColumnName("Fecha_Fin_Contrato")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("Fecha_Inicio")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.HcoIntegrante)
                    .HasForeignKey(d => d.CodEquipo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Hco_Integ__Cod_E__023D5A04");

                entity.HasOne(d => d.CodIntegranteNavigation)
                    .WithMany(p => p.HcoIntegrante)
                    .HasForeignKey(d => d.CodIntegrante)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Hco_Integ__Cod_I__014935CB");
            });

            modelBuilder.Entity<Integrante>(entity =>
            {
                entity.HasKey(e => e.CodInt)
                    .HasName("PK__Integrante__7C8480AE");

                entity.Property(e => e.CodInt)
                    .HasColumnName("Cod_Int")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.FechaNac)
                    .HasColumnName("Fecha_Nac")
                    .HasColumnType("datetime");

                entity.Property(e => e.Foto).HasColumnType("varchar(50)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.HasKey(e => e.CodJugador)
                    .HasName("PK__Jugador__108B795B");

                entity.Property(e => e.CodJugador).HasColumnName("Cod_Jugador");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.Property(e => e.CodIntegrante).HasColumnName("Cod_Integrante");

                entity.Property(e => e.Pierna).HasColumnType("varchar(10)");

                entity.Property(e => e.Posicion)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.VersionIntegrante).HasColumnName("Version_Integrante");

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.Jugador)
                    .HasForeignKey(d => d.CodEquipo)
                    .HasConstraintName("FK__Jugador__Cod_Equ__117F9D94");

                entity.HasOne(d => d.CodIntegranteNavigation)
                    .WithMany(p => p.Jugador)
                    .HasForeignKey(d => d.CodIntegrante)
                    .HasConstraintName("FK_Jugador_Integrante");
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.HasKey(e => e.LanguageCode)
                    .HasName("PK_Languages");

                entity.Property(e => e.LanguageCode)
                    .HasColumnName("languageCode")
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasColumnName("languageName")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<LineaPedido>(entity =>
            {
                entity.HasKey(e => new { e.Idpedido, e.Idlinea })
                    .HasName("PK__LineaPedido__5535A963");

                entity.Property(e => e.Idpedido).HasColumnName("idpedido");

                entity.Property(e => e.Idlinea).HasColumnName("idlinea");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Disp).HasColumnName("disp");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Pvp).HasColumnName("pvp");

                entity.HasOne(d => d.IdpedidoNavigation)
                    .WithMany(p => p.LineaPedido)
                    .HasForeignKey(d => d.Idpedido)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__LineaPedi__idped__5629CD9C");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.CodMedico)
                    .HasName("PK__Medico__0DAF0CB0");

                entity.Property(e => e.CodMedico).HasColumnName("Cod_Medico");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.Property(e => e.CodIntegrante).HasColumnName("Cod_Integrante");

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.FechaProfesional)
                    .HasColumnName("Fecha_Profesional")
                    .HasColumnType("datetime");

                entity.Property(e => e.VersionIntegrante).HasColumnName("Version_Integrante");

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.Medico)
                    .HasForeignKey(d => d.CodEquipo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Medico__Cod_Equi__0EA330E9");
            });

            modelBuilder.Entity<Noticia>(entity =>
            {
                entity.HasKey(e => e.CodNoticia)
                    .HasName("PK__Noticia__3A81B327");

                entity.Property(e => e.CodNoticia).HasColumnName("Cod_Noticia");

                entity.Property(e => e.Autor)
                    .HasColumnName("autor")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.CodPartido).HasColumnName("cod_Partido");

                entity.Property(e => e.Cuerpo).HasColumnType("text");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasColumnType("text");

                entity.Property(e => e.Resumen).HasColumnType("text");

                entity.Property(e => e.SubCategoria).HasColumnType("varchar(30)");

                entity.Property(e => e.Titulo).HasColumnType("text");
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.HasKey(e => e.CodPartido)
                    .HasName("PK__Partido__1CF15040");

                entity.Property(e => e.CodPartido).HasColumnName("Cod_Partido");

                entity.Property(e => e.Clima).HasColumnType("varchar(10)");

                entity.Property(e => e.CodArbitro).HasColumnName("Cod_Arbitro");

                entity.Property(e => e.CodCompeticion).HasColumnName("Cod_Competicion");

                entity.Property(e => e.CodEstadio).HasColumnName("Cod_Estadio");

                entity.Property(e => e.CodLocal).HasColumnName("Cod_Local");

                entity.Property(e => e.CodVisitante).HasColumnName("Cod_Visitante");

                entity.Property(e => e.CornersLocal).HasColumnName("Corners_Local");

                entity.Property(e => e.CornersVisitante).HasColumnName("Corners_Visitante");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FuerasJuegoLocal).HasColumnName("Fueras_Juego_Local");

                entity.Property(e => e.FuerasJuegoVisitante).HasColumnName("Fueras_Juego_Visitante");

                entity.Property(e => e.GolesLocal).HasColumnName("Goles_Local");

                entity.Property(e => e.GolesVisitante).HasColumnName("Goles_Visitante");

                entity.Property(e => e.Jornada).HasColumnType("varchar(10)");

                entity.Property(e => e.PosesionLocal).HasColumnName("Posesion_Local");

                entity.Property(e => e.PosesionVisitante).HasColumnName("Posesion_Visitante");

                entity.HasOne(d => d.CodArbitroNavigation)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.CodArbitro)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Partido__Cod_Arb__20C1E124");

                entity.HasOne(d => d.CodCompeticionNavigation)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.CodCompeticion)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Partido__Cod_Com__1DE57479");

                entity.HasOne(d => d.CodEstadioNavigation)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.CodEstadio)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Partido__Cod_Est__21B6055D");

                entity.HasOne(d => d.CodLocalNavigation)
                    .WithMany(p => p.PartidoCodLocalNavigation)
                    .HasForeignKey(d => d.CodLocal)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Partido__Cod_Loc__1ED998B2");

                entity.HasOne(d => d.CodVisitanteNavigation)
                    .WithMany(p => p.PartidoCodVisitanteNavigation)
                    .HasForeignKey(d => d.CodVisitante)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Partido__Cod_Vis__1FCDBCEB");
            });

            modelBuilder.Entity<PartidoJugado>(entity =>
            {
                entity.HasKey(e => new { e.CodJugador, e.CodPartido })
                    .HasName("PK__Partido_Jugado__239E4DCF");

                entity.ToTable("Partido_Jugado");

                entity.Property(e => e.CodJugador).HasColumnName("Cod_Jugador");

                entity.Property(e => e.CodPartido).HasColumnName("Cod_Partido");

                entity.Property(e => e.AsistenciasGol).HasColumnName("Asistencias_Gol");

                entity.Property(e => e.BalonesPerdidos).HasColumnName("balones_perdidos");

                entity.Property(e => e.BalonesRecuperados).HasColumnName("balones_recuperados");

                entity.Property(e => e.Corners).HasColumnName("corners");

                entity.Property(e => e.FaltasCometidas).HasColumnName("Faltas_Cometidas");

                entity.Property(e => e.FaltasRecibidas).HasColumnName("Faltas_Recibidas");

                entity.Property(e => e.FuerasJuego).HasColumnName("fueras_Juego");

                entity.Property(e => e.PenaltisCometidos).HasColumnName("penaltis_cometidos");

                entity.Property(e => e.PenaltisRecibidos).HasColumnName("penaltis_recibidos");

                entity.Property(e => e.Remates).HasColumnName("remates");

                entity.Property(e => e.RematesPorteria).HasColumnName("remates_Porteria");

                entity.Property(e => e.RematesPoste).HasColumnName("remates_Poste");

                entity.Property(e => e.TarjetasAmarillasProvocadas).HasColumnName("tarjetas_Amarillas_Provocadas");

                entity.Property(e => e.TarjetasRojasProvocadas).HasColumnName("tarjetas_Rojas_Provocadas");

                entity.Property(e => e.Titular)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.HasOne(d => d.CodJugadorNavigation)
                    .WithMany(p => p.PartidoJugado)
                    .HasForeignKey(d => d.CodJugador)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Partido_J__Cod_J__24927208");

                entity.HasOne(d => d.CodPartidoNavigation)
                    .WithMany(p => p.PartidoJugado)
                    .HasForeignKey(d => d.CodPartido)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Partido_J__Cod_P__25869641");
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__pedidos__52593CB8");

                entity.ToTable("pedidos");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasColumnName("calle")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Cp).HasColumnName("cp");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasColumnType("varchar(10)")
                    .HasDefaultValueSql("'Pendiente'");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechatarjeta)
                    .HasColumnName("fechatarjeta")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Puerta)
                    .HasColumnName("puerta")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Tarjeta)
                    .IsRequired()
                    .HasColumnName("tarjeta")
                    .HasColumnType("varchar(17)");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__Producto__5070F446");

                entity.Property(e => e.ProdId).HasColumnName("prodId");

                entity.Property(e => e.Categoria)
                    .HasColumnName("categoria")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("text");

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fechaAlta")
                    .HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(e => e.CodTarjeta)
                    .HasName("PK__Tarjeta__2B3F6F97");

                entity.Property(e => e.CodTarjeta).HasColumnName("Cod_Tarjeta");

                entity.Property(e => e.CodJugador).HasColumnName("Cod_Jugador");

                entity.Property(e => e.CodPartido).HasColumnName("Cod_Partido");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.HasOne(d => d.CodJugadorNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.CodJugador)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Tarjeta__Cod_Jug__2D27B809");

                entity.HasOne(d => d.CodPartidoNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.CodPartido)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Tarjeta__Cod_Par__2C3393D0");
            });

            modelBuilder.Entity<Transpaso>(entity =>
            {
                entity.HasKey(e => e.CodTranspaso)
                    .HasName("PK__Transpaso__0425A276");

                entity.Property(e => e.CodTranspaso).HasColumnName("Cod_Transpaso");

                entity.Property(e => e.CodEquipoDestino).HasColumnName("Cod_Equipo_Destino");

                entity.Property(e => e.CodEquipoOrigen).HasColumnName("Cod_Equipo_Origen");

                entity.Property(e => e.CodIntegrante).HasColumnName("Cod_Integrante");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.CodEquipoDestinoNavigation)
                    .WithMany(p => p.TranspasoCodEquipoDestinoNavigation)
                    .HasForeignKey(d => d.CodEquipoDestino)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Transpaso__Cod_E__060DEAE8");

                entity.HasOne(d => d.CodEquipoOrigenNavigation)
                    .WithMany(p => p.TranspasoCodEquipoOrigenNavigation)
                    .HasForeignKey(d => d.CodEquipoOrigen)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Transpaso__Cod_E__0519C6AF");
            });

            modelBuilder.Entity<Trata>(entity =>
            {
                entity.HasKey(e => e.CodTratamiento)
                    .HasName("PK__Trata__1367E606");

                entity.Property(e => e.CodTratamiento).HasColumnName("Cod_Tratamiento");

                entity.Property(e => e.CodJugador).HasColumnName("Cod_Jugador");

                entity.Property(e => e.CodMedico).HasColumnName("Cod_Medico");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("Fecha_Fin")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("Fecha_Inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lesion).HasColumnType("varchar(20)");

                entity.HasOne(d => d.CodJugadorNavigation)
                    .WithMany(p => p.Trata)
                    .HasForeignKey(d => d.CodJugador)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Trata__Cod_Jugad__15502E78");

                entity.HasOne(d => d.CodMedicoNavigation)
                    .WithMany(p => p.Trata)
                    .HasForeignKey(d => d.CodMedico)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Trata__Cod_Medic__145C0A3F");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.LoginName)
                    .HasName("PK_UserProfile");

                entity.Property(e => e.LoginName)
                    .HasColumnName("loginName")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Cp).HasColumnName("cp");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.EnPassword)
                    .IsRequired()
                    .HasColumnName("enPassword")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FechaTarjeta)
                    .HasColumnName("fechaTarjeta")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasColumnName("language")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.Localidad)
                    .HasColumnName("localidad")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.Tarjeta)
                    .HasColumnName("tarjeta")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<ZonaEstadio>(entity =>
            {
                entity.HasKey(e => e.IdZona)
                    .HasName("PK__zonaEstadio__4AB81AF0");

                entity.ToTable("zonaEstadio");

                entity.Property(e => e.IdZona).HasColumnName("id_zona");

                entity.Property(e => e.Capacidad).HasColumnName("capacidad");

                entity.Property(e => e.Cubierto)
                    .HasColumnName("cubierto")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(20)");
            });
        }
    }
}