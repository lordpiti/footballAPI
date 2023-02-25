using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Football.DataAccessEFCore3.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agenda",
                columns: table => new
                {
                    id_evento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    cod_calendario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__agenda__AF150CA507B5EB6B", x => x.id_evento);
                });

            migrationBuilder.CreateTable(
                name: "Arbitro",
                columns: table => new
                {
                    Cod_Arbitro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Colegio = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Anos_Activo = table.Column<int>(type: "int", nullable: true),
                    Foto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Arbitro__C117B4EE6864E33C", x => x.Cod_Arbitro);
                });

            migrationBuilder.CreateTable(
                name: "asiento",
                columns: table => new
                {
                    cod_competicion = table.Column<int>(type: "int", nullable: false),
                    ref_zona = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<float>(type: "real", nullable: true),
                    libres = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__asiento__2DDFBB74B7935AF9", x => new { x.cod_competicion, x.ref_zona });
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Cod_Comentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_Noticia = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    texto = table.Column<string>(type: "text", nullable: true),
                    autor = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comentar__A48D582F2347E01F", x => x.Cod_Comentario);
                });

            migrationBuilder.CreateTable(
                name: "GlobalMedia",
                columns: table => new
                {
                    GlobalMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlobStorageContainer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlobStorageReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalMedia", x => x.GlobalMediaId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    languageCode = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false),
                    languageName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.languageCode);
                });

            migrationBuilder.CreateTable(
                name: "Noticia",
                columns: table => new
                {
                    Cod_Noticia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    SubCategoria = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Titulo = table.Column<string>(type: "text", nullable: true),
                    Resumen = table.Column<string>(type: "text", nullable: true),
                    Cuerpo = table.Column<string>(type: "text", nullable: true),
                    cod_Partido = table.Column<int>(type: "int", nullable: true),
                    foto = table.Column<string>(type: "text", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    autor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Noticia__A76A776C50E2F9FA", x => x.Cod_Noticia);
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    idPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    tarjeta = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: false),
                    fechatarjeta = table.Column<DateTime>(type: "datetime", nullable: false),
                    nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    calle = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    puerta = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    cp = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    estado = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false, defaultValueSql: "('Pendiente')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pedidos__A9F619B737664567", x => x.idPedido);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    prodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    precio = table.Column<float>(type: "real", nullable: true),
                    fechaAlta = table.Column<DateTime>(type: "datetime", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: true),
                    categoria = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    foto = table.Column<string>(type: "text", nullable: true),
                    descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__319F67F18283D8BE", x => x.prodId);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    loginName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    enPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    firstName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    surname = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    dni = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    email = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    direccion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    cp = table.Column<int>(type: "int", nullable: true),
                    localidad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    telefono = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tarjeta = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    fechaTarjeta = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    language = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    country = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.loginName);
                });

            migrationBuilder.CreateTable(
                name: "zonaEstadio",
                columns: table => new
                {
                    id_zona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    capacidad = table.Column<int>(type: "int", nullable: true),
                    cubierto = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__zonaEsta__67C93611F159F2D3", x => x.id_zona);
                });

            migrationBuilder.CreateTable(
                name: "Competicion",
                columns: table => new
                {
                    Cod_Competicion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    temporada = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    Fecha_Fin = table.Column<DateTime>(type: "datetime", nullable: true),
                    Campeon = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    foto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    tipo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CompetitionLogoGlobalMediaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Competic__EFAD7B6AC59DC2E9", x => x.Cod_Competicion);
                    table.ForeignKey(
                        name: "FK_Competicion_GlobalMedia_CompetitionLogoGlobalMediaId",
                        column: x => x.CompetitionLogoGlobalMediaId,
                        principalTable: "GlobalMedia",
                        principalColumn: "GlobalMediaId");
                });

            migrationBuilder.CreateTable(
                name: "Estadio",
                columns: table => new
                {
                    Cod_Estadio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Tipo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Foto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PictureGlobalMediaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Estadio__7517D2A58A94C613", x => x.Cod_Estadio);
                    table.ForeignKey(
                        name: "FK_Estadio_GlobalMedia_PictureGlobalMediaId",
                        column: x => x.PictureGlobalMediaId,
                        principalTable: "GlobalMedia",
                        principalColumn: "GlobalMediaId");
                });

            migrationBuilder.CreateTable(
                name: "Integrante",
                columns: table => new
                {
                    Cod_Int = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Fecha_Nac = table.Column<DateTime>(type: "datetime", nullable: true),
                    Foto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PictureGlobalMediaId = table.Column<int>(type: "int", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Integran__0488816542B2EB29", x => x.Cod_Int);
                    table.ForeignKey(
                        name: "FK_Integrante_GlobalMedia_PictureGlobalMediaId",
                        column: x => x.PictureGlobalMediaId,
                        principalTable: "GlobalMedia",
                        principalColumn: "GlobalMediaId");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    countryCode = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false),
                    languageCode = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false),
                    countryName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => new { x.countryCode, x.languageCode });
                    table.ForeignKey(
                        name: "FK_Languages",
                        column: x => x.languageCode,
                        principalTable: "Languages",
                        principalColumn: "languageCode");
                });

            migrationBuilder.CreateTable(
                name: "LineaPedido",
                columns: table => new
                {
                    idpedido = table.Column<int>(type: "int", nullable: false),
                    idlinea = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    pvp = table.Column<float>(type: "real", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    disp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LineaPed__3565A2260C680D70", x => new { x.idpedido, x.idlinea });
                    table.ForeignKey(
                        name: "FK__LineaPedi__idped__160F4887",
                        column: x => x.idpedido,
                        principalTable: "pedidos",
                        principalColumn: "idPedido");
                });

            migrationBuilder.CreateTable(
                name: "abono",
                columns: table => new
                {
                    id_abono = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loginName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    cod_competicion = table.Column<int>(type: "int", nullable: true),
                    cod_zona = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__abono__1E6B9583BC7B6591", x => x.id_abono);
                    table.ForeignKey(
                        name: "FK__abono__cod_zona__06CD04F7",
                        column: x => x.cod_zona,
                        principalTable: "zonaEstadio",
                        principalColumn: "id_zona");
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    Cod_Equipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Localidad = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Cod_Estadio = table.Column<int>(type: "int", nullable: true),
                    Foto_Escudo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto_Plantilla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamPictureGlobalMediaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Equipo__FE190172A303E7EF", x => x.Cod_Equipo);
                    table.ForeignKey(
                        name: "FK_Equipo_Estadio_Cod_Estadio",
                        column: x => x.Cod_Estadio,
                        principalTable: "Estadio",
                        principalColumn: "Cod_Estadio");
                    table.ForeignKey(
                        name: "FK_Equipo_GlobalMedia_TeamPictureGlobalMediaId",
                        column: x => x.TeamPictureGlobalMediaId,
                        principalTable: "GlobalMedia",
                        principalColumn: "GlobalMediaId");
                });

            migrationBuilder.CreateTable(
                name: "Clasificacion",
                columns: table => new
                {
                    Cod_Competicion = table.Column<int>(type: "int", nullable: false),
                    jornada = table.Column<int>(type: "int", nullable: false),
                    Cod_Equipo = table.Column<int>(type: "int", nullable: false),
                    posicion = table.Column<int>(type: "int", nullable: false),
                    ganados = table.Column<int>(type: "int", nullable: true),
                    perdidos = table.Column<int>(type: "int", nullable: true),
                    empatados = table.Column<int>(type: "int", nullable: true),
                    goles_favor = table.Column<int>(type: "int", nullable: true),
                    goles_contra = table.Column<int>(type: "int", nullable: true),
                    puntos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clasific__38DD26DC8262AF4E", x => new { x.Cod_Competicion, x.jornada, x.Cod_Equipo, x.posicion });
                    table.ForeignKey(
                        name: "FK__Clasifica__Cod_C__0A9D95DB",
                        column: x => x.Cod_Competicion,
                        principalTable: "Competicion",
                        principalColumn: "Cod_Competicion");
                    table.ForeignKey(
                        name: "FK__Clasifica__Cod_E__0B91BA14",
                        column: x => x.Cod_Equipo,
                        principalTable: "Equipo",
                        principalColumn: "Cod_Equipo");
                });

            migrationBuilder.CreateTable(
                name: "Directivo",
                columns: table => new
                {
                    Cod_Integrante = table.Column<int>(type: "int", nullable: false),
                    Cod_Equipo = table.Column<int>(type: "int", nullable: false),
                    Version_Integrante = table.Column<int>(type: "int", nullable: false),
                    Cod_Directivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cargo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Profesion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Directiv__80B369C491BE850F", x => new { x.Cod_Integrante, x.Cod_Equipo, x.Version_Integrante });
                    table.ForeignKey(
                        name: "FK__Directivo__Cod_E__0D7A0286",
                        column: x => x.Cod_Equipo,
                        principalTable: "Equipo",
                        principalColumn: "Cod_Equipo");
                });

            migrationBuilder.CreateTable(
                name: "Entrenador",
                columns: table => new
                {
                    Cod_Integrante = table.Column<int>(type: "int", nullable: false),
                    Cod_Equipo = table.Column<int>(type: "int", nullable: false),
                    Version_Integrante = table.Column<int>(type: "int", nullable: false),
                    Cod_Entrenador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cargo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Fecha_Profesional = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Entrenad__80B369C4C98831BD", x => new { x.Cod_Integrante, x.Cod_Equipo, x.Version_Integrante });
                    table.ForeignKey(
                        name: "FK__Entrenado__Cod_E__0E6E26BF",
                        column: x => x.Cod_Equipo,
                        principalTable: "Equipo",
                        principalColumn: "Cod_Equipo");
                });

            migrationBuilder.CreateTable(
                name: "EquiposParticipan",
                columns: table => new
                {
                    Cod_Competicion = table.Column<int>(type: "int", nullable: false),
                    Cod_Equipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EquiposP__D04CEB7DEB21C6E3", x => new { x.Cod_Competicion, x.Cod_Equipo });
                    table.ForeignKey(
                        name: "FK__EquiposPa__Cod_E__0F624AF8",
                        column: x => x.Cod_Equipo,
                        principalTable: "Equipo",
                        principalColumn: "Cod_Equipo");
                    table.ForeignKey(
                        name: "FK_EquiposParticipan_Competicion_Cod_Competicion",
                        column: x => x.Cod_Competicion,
                        principalTable: "Competicion",
                        principalColumn: "Cod_Competicion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hco_Integrante",
                columns: table => new
                {
                    Cod_Integrante = table.Column<int>(type: "int", nullable: false),
                    Cod_Equipo = table.Column<int>(type: "int", nullable: false),
                    Version_Integrante = table.Column<int>(type: "int", nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fecha_Fin = table.Column<DateTime>(type: "datetime", nullable: true),
                    Fecha_Fin_Contrato = table.Column<DateTime>(type: "datetime", nullable: true),
                    Sueldo = table.Column<float>(type: "real", nullable: true),
                    Dorsal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hco_Inte__80B369C4638A5B22", x => new { x.Cod_Integrante, x.Cod_Equipo, x.Version_Integrante });
                    table.ForeignKey(
                        name: "FK__Hco_Integ__Cod_E__1332DBDC",
                        column: x => x.Cod_Equipo,
                        principalTable: "Equipo",
                        principalColumn: "Cod_Equipo");
                    table.ForeignKey(
                        name: "FK__Hco_Integ__Cod_I__123EB7A3",
                        column: x => x.Cod_Integrante,
                        principalTable: "Integrante",
                        principalColumn: "Cod_Int");
                });

            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    Cod_Jugador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Integrante = table.Column<int>(type: "int", nullable: true),
                    Cod_Equipo = table.Column<int>(type: "int", nullable: true),
                    Version_Integrante = table.Column<int>(type: "int", nullable: true),
                    Altura = table.Column<float>(type: "real", nullable: true),
                    Posicion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Pierna = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Married = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Jugador__311588804F56E76B", x => x.Cod_Jugador);
                    table.ForeignKey(
                        name: "FK__Jugador__Cod_Equ__14270015",
                        column: x => x.Cod_Equipo,
                        principalTable: "Equipo",
                        principalColumn: "Cod_Equipo");
                    table.ForeignKey(
                        name: "FK_Jugador_Integrante",
                        column: x => x.Cod_Integrante,
                        principalTable: "Integrante",
                        principalColumn: "Cod_Int");
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Cod_Medico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Integrante = table.Column<int>(type: "int", nullable: false),
                    Cod_Equipo = table.Column<int>(type: "int", nullable: false),
                    Version_Integrante = table.Column<int>(type: "int", nullable: false),
                    Especialidad = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Fecha_Profesional = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Medico__18937FE2AD662269", x => x.Cod_Medico);
                    table.ForeignKey(
                        name: "FK__Medico__Cod_Equi__17036CC0",
                        column: x => x.Cod_Equipo,
                        principalTable: "Equipo",
                        principalColumn: "Cod_Equipo");
                });

            migrationBuilder.CreateTable(
                name: "Partido",
                columns: table => new
                {
                    Cod_Partido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Competicion = table.Column<int>(type: "int", nullable: false),
                    Jornada = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Cod_Local = table.Column<int>(type: "int", nullable: false),
                    Cod_Visitante = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    Clima = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Goles_Local = table.Column<int>(type: "int", nullable: false),
                    Goles_Visitante = table.Column<int>(type: "int", nullable: false),
                    Posesion_Local = table.Column<float>(type: "real", nullable: false),
                    Posesion_Visitante = table.Column<float>(type: "real", nullable: false),
                    Corners_Local = table.Column<int>(type: "int", nullable: false),
                    Corners_Visitante = table.Column<int>(type: "int", nullable: false),
                    Fueras_Juego_Local = table.Column<int>(type: "int", nullable: false),
                    Fueras_Juego_Visitante = table.Column<int>(type: "int", nullable: false),
                    Asistencia = table.Column<int>(type: "int", nullable: true),
                    Cod_Arbitro = table.Column<int>(type: "int", nullable: false),
                    Cod_Estadio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Partido__7E512A7A7524CB5D", x => x.Cod_Partido);
                    table.ForeignKey(
                        name: "FK__Partido__Cod_Arb__1AD3FDA4",
                        column: x => x.Cod_Arbitro,
                        principalTable: "Arbitro",
                        principalColumn: "Cod_Arbitro");
                    table.ForeignKey(
                        name: "FK__Partido__Cod_Com__17F790F9",
                        column: x => x.Cod_Competicion,
                        principalTable: "Competicion",
                        principalColumn: "Cod_Competicion");
                    table.ForeignKey(
                        name: "FK__Partido__Cod_Est__1BC821DD",
                        column: x => x.Cod_Estadio,
                        principalTable: "Estadio",
                        principalColumn: "Cod_Estadio");
                    table.ForeignKey(
                        name: "FK__Partido__Cod_Loc__18EBB532",
                        column: x => x.Cod_Local,
                        principalTable: "Equipo",
                        principalColumn: "Cod_Equipo");
                    table.ForeignKey(
                        name: "FK__Partido__Cod_Vis__19DFD96B",
                        column: x => x.Cod_Visitante,
                        principalTable: "Equipo",
                        principalColumn: "Cod_Equipo");
                });

            migrationBuilder.CreateTable(
                name: "Transpaso",
                columns: table => new
                {
                    Cod_Transpaso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Integrante = table.Column<int>(type: "int", nullable: false),
                    Cod_Equipo_Origen = table.Column<int>(type: "int", nullable: false),
                    Cod_Equipo_Destino = table.Column<int>(type: "int", nullable: false),
                    Coste = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transpas__94AB3B39BE7F2969", x => x.Cod_Transpaso);
                    table.ForeignKey(
                        name: "FK__Transpaso__Cod_E__208CD6FA",
                        column: x => x.Cod_Equipo_Origen,
                        principalTable: "Equipo",
                        principalColumn: "Cod_Equipo");
                    table.ForeignKey(
                        name: "FK__Transpaso__Cod_E__2180FB33",
                        column: x => x.Cod_Equipo_Destino,
                        principalTable: "Equipo",
                        principalColumn: "Cod_Equipo");
                });

            migrationBuilder.CreateTable(
                name: "Trata",
                columns: table => new
                {
                    Cod_Tratamiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Medico = table.Column<int>(type: "int", nullable: false),
                    Cod_Jugador = table.Column<int>(type: "int", nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fecha_Fin = table.Column<DateTime>(type: "datetime", nullable: true),
                    Lesion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trata__17B0DB894F867B70", x => x.Cod_Tratamiento);
                    table.ForeignKey(
                        name: "FK__Trata__Cod_Jugad__236943A5",
                        column: x => x.Cod_Jugador,
                        principalTable: "Jugador",
                        principalColumn: "Cod_Jugador");
                    table.ForeignKey(
                        name: "FK__Trata__Cod_Medic__22751F6C",
                        column: x => x.Cod_Medico,
                        principalTable: "Medico",
                        principalColumn: "Cod_Medico");
                });

            migrationBuilder.CreateTable(
                name: "Calendario",
                columns: table => new
                {
                    cod_calendario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_Competicion = table.Column<int>(type: "int", nullable: false),
                    jornada = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    cod_Local = table.Column<int>(type: "int", nullable: false),
                    cod_Visitante = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    MatchCodPartido = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Calendar__C0C368B419E86DF6", x => x.cod_calendario);
                    table.ForeignKey(
                        name: "FK_Calendario_Partido_MatchCodPartido",
                        column: x => x.MatchCodPartido,
                        principalTable: "Partido",
                        principalColumn: "Cod_Partido");
                });

            migrationBuilder.CreateTable(
                name: "Cambio",
                columns: table => new
                {
                    Cod_Cambio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Partido = table.Column<int>(type: "int", nullable: false),
                    Cod_Jugador_Entra = table.Column<int>(type: "int", nullable: false),
                    Cod_Jugador_Sale = table.Column<int>(type: "int", nullable: false),
                    Minuto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cambio__82EA1AC42870933A", x => x.Cod_Cambio);
                    table.ForeignKey(
                        name: "FK__Cambio__Cod_Juga__08B54D69",
                        column: x => x.Cod_Jugador_Entra,
                        principalTable: "Jugador",
                        principalColumn: "Cod_Jugador");
                    table.ForeignKey(
                        name: "FK__Cambio__Cod_Juga__09A971A2",
                        column: x => x.Cod_Jugador_Sale,
                        principalTable: "Jugador",
                        principalColumn: "Cod_Jugador");
                    table.ForeignKey(
                        name: "FK__Cambio__Cod_Part__07C12930",
                        column: x => x.Cod_Partido,
                        principalTable: "Partido",
                        principalColumn: "Cod_Partido");
                });

            migrationBuilder.CreateTable(
                name: "Gol",
                columns: table => new
                {
                    Cod_Gol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Partido = table.Column<int>(type: "int", nullable: false),
                    Cod_Jugador = table.Column<int>(type: "int", nullable: false),
                    Minuto = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    video = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Gol__0604040C0A22D869", x => x.Cod_Gol);
                    table.ForeignKey(
                        name: "FK__Gol__Cod_Jugador__114A936A",
                        column: x => x.Cod_Jugador,
                        principalTable: "Jugador",
                        principalColumn: "Cod_Jugador");
                    table.ForeignKey(
                        name: "FK__Gol__Cod_Partido__10566F31",
                        column: x => x.Cod_Partido,
                        principalTable: "Partido",
                        principalColumn: "Cod_Partido");
                });

            migrationBuilder.CreateTable(
                name: "Partido_Jugado",
                columns: table => new
                {
                    Cod_Jugador = table.Column<int>(type: "int", nullable: false),
                    Cod_Partido = table.Column<int>(type: "int", nullable: false),
                    Titular = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Minutos = table.Column<int>(type: "int", nullable: false),
                    Asistencias = table.Column<int>(type: "int", nullable: false),
                    Asistencias_Gol = table.Column<int>(type: "int", nullable: false),
                    remates = table.Column<int>(type: "int", nullable: false),
                    remates_Porteria = table.Column<int>(type: "int", nullable: false),
                    remates_Poste = table.Column<int>(type: "int", nullable: false),
                    fueras_Juego = table.Column<int>(type: "int", nullable: false),
                    tarjetas_Amarillas_Provocadas = table.Column<int>(type: "int", nullable: false),
                    tarjetas_Rojas_Provocadas = table.Column<int>(type: "int", nullable: false),
                    Faltas_Recibidas = table.Column<int>(type: "int", nullable: false),
                    Faltas_Cometidas = table.Column<int>(type: "int", nullable: false),
                    corners = table.Column<int>(type: "int", nullable: false),
                    balones_recuperados = table.Column<int>(type: "int", nullable: false),
                    balones_perdidos = table.Column<int>(type: "int", nullable: false),
                    penaltis_recibidos = table.Column<int>(type: "int", nullable: false),
                    penaltis_cometidos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Partido___86F09A27E3058A54", x => new { x.Cod_Jugador, x.Cod_Partido });
                    table.ForeignKey(
                        name: "FK__Partido_J__Cod_J__1CBC4616",
                        column: x => x.Cod_Jugador,
                        principalTable: "Jugador",
                        principalColumn: "Cod_Jugador");
                    table.ForeignKey(
                        name: "FK__Partido_J__Cod_P__1DB06A4F",
                        column: x => x.Cod_Partido,
                        principalTable: "Partido",
                        principalColumn: "Cod_Partido");
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    Cod_Tarjeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Partido = table.Column<int>(type: "int", nullable: false),
                    Cod_Jugador = table.Column<int>(type: "int", nullable: false),
                    Minuto = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Motivo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tarjeta__D5EE15398F60B8AF", x => x.Cod_Tarjeta);
                    table.ForeignKey(
                        name: "FK__Tarjeta__Cod_Jug__1F98B2C1",
                        column: x => x.Cod_Jugador,
                        principalTable: "Jugador",
                        principalColumn: "Cod_Jugador");
                    table.ForeignKey(
                        name: "FK__Tarjeta__Cod_Par__1EA48E88",
                        column: x => x.Cod_Partido,
                        principalTable: "Partido",
                        principalColumn: "Cod_Partido");
                });

            migrationBuilder.CreateIndex(
                name: "IX_abono_cod_zona",
                table: "abono",
                column: "cod_zona");

            migrationBuilder.CreateIndex(
                name: "UQ__abono__4A62EF7D0F85E508",
                table: "abono",
                columns: new[] { "loginName", "cod_competicion" },
                unique: true,
                filter: "[loginName] IS NOT NULL AND [cod_competicion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_MatchCodPartido",
                table: "Calendario",
                column: "MatchCodPartido");

            migrationBuilder.CreateIndex(
                name: "IX_Cambio_Cod_Jugador_Entra",
                table: "Cambio",
                column: "Cod_Jugador_Entra");

            migrationBuilder.CreateIndex(
                name: "IX_Cambio_Cod_Jugador_Sale",
                table: "Cambio",
                column: "Cod_Jugador_Sale");

            migrationBuilder.CreateIndex(
                name: "IX_Cambio_Cod_Partido",
                table: "Cambio",
                column: "Cod_Partido");

            migrationBuilder.CreateIndex(
                name: "IX_Clasificacion_Cod_Equipo",
                table: "Clasificacion",
                column: "Cod_Equipo");

            migrationBuilder.CreateIndex(
                name: "IX_Competicion_CompetitionLogoGlobalMediaId",
                table: "Competicion",
                column: "CompetitionLogoGlobalMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_languageCode",
                table: "Countries",
                column: "languageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Directivo_Cod_Equipo",
                table: "Directivo",
                column: "Cod_Equipo");

            migrationBuilder.CreateIndex(
                name: "IX_Entrenador_Cod_Equipo",
                table: "Entrenador",
                column: "Cod_Equipo");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_Cod_Estadio",
                table: "Equipo",
                column: "Cod_Estadio");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_TeamPictureGlobalMediaId",
                table: "Equipo",
                column: "TeamPictureGlobalMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_EquiposParticipan_Cod_Equipo",
                table: "EquiposParticipan",
                column: "Cod_Equipo");

            migrationBuilder.CreateIndex(
                name: "IX_Estadio_PictureGlobalMediaId",
                table: "Estadio",
                column: "PictureGlobalMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Gol_Cod_Jugador",
                table: "Gol",
                column: "Cod_Jugador");

            migrationBuilder.CreateIndex(
                name: "IX_Gol_Cod_Partido",
                table: "Gol",
                column: "Cod_Partido");

            migrationBuilder.CreateIndex(
                name: "IX_Hco_Integrante_Cod_Equipo",
                table: "Hco_Integrante",
                column: "Cod_Equipo");

            migrationBuilder.CreateIndex(
                name: "IX_Integrante_PictureGlobalMediaId",
                table: "Integrante",
                column: "PictureGlobalMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_Cod_Equipo",
                table: "Jugador",
                column: "Cod_Equipo");

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_Cod_Integrante",
                table: "Jugador",
                column: "Cod_Integrante");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_Cod_Equipo",
                table: "Medico",
                column: "Cod_Equipo");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_Cod_Arbitro",
                table: "Partido",
                column: "Cod_Arbitro");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_Cod_Competicion",
                table: "Partido",
                column: "Cod_Competicion");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_Cod_Estadio",
                table: "Partido",
                column: "Cod_Estadio");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_Cod_Local",
                table: "Partido",
                column: "Cod_Local");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_Cod_Visitante",
                table: "Partido",
                column: "Cod_Visitante");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_Jugado_Cod_Partido",
                table: "Partido_Jugado",
                column: "Cod_Partido");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_Cod_Jugador",
                table: "Tarjeta",
                column: "Cod_Jugador");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_Cod_Partido",
                table: "Tarjeta",
                column: "Cod_Partido");

            migrationBuilder.CreateIndex(
                name: "IX_Transpaso_Cod_Equipo_Destino",
                table: "Transpaso",
                column: "Cod_Equipo_Destino");

            migrationBuilder.CreateIndex(
                name: "IX_Transpaso_Cod_Equipo_Origen",
                table: "Transpaso",
                column: "Cod_Equipo_Origen");

            migrationBuilder.CreateIndex(
                name: "IX_Trata_Cod_Jugador",
                table: "Trata",
                column: "Cod_Jugador");

            migrationBuilder.CreateIndex(
                name: "IX_Trata_Cod_Medico",
                table: "Trata",
                column: "Cod_Medico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abono");

            migrationBuilder.DropTable(
                name: "agenda");

            migrationBuilder.DropTable(
                name: "asiento");

            migrationBuilder.DropTable(
                name: "Calendario");

            migrationBuilder.DropTable(
                name: "Cambio");

            migrationBuilder.DropTable(
                name: "Clasificacion");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Directivo");

            migrationBuilder.DropTable(
                name: "Entrenador");

            migrationBuilder.DropTable(
                name: "EquiposParticipan");

            migrationBuilder.DropTable(
                name: "Gol");

            migrationBuilder.DropTable(
                name: "Hco_Integrante");

            migrationBuilder.DropTable(
                name: "LineaPedido");

            migrationBuilder.DropTable(
                name: "Noticia");

            migrationBuilder.DropTable(
                name: "Partido_Jugado");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "Transpaso");

            migrationBuilder.DropTable(
                name: "Trata");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "zonaEstadio");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "Partido");

            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Arbitro");

            migrationBuilder.DropTable(
                name: "Competicion");

            migrationBuilder.DropTable(
                name: "Integrante");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Estadio");

            migrationBuilder.DropTable(
                name: "GlobalMedia");
        }
    }
}
