using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPay = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_Category",
                        column: x => x.Category,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sale = table.Column<int>(type: "int", nullable: false),
                    Product = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Product_Product",
                        column: x => x.Product,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sale_Sale",
                        column: x => x.Sale,
                        principalTable: "Sale",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Electrodomestico" },
                    { 2, "Tecnología y Electrónica" },
                    { 3, "Moda y Accesorios" },
                    { 4, "Hogar y Decoración" },
                    { 5, "Salud y Belleza" },
                    { 6, "Deportes y Ocio" },
                    { 7, "Juguetes y Juegos" },
                    { 8, "Alimentos y Bebidas" },
                    { 9, "Libros y Material Educativo" },
                    { 10, "Jardinería y Bricolaje" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Category", "Description", "Discount", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0653e07c-b3b1-433e-b473-a01c00874d7e"), 4, "Divan Cama Pacifico, Madera, Ancho 90 Cm, largo 204 Cm", 0, "https://www.megatone.net/Images/Articulos/zoom2x/273/DIV0001INM.jpg", "Divan Inmacol", 259000m },
                    { new Guid("0750083e-dabd-4c5f-9995-c454ad711bb1"), 8, "Cafe torrado, 170 GR", 0, "https://cdn.tiendanegocio.com/gallery/17745/img_17745_18b1f7b2bf9.jpeg", "Cafe Dolca", 1900m },
                    { new Guid("0ac8c8a4-fa71-4f7b-825c-aed4e78e63cb"), 8, "Ferrero x140g", 0, "https://www.golomax.com.ar/uploads/centum/articles/home/7003428_1.jpg", "Nutella", 2565m },
                    { new Guid("19f7128a-f6bc-4adf-be23-f505dbb7c5b9"), 7, "Caminador musical con panel didactico", 0, "https://www.megatone.net/images//Articulos/zoom2x/325/MKT0616ATR-1.jpg", "Caminador Musical Bebesit 1226", 52280m },
                    { new Guid("24f5e33f-de5a-40e4-87b4-98d779e32135"), 6, "Rodado 26, Con 7 Velocidades,Talle 18, Color Azul", 0, "https://www.megatone.net/images//Articulos/zoom2x/104/MKT0379DNC-1.jpg", "Bicicleta De Paseo Lamborghini", 350490m },
                    { new Guid("25fda333-7589-40b5-a764-b6aea9e2b320"), 5, "Balanza Digital Vidrio Templado Hasta 150Kg", 0, "https://www.megatone.net/images//Articulos/zoom2x/78/MKT0132PHO-1.jpg", "Balanza Digital Atma Ba7504n", 23400m },
                    { new Guid("29a21ee2-535b-4750-87af-6a85b413a287"), 9, "Autor Rick Riordan, Libro tapa blanda", 0, "https://www.penguinlibros.com/ar/3477641-thickbox_default/la-torre-de-neron-las-pruebas-de-apolo-5.jpg", "La torre de Nerón, Las pruebas de Apolo 5", 29900m },
                    { new Guid("2c53350d-6ee7-4445-9137-019715d7a1eb"), 4, "Colchón 1 Plaza Resorte Bonnell Babel 0.80 X 1.90", 0, "https://www.megatone.net/Images/Articulos/zoom/140/CHO7062IDL.jpg?version=35", "Colchón Bonnell Babel Inducol", 216999m },
                    { new Guid("2f8fc42b-0e05-4e56-8327-28fe3c59f1e2"), 10, "Material madera", 0, "https://www.megatone.net/images//Articulos/zoom2x/343/MKT0425EMC-1.jpg", "Reposera para jardín EMC", 246800m },
                    { new Guid("345fe562-4ffa-41df-8118-088182eb14b1"), 3, "Anteojos de sol, Negro mate, lente gris ", 0, "https://infinit.la/cdn/shop/products/6_f14d1e1f-e535-42e0-84ce-07c9f0aa93eb.jpg?v=1681141624&width=800", "Lentes de Sol Exclamation", 129000m },
                    { new Guid("418b2c87-ce2a-49ad-80fa-e53fb3adfe13"), 7, "Con Lentejuelas Reversibles y Protecciones, Talle 36", 0, "https://www.megatone.net/images/Articulos/zoom2x/257/MKT0104DNC.jpg", "Patines Lamborghini", 98020m },
                    { new Guid("43386dc5-62ec-451c-9b18-4b2c26481a83"), 10, "Material madera", 0, "https://www.megatone.net/images//Articulos/zoom2x/343/MKT0425EMC-1.jpg", "Reposera para jardín EMC", 246800m },
                    { new Guid("470e7424-0f8c-4fb3-b5ac-5f5b8ac37776"), 8, "Gaseosa 500 ml", 0, "https://cdn.tiendanegocio.com/gallery/17745/img_17745_18b20896ea8.jpeg", "Coca Cola 500 ml", 750m },
                    { new Guid("62652dd1-26a7-4a3b-af77-98fc8bc1ec6e"), 6, "Rodado 29, Talle 18, Color Blanco", 0, "https://www.megatone.net/Images/Articulos/zoom2x/104/BIC2920NRD.jpg", "Bicicleta Mountain Bike Nordic", 320000m },
                    { new Guid("703072b3-4440-4e26-bf8f-8b3230ceae8b"), 7, "Silla de comer, Color rosa", 0, "https://www.megatone.net/images/Articulos/zoom2x/119/MKT0203DNC.jpg", "Sillita De Comer Booster Lamborghini", 97860m },
                    { new Guid("73a515cb-2f77-41e2-8604-78392ac915df"), 1, "Heladera Conqueror, 329L 2F-1600bda ", 20, "https://www.megatone.net/Images/Articulos/zoom2x/35/HEL1688CNQ.jpg", "Heladera Conqueror", 732299m },
                    { new Guid("7cb16dfc-c3e3-4037-8e0e-4f7bfed7bfe1"), 6, "Con regulador, Visera, Color Azul", 0, "https://www.megatone.net/Images/Articulos/zoom2x/232/CAS0033SLP.jpg", "Casco Ciclismo Wt-032", 27600m },
                    { new Guid("80648e78-49e9-482c-aa57-ae707b613023"), 3, "Zapatillas de running, color negro, talle 44", 0, "https://assets.adidas.com/images/w_383,h_383,f_auto,q_auto,fl_lossy,c_fill,g_auto/2881496d3d514a33905ef338f92dc37d_9366/zapatillas-de-running-adizero-sl.jpg", "Zapatillas Adizero Adidas", 171999m },
                    { new Guid("8d33b667-9445-42f6-b0de-0f194434daba"), 4, "Sillón De 3 Cuerpos, Esquinero,1.85Mts, Chenille Gris ", 0, "https://www.megatone.net/Images/Articulos/zoom2x/270/MKT0022AWO.jpg", "Sillón American Wood", 600000m },
                    { new Guid("90c352bb-3edb-40e2-9a18-a0e80593420f"), 10, "Parrilla portátil, plegable para camping", 0, "https://www.megatone.net/images/Articulos/zoom2x/316/MKT0048IUR.jpg", "Parrilla portátil carbón balcon Mor Amazonas", 64900m },
                    { new Guid("942431e4-48e5-41ea-9ef5-706fd1cd0ed5"), 3, "Riñonera Adicolor Classic", 0, "https://assets.adidas.com/images/w_383,h_383,f_auto,q_auto,fl_lossy,c_fill,g_auto/5460d79ff58c46dcac93ae6701128b5e_9366/rinonera-adicolor-classic.jpg", "Riñonera Adicolor Adidas", 35999m },
                    { new Guid("9b74566b-60f5-4e63-939a-a09c0037c1e8"), 1, "Lavarropa automatico Drean Next 6.06 Eco, 6kl, Blanco", 20, "https://megatonedigital.vteximg.com.br/arquivos/ids/156425-520-520/135728_01.jpg?v=638265420231900000", "Lavarropa Drean", 740299m },
                    { new Guid("9e2b0162-b233-46e9-9fe0-b268495efb77"), 2, "Tablet Wave 7 Dual I726a10, 2Gb, Ram 16Gb, Wifi", 0, "https://www.megatone.net/images//Articulos/zoom2x/224/MKT0054EXO-1.jpg", "Tablet Wave 7 Exo", 134999m },
                    { new Guid("9ede373f-ebeb-48c0-9aef-fb9cb9f3313f"), 8, "Vino malbec 750 ml", 0, "https://cdn.tiendanegocio.com/gallery/17745/img_17745_18b4b8c013b.jpeg", "Dv Catena Malbec", 15800m },
                    { new Guid("ab66afba-77da-4bba-adea-8b5496605fad"), 9, "Autor Michael Crichton, Libro tipo bolsillo", 0, "https://www.penguinlibros.com/ar/3243614-thickbox_default/parque-jurasico-jurassic-park.jpg", "Parque Jurásico", 23500m },
                    { new Guid("acdc4528-9ddf-4852-a629-2affb5be62dc"), 5, "Planchita de pelo, No recargable, Potencia Total 2400 ", 0, "https://www.megatone.net/Images/Articulos/zoom2x/97/PLA2118GAM.jpg", "Plancha Elegance Gamma", 101000m },
                    { new Guid("b61b5a8c-c75f-4e2c-b642-0806d49276dc"), 7, "Moto a batería, Color azul y negro", 0, "https://www.megatone.net/images//Articulos/zoom2x/362/MKT0032BBS-1.jpg", "Moto a batería Bmw K1300", 530000m },
                    { new Guid("c08b5aab-3b83-4e65-8fbc-71c80f6ad9f0"), 5, "Uso En Humedo, No recargable, Potencia Total 2400 ", 0, "https://www.megatone.net/images/articulos/zoom2x/97/SEC0215GAM.jpg", "Secador De Pelo Eleganza Gama", 84800m },
                    { new Guid("c2e71e36-090d-4853-b118-2e782f253ce2"), 3, "Reloj Inteligente, Negro, Bluetooth, Android, Notificaciones, Resistente al agua", 0, "https://www.megatone.net/images/Articulos/zoom2x/239/MKT0034DXE.jpg", "Reloj Smartwatch Nt04", 33798m },
                    { new Guid("c4834922-c7f6-4eee-a8c7-00d422ceddd9"), 9, "Autor Dibu Martinez, Libro tapa blanda", 0, "https://www.penguinlibros.com/ar/2733557-thickbox_default/dibu-martinez-pasion-por-el-futbol.jpg", "Pasión por el fútbol", 12800m },
                    { new Guid("c59aebb8-d715-47b0-8583-ed510c135b75"), 10, "Gazebo de 6X3, con puerta y ventanas, Color blanco", 0, "https://www.megatone.net/Images/Articulos/zoom2x/114/MKT0058RBJ.jpg", "Gazebo Rafia Exahome", 430000m },
                    { new Guid("c78611d9-f83f-43fd-bc68-f58947c27c04"), 1, "Microonda Daewoo, 23 Litros Bifunción D223dg", 20, "https://www.megatone.net/images//Articulos/zoom2x/32/MKT0005BGH-1.jpg", "Microonda Daewoo ", 400846m },
                    { new Guid("cb28c377-70e5-4adb-b66c-6d851f57b05b"), 5, "Lavable Con Agua, Recargable, Color Negro", 0, "https://www.megatone.net/Images/Articulos/zoom/76/AFE2724PHI.jpg?version=35", "Afeitadora Oneblade Qp2724, Philips", 52999m },
                    { new Guid("d05af8ee-97ac-46b1-bf22-6fb269bfec22"), 2, "Celular Liberado A34 Gris 128 Gb, Ram 6 Gb, Octa Core", 0, "https://www.megatone.net/Images/Articulos/zoom2x/209/02/KIT3463SSG.jpg", "Celular Sansung A34", 695999m },
                    { new Guid("d67e9c3f-2306-4ba2-904b-6dc2538bdcd6"), 2, "Notebook Cel Fire Glw2, Ram 4G, SSD 128 Gb, Pantalla 14", 0, "https://www.megatone.net/Images/Articulos/zoom2x/200/04/NOT2128PCB.jpg", "Notebook PCBOX", 499999m },
                    { new Guid("dd16d78d-2de9-4c7b-984d-76ad05abdf40"), 6, "Velocidad 12 Km/h, Peso Máximo Soportado 100 kl", 0, "https://www.megatone.net/images//Articulos/zoom2x/111/MKT0650ATR-1.jpg", "Cinta Caminadora Randers Arg-407", 716519m },
                    { new Guid("e792cffb-1561-4ea7-99a5-58f7df27b777"), 9, "Autor Ernest Cline, Libro tapa blanda", 0, "https://www.penguinlibros.com/ar/3495318-thickbox_default/ready-player-two.jpg", "Ready player Two", 30800m },
                    { new Guid("ebca9848-782e-407f-9f8f-9d88c8b6a8e7"), 1, " Cocina Florencia 5518F Inoxidable Multigas Con 4 Hornallas", 20, "https://www.megatone.net/Images/Articulos/zoom2x/31/COC5518FLO.jpg", "Cocina Florencia", 519399m },
                    { new Guid("ec8422ac-374c-47f8-902d-3e0a79c9c7ee"), 2, "Joystick Robot Con Conexión Inalámbrica, Microsoft", 0, "https://www.megatone.net/Images/Articulos/zoom2x/235/JOY6910MIC.jpg", "Joystick Xbox", 129999m },
                    { new Guid("faaa3eee-4d88-4662-a1df-6bab00812a5e"), 4, "Silla Comedor, Nórdica Eames, Diseño Moderno, Color Verde", 0, "https://www.megatone.net/images/Articulos/zoom2x/339/MKT0250VIV.jpg", "Silla Comedor Vita Meet Makom", 179000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category",
                table: "Product",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_Product",
                table: "SaleProduct",
                column: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_Sale",
                table: "SaleProduct",
                column: "Sale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
