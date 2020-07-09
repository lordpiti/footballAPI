using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Football.DataAccessEFCore3.Models
{
    public partial class FootballContext : DbContext
    {
        public FootballContext()
        {
        }

        public FootballContext(DbContextOptions<FootballContext> options)
            : base(options)
        {
        }

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
        public virtual DbSet<GlobalMedia> GlobalMedia { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abono>(entity =>
            {
                entity.HasKey(e => e.IdAbono)
                    .HasName("PK__abono__1E6B9583BC7B6591");

                entity.ToTable("abono");

                entity.HasIndex(e => new { e.LoginName, e.CodCompeticion })
                    .HasName("UQ__abono__4A62EF7D0F85E508")
                    .IsUnique();

                entity.Property(e => e.IdAbono).HasColumnName("id_abono");

                entity.Property(e => e.CodCompeticion).HasColumnName("cod_competicion");

                entity.Property(e => e.CodZona).HasColumnName("cod_zona");

                entity.Property(e => e.LoginName)
                    .HasColumnName("loginName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodZonaNavigation)
                    .WithMany(p => p.Abono)
                    .HasForeignKey(d => d.CodZona)
                    .HasConstraintName("FK__abono__cod_zona__06CD04F7");
            });

            modelBuilder.Entity<Agenda>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__agenda__AF150CA507B5EB6B");

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
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Arbitro>(entity =>
            {
                entity.HasKey(e => e.CodArbitro)
                    .HasName("PK__Arbitro__C117B4EE6864E33C");

                entity.Property(e => e.CodArbitro).HasColumnName("Cod_Arbitro");

                entity.Property(e => e.AnosActivo).HasColumnName("Anos_Activo");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Colegio)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Asiento>(entity =>
            {
                entity.HasKey(e => new { e.CodCompeticion, e.RefZona })
                    .HasName("PK__asiento__2DDFBB74B7935AF9");

                entity.ToTable("asiento");

                entity.Property(e => e.CodCompeticion).HasColumnName("cod_competicion");

                entity.Property(e => e.RefZona).HasColumnName("ref_zona");

                entity.Property(e => e.Libres).HasColumnName("libres");

                entity.Property(e => e.Precio).HasColumnName("precio");
            });

            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.HasKey(e => e.CodCalendario)
                    .HasName("PK__Calendar__C0C368B419E86DF6");

                entity.HasIndex(e => e.MatchCodPartido);

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
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.MatchCodPartidoNavigation)
                    .WithMany(p => p.Calendario)
                    .HasForeignKey(d => d.MatchCodPartido);
            });

            modelBuilder.Entity<Cambio>(entity =>
            {
                entity.HasKey(e => e.CodCambio)
                    .HasName("PK__Cambio__82EA1AC42870933A");

                entity.Property(e => e.CodCambio).HasColumnName("Cod_Cambio");

                entity.Property(e => e.CodJugadorEntra).HasColumnName("Cod_Jugador_Entra");

                entity.Property(e => e.CodJugadorSale).HasColumnName("Cod_Jugador_Sale");

                entity.Property(e => e.CodPartido).HasColumnName("Cod_Partido");

                entity.HasOne(d => d.CodJugadorEntraNavigation)
                    .WithMany(p => p.CambioCodJugadorEntraNavigation)
                    .HasForeignKey(d => d.CodJugadorEntra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cambio__Cod_Juga__08B54D69");

                entity.HasOne(d => d.CodJugadorSaleNavigation)
                    .WithMany(p => p.CambioCodJugadorSaleNavigation)
                    .HasForeignKey(d => d.CodJugadorSale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cambio__Cod_Juga__09A971A2");

                entity.HasOne(d => d.CodPartidoNavigation)
                    .WithMany(p => p.Cambio)
                    .HasForeignKey(d => d.CodPartido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cambio__Cod_Part__07C12930");
            });

            modelBuilder.Entity<Clasificacion>(entity =>
            {
                entity.HasKey(e => new { e.CodCompeticion, e.Jornada, e.CodEquipo, e.Posicion })
                    .HasName("PK__Clasific__38DD26DC8262AF4E");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clasifica__Cod_C__0A9D95DB");

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.Clasificacion)
                    .HasForeignKey(d => d.CodEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clasifica__Cod_E__0B91BA14");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.CodComentario)
                    .HasName("PK__Comentar__A48D582F2347E01F");

                entity.Property(e => e.CodComentario).HasColumnName("Cod_Comentario");

                entity.Property(e => e.Autor)
                    .HasColumnName("autor")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CodNoticia).HasColumnName("cod_Noticia");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Texto)
                    .HasColumnName("texto")
                    .HasColumnType("text");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Competicion>(entity =>
            {
                entity.HasKey(e => e.CodCompeticion)
                    .HasName("PK__Competic__EFAD7B6AC59DC2E9");

                entity.HasIndex(e => e.CompetitionLogoGlobalMediaId);

                entity.Property(e => e.CodCompeticion).HasColumnName("Cod_Competicion");

                entity.Property(e => e.Campeon)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFin)
                    .HasColumnName("Fecha_Fin")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("Fecha_Inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Temporada)
                    .IsRequired()
                    .HasColumnName("temporada")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompetitionLogoGlobalMedia)
                    .WithMany(p => p.Competicion)
                    .HasForeignKey(d => d.CompetitionLogoGlobalMediaId);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => new { e.CountryCode, e.LanguageCode });

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.LanguageCode)
                    .HasColumnName("languageCode")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("countryName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LanguageCodeNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.LanguageCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Languages");
            });

            modelBuilder.Entity<Directivo>(entity =>
            {
                entity.HasKey(e => new { e.CodIntegrante, e.CodEquipo, e.VersionIntegrante })
                    .HasName("PK__Directiv__80B369C491BE850F");

                entity.Property(e => e.CodIntegrante).HasColumnName("Cod_Integrante");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.Property(e => e.VersionIntegrante).HasColumnName("Version_Integrante");

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodDirectivo)
                    .HasColumnName("Cod_Directivo")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Profesion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.Directivo)
                    .HasForeignKey(d => d.CodEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Directivo__Cod_E__0D7A0286");
            });

            modelBuilder.Entity<Entrenador>(entity =>
            {
                entity.HasKey(e => new { e.CodIntegrante, e.CodEquipo, e.VersionIntegrante })
                    .HasName("PK__Entrenad__80B369C4C98831BD");

                entity.Property(e => e.CodIntegrante).HasColumnName("Cod_Integrante");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.Property(e => e.VersionIntegrante).HasColumnName("Version_Integrante");

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CodEntrenador)
                    .HasColumnName("Cod_Entrenador")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FechaProfesional)
                    .HasColumnName("Fecha_Profesional")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.Entrenador)
                    .HasForeignKey(d => d.CodEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Entrenado__Cod_E__0E6E26BF");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.CodEquipo)
                    .HasName("PK__Equipo__FE190172A303E7EF");

                entity.HasIndex(e => e.CodEstadio);

                entity.HasIndex(e => e.TeamPictureGlobalMediaId);

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.Property(e => e.CodEstadio).HasColumnName("Cod_Estadio");

                entity.Property(e => e.FotoEscudo).HasColumnName("Foto_Escudo");

                entity.Property(e => e.FotoPlantilla).HasColumnName("Foto_Plantilla");

                entity.Property(e => e.Localidad)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodEstadioNavigation)
                    .WithMany(p => p.Equipo)
                    .HasForeignKey(d => d.CodEstadio);

                entity.HasOne(d => d.TeamPictureGlobalMedia)
                    .WithMany(p => p.Equipo)
                    .HasForeignKey(d => d.TeamPictureGlobalMediaId);
            });

            modelBuilder.Entity<EquiposParticipan>(entity =>
            {
                entity.HasKey(e => new { e.CodCompeticion, e.CodEquipo })
                    .HasName("PK__EquiposP__D04CEB7DEB21C6E3");

                entity.Property(e => e.CodCompeticion).HasColumnName("Cod_Competicion");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.HasOne(d => d.CodCompeticionNavigation)
                    .WithMany(p => p.EquiposParticipan)
                    .HasForeignKey(d => d.CodCompeticion);

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.EquiposParticipan)
                    .HasForeignKey(d => d.CodEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EquiposPa__Cod_E__0F624AF8");
            });

            modelBuilder.Entity<Estadio>(entity =>
            {
                entity.HasKey(e => e.CodEstadio)
                    .HasName("PK__Estadio__7517D2A58A94C613");

                entity.HasIndex(e => e.PictureGlobalMediaId);

                entity.Property(e => e.CodEstadio).HasColumnName("Cod_Estadio");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PictureGlobalMedia)
                    .WithMany(p => p.Estadio)
                    .HasForeignKey(d => d.PictureGlobalMediaId);
            });

            modelBuilder.Entity<Gol>(entity =>
            {
                entity.HasKey(e => e.CodGol)
                    .HasName("PK__Gol__0604040C0A22D869");

                entity.Property(e => e.CodGol).HasColumnName("Cod_Gol");

                entity.Property(e => e.CodJugador).HasColumnName("Cod_Jugador");

                entity.Property(e => e.CodPartido).HasColumnName("Cod_Partido");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Video)
                    .HasColumnName("video")
                    .HasColumnType("text");

                entity.HasOne(d => d.CodJugadorNavigation)
                    .WithMany(p => p.Gol)
                    .HasForeignKey(d => d.CodJugador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Gol__Cod_Jugador__114A936A");

                entity.HasOne(d => d.CodPartidoNavigation)
                    .WithMany(p => p.Gol)
                    .HasForeignKey(d => d.CodPartido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Gol__Cod_Partido__10566F31");
            });

            modelBuilder.Entity<HcoIntegrante>(entity =>
            {
                entity.HasKey(e => new { e.CodIntegrante, e.CodEquipo, e.VersionIntegrante })
                    .HasName("PK__Hco_Inte__80B369C4638A5B22");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Hco_Integ__Cod_E__1332DBDC");

                entity.HasOne(d => d.CodIntegranteNavigation)
                    .WithMany(p => p.HcoIntegrante)
                    .HasForeignKey(d => d.CodIntegrante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Hco_Integ__Cod_I__123EB7A3");
            });

            modelBuilder.Entity<Integrante>(entity =>
            {
                entity.HasKey(e => e.CodInt)
                    .HasName("PK__Integran__0488816542B2EB29");

                entity.HasIndex(e => e.PictureGlobalMediaId);

                entity.Property(e => e.CodInt)
                    .HasColumnName("Cod_Int")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNac)
                    .HasColumnName("Fecha_Nac")
                    .HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PictureGlobalMedia)
                    .WithMany(p => p.Integrante)
                    .HasForeignKey(d => d.PictureGlobalMediaId);
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.HasKey(e => e.CodJugador)
                    .HasName("PK__Jugador__311588804F56E76B");

                entity.Property(e => e.CodJugador).HasColumnName("Cod_Jugador");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.Property(e => e.CodIntegrante).HasColumnName("Cod_Integrante");

                entity.Property(e => e.Pierna)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Posicion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VersionIntegrante).HasColumnName("Version_Integrante");

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.Jugador)
                    .HasForeignKey(d => d.CodEquipo)
                    .HasConstraintName("FK__Jugador__Cod_Equ__14270015");

                entity.HasOne(d => d.CodIntegranteNavigation)
                    .WithMany(p => p.Jugador)
                    .HasForeignKey(d => d.CodIntegrante)
                    .HasConstraintName("FK_Jugador_Integrante");
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.HasKey(e => e.LanguageCode);

                entity.Property(e => e.LanguageCode)
                    .HasColumnName("languageCode")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasColumnName("languageName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LineaPedido>(entity =>
            {
                entity.HasKey(e => new { e.Idpedido, e.Idlinea })
                    .HasName("PK__LineaPed__3565A2260C680D70");

                entity.Property(e => e.Idpedido).HasColumnName("idpedido");

                entity.Property(e => e.Idlinea).HasColumnName("idlinea");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Disp).HasColumnName("disp");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Pvp).HasColumnName("pvp");

                entity.HasOne(d => d.IdpedidoNavigation)
                    .WithMany(p => p.LineaPedido)
                    .HasForeignKey(d => d.Idpedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineaPedi__idped__160F4887");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.CodMedico)
                    .HasName("PK__Medico__18937FE2AD662269");

                entity.Property(e => e.CodMedico).HasColumnName("Cod_Medico");

                entity.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo");

                entity.Property(e => e.CodIntegrante).HasColumnName("Cod_Integrante");

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaProfesional)
                    .HasColumnName("Fecha_Profesional")
                    .HasColumnType("datetime");

                entity.Property(e => e.VersionIntegrante).HasColumnName("Version_Integrante");

                entity.HasOne(d => d.CodEquipoNavigation)
                    .WithMany(p => p.Medico)
                    .HasForeignKey(d => d.CodEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medico__Cod_Equi__17036CC0");
            });

            modelBuilder.Entity<Noticia>(entity =>
            {
                entity.HasKey(e => e.CodNoticia)
                    .HasName("PK__Noticia__A76A776C50E2F9FA");

                entity.Property(e => e.CodNoticia).HasColumnName("Cod_Noticia");

                entity.Property(e => e.Autor)
                    .HasColumnName("autor")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CodPartido).HasColumnName("cod_Partido");

                entity.Property(e => e.Cuerpo).HasColumnType("text");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasColumnType("text");

                entity.Property(e => e.Resumen).HasColumnType("text");

                entity.Property(e => e.SubCategoria)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo).HasColumnType("text");
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.HasKey(e => e.CodPartido)
                    .HasName("PK__Partido__7E512A7A7524CB5D");

                entity.Property(e => e.CodPartido).HasColumnName("Cod_Partido");

                entity.Property(e => e.Clima)
                    .HasMaxLength(10)
                    .IsUnicode(false);

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

                entity.Property(e => e.Jornada)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PosesionLocal).HasColumnName("Posesion_Local");

                entity.Property(e => e.PosesionVisitante).HasColumnName("Posesion_Visitante");

                entity.HasOne(d => d.CodArbitroNavigation)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.CodArbitro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Partido__Cod_Arb__1AD3FDA4");

                entity.HasOne(d => d.CodCompeticionNavigation)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.CodCompeticion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Partido__Cod_Com__17F790F9");

                entity.HasOne(d => d.CodEstadioNavigation)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.CodEstadio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Partido__Cod_Est__1BC821DD");

                entity.HasOne(d => d.CodLocalNavigation)
                    .WithMany(p => p.PartidoCodLocalNavigation)
                    .HasForeignKey(d => d.CodLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Partido__Cod_Loc__18EBB532");

                entity.HasOne(d => d.CodVisitanteNavigation)
                    .WithMany(p => p.PartidoCodVisitanteNavigation)
                    .HasForeignKey(d => d.CodVisitante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Partido__Cod_Vis__19DFD96B");
            });

            modelBuilder.Entity<PartidoJugado>(entity =>
            {
                entity.HasKey(e => new { e.CodJugador, e.CodPartido })
                    .HasName("PK__Partido___86F09A27E3058A54");

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
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodJugadorNavigation)
                    .WithMany(p => p.PartidoJugado)
                    .HasForeignKey(d => d.CodJugador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Partido_J__Cod_J__1CBC4616");

                entity.HasOne(d => d.CodPartidoNavigation)
                    .WithMany(p => p.PartidoJugado)
                    .HasForeignKey(d => d.CodPartido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Partido_J__Cod_P__1DB06A4F");
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__pedidos__A9F619B737664567");

                entity.ToTable("pedidos");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasColumnName("calle")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cp).HasColumnName("cp");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Pendiente')");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechatarjeta)
                    .HasColumnName("fechatarjeta")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Puerta)
                    .HasColumnName("puerta")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tarjeta)
                    .IsRequired()
                    .HasColumnName("tarjeta")
                    .HasMaxLength(17)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__Producto__319F67F18283D8BE");

                entity.Property(e => e.ProdId).HasColumnName("prodId");

                entity.Property(e => e.Categoria)
                    .HasColumnName("categoria")
                    .HasMaxLength(20)
                    .IsUnicode(false);

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
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(e => e.CodTarjeta)
                    .HasName("PK__Tarjeta__D5EE15398F60B8AF");

                entity.Property(e => e.CodTarjeta).HasColumnName("Cod_Tarjeta");

                entity.Property(e => e.CodJugador).HasColumnName("Cod_Jugador");

                entity.Property(e => e.CodPartido).HasColumnName("Cod_Partido");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodJugadorNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.CodJugador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tarjeta__Cod_Jug__1F98B2C1");

                entity.HasOne(d => d.CodPartidoNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.CodPartido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tarjeta__Cod_Par__1EA48E88");
            });

            modelBuilder.Entity<Transpaso>(entity =>
            {
                entity.HasKey(e => e.CodTranspaso)
                    .HasName("PK__Transpas__94AB3B39BE7F2969");

                entity.Property(e => e.CodTranspaso).HasColumnName("Cod_Transpaso");

                entity.Property(e => e.CodEquipoDestino).HasColumnName("Cod_Equipo_Destino");

                entity.Property(e => e.CodEquipoOrigen).HasColumnName("Cod_Equipo_Origen");

                entity.Property(e => e.CodIntegrante).HasColumnName("Cod_Integrante");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.CodEquipoDestinoNavigation)
                    .WithMany(p => p.TranspasoCodEquipoDestinoNavigation)
                    .HasForeignKey(d => d.CodEquipoDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transpaso__Cod_E__2180FB33");

                entity.HasOne(d => d.CodEquipoOrigenNavigation)
                    .WithMany(p => p.TranspasoCodEquipoOrigenNavigation)
                    .HasForeignKey(d => d.CodEquipoOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transpaso__Cod_E__208CD6FA");
            });

            modelBuilder.Entity<Trata>(entity =>
            {
                entity.HasKey(e => e.CodTratamiento)
                    .HasName("PK__Trata__17B0DB894F867B70");

                entity.Property(e => e.CodTratamiento).HasColumnName("Cod_Tratamiento");

                entity.Property(e => e.CodJugador).HasColumnName("Cod_Jugador");

                entity.Property(e => e.CodMedico).HasColumnName("Cod_Medico");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("Fecha_Fin")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("Fecha_Inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lesion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodJugadorNavigation)
                    .WithMany(p => p.Trata)
                    .HasForeignKey(d => d.CodJugador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trata__Cod_Jugad__236943A5");

                entity.HasOne(d => d.CodMedicoNavigation)
                    .WithMany(p => p.Trata)
                    .HasForeignKey(d => d.CodMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trata__Cod_Medic__22751F6C");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.LoginName);

                entity.Property(e => e.LoginName)
                    .HasColumnName("loginName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cp).HasColumnName("cp");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.EnPassword)
                    .IsRequired()
                    .HasColumnName("enPassword")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaTarjeta)
                    .HasColumnName("fechaTarjeta")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasColumnName("language")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Localidad)
                    .HasColumnName("localidad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Tarjeta)
                    .HasColumnName("tarjeta")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ZonaEstadio>(entity =>
            {
                entity.HasKey(e => e.IdZona)
                    .HasName("PK__zonaEsta__67C93611F159F2D3");

                entity.ToTable("zonaEstadio");

                entity.Property(e => e.IdZona).HasColumnName("id_zona");

                entity.Property(e => e.Capacidad).HasColumnName("capacidad");

                entity.Property(e => e.Cubierto)
                    .HasColumnName("cubierto")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
