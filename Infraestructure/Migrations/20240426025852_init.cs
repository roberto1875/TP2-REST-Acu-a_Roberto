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
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
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
                    { new Guid("08416f69-3583-4c90-928b-d0d455b2a500"), 2, "Celular Liberado A34 Gris 128 Gb, Ram 6 Gb, Octa Core", 0, "https://www.megatone.net/Images/Articulos/zoom2x/209/02/KIT3463SSG.jpg", "Celular Sansung A34", 695999m },
                    { new Guid("1a5bef09-74f0-4851-a257-025c739444e4"), 1, " Cocina Florencia 5518F Inoxidable Multigas Con 4 Hornallas", 20, "https://www.megatone.net/Images/Articulos/zoom2x/31/COC5518FLO.jpg", "Cocina Florencia", 519399m },
                    { new Guid("1c51895e-a75e-483f-b206-6ac9dc201a60"), 6, "Velocidad 12 Km/h, Peso Máximo Soportado 100 kl", 0, "https://www.megatone.net/images//Articulos/zoom2x/111/MKT0650ATR-1.jpg", "Cinta Caminadora Randers Arg-407", 716519m },
                    { new Guid("1f5c9ba8-9b18-428f-8348-2000e62ec08f"), 8, "Cafe torrado, 170 GR", 0, "https://cdn.tiendanegocio.com/gallery/17745/img_17745_18b1f7b2bf9.jpeg", "Cafe Dolca", 1900m },
                    { new Guid("2ef8edfc-84db-475e-a969-aa9ace5ace0b"), 10, "Material madera", 0, "https://www.megatone.net/images//Articulos/zoom2x/343/MKT0425EMC-1.jpg", "Reposera para jardín EMC", 246800m },
                    { new Guid("3c7699a0-35ca-48a8-8107-d30960f68170"), 4, "Divan Cama Pacifico, Madera, Ancho 90 Cm, largo 204 Cm", 0, "https://www.megatone.net/Images/Articulos/zoom2x/273/DIV0001INM.jpg", "Divan Inmacol", 259000m },
                    { new Guid("3da6795d-4684-42ab-b1ac-059fb958bf28"), 1, "Lavarropa automatico Drean Next 6.06 Eco, 6kl, Blanco", 20, "https://megatonedigital.vteximg.com.br/arquivos/ids/156425-520-520/135728_01.jpg?v=638265420231900000", "Lavarropa Drean", 740299m },
                    { new Guid("43f39e14-00c8-489e-bee4-d2309f8860d3"), 7, "Moto a batería, Color azul y negro", 0, "https://www.megatone.net/images//Articulos/zoom2x/362/MKT0032BBS-1.jpg", "Moto a batería Bmw K1300", 530000m },
                    { new Guid("498f3033-9878-4153-a597-23b2368aaa9f"), 3, "Anteojos de sol, Negro mate, lente gris ", 0, "https://infinit.la/cdn/shop/products/6_f14d1e1f-e535-42e0-84ce-07c9f0aa93eb.jpg?v=1681141624&width=800", "Lentes de Sol Exclamation", 129000m },
                    { new Guid("4a404d8d-b936-421a-aace-789fdb56c766"), 10, "Parrilla portátil, plegable para camping", 0, "https://www.megatone.net/images/Articulos/zoom2x/316/MKT0048IUR.jpg", "Parrilla portátil carbón balcon Mor Amazonas", 64900m },
                    { new Guid("51bd01f1-8688-4966-9241-06531ddaa399"), 2, "Tablet Wave 7 Dual I726a10, 2Gb, Ram 16Gb, Wifi", 0, "https://www.megatone.net/images//Articulos/zoom2x/224/MKT0054EXO-1.jpg", "Tablet Wave 7 Exo", 134999m },
                    { new Guid("55121716-f5f8-4d48-8151-4353aab8be91"), 1, "Heladera Conqueror, 329L 2F-1600bda ", 20, "https://www.megatone.net/Images/Articulos/zoom2x/35/HEL1688CNQ.jpg", "Heladera Conqueror", 732299m },
                    { new Guid("61fa0f65-7500-44e2-90f1-29bb26c1ddef"), 2, "Notebook Cel Fire Glw2, Ram 4G, SSD 128 Gb, Pantalla 14", 0, "https://www.megatone.net/Images/Articulos/zoom2x/200/04/NOT2128PCB.jpg", "Notebook PCBOX", 499999m },
                    { new Guid("65f3a6e1-7a4c-4c4d-a2cd-cb5effd0628b"), 9, "Autor Michael Crichton, Libro tipo bolsillo", 0, "https://www.penguinlibros.com/ar/3243614-thickbox_default/parque-jurasico-jurassic-park.jpg", "Parque Jurásico", 23500m },
                    { new Guid("72ff9828-19d7-436d-94b1-cc26435e0c65"), 8, "Vino malbec 750 ml", 0, "https://cdn.tiendanegocio.com/gallery/17745/img_17745_18b4b8c013b.jpeg", "Dv Catena Malbec", 15800m },
                    { new Guid("77a0891a-35c8-44da-9165-4de892ff8937"), 2, "Joystick Robot Con Conexión Inalámbrica, Microsoft", 0, "https://www.megatone.net/Images/Articulos/zoom2x/235/JOY6910MIC.jpg", "Joystick Xbox", 129999m },
                    { new Guid("822873fa-3bd4-4493-96ab-f8987c7f5489"), 8, "Gaseosa 500 ml", 0, "https://cdn.tiendanegocio.com/gallery/17745/img_17745_18b20896ea8.jpeg", "Coca Cola 500 ml", 750m },
                    { new Guid("8583e23b-2ed1-4630-a367-a20092fa637e"), 9, "Autor Ernest Cline, Libro tapa blanda", 0, "https://www.penguinlibros.com/ar/3495318-thickbox_default/ready-player-two.jpg", "Ready player Two", 30800m },
                    { new Guid("8eedd19a-6252-49c8-9de0-7a6c31531698"), 10, "Gazebo de 6X3, con puerta y ventanas, Color blanco", 0, "https://www.megatone.net/Images/Articulos/zoom2x/114/MKT0058RBJ.jpg", "Gazebo Rafia Exahome", 430000m },
                    { new Guid("90a92d74-583f-4e31-9416-e937acdd6120"), 4, "Sillón De 3 Cuerpos, Esquinero,1.85Mts, Chenille Gris ", 0, "https://www.megatone.net/Images/Articulos/zoom2x/270/MKT0022AWO.jpg", "Sillón American Wood", 600000m },
                    { new Guid("94013188-d7a9-4c89-987d-3768010a963d"), 10, "Material madera", 0, "https://www.megatone.net/images//Articulos/zoom2x/343/MKT0425EMC-1.jpg", "Reposera para jardín EMC", 246800m },
                    { new Guid("940eb2e5-8520-401c-bf4f-55ebf9934848"), 3, "Riñonera Adicolor Classic", 0, "https://assets.adidas.com/images/w_383,h_383,f_auto,q_auto,fl_lossy,c_fill,g_auto/5460d79ff58c46dcac93ae6701128b5e_9366/rinonera-adicolor-classic.jpg", "Riñonera Adicolor Adidas", 35999m },
                    { new Guid("95c6c15f-63c3-4ddf-b04e-ec324d47135e"), 3, "Reloj Inteligente, Negro, Bluetooth, Android, Notificaciones, Resistente al agua", 0, "https://www.megatone.net/images/Articulos/zoom2x/239/MKT0034DXE.jpg", "Reloj Smartwatch Nt04", 33798m },
                    { new Guid("9648780d-c63a-4847-981b-18f200e13765"), 1, "Microonda Daewoo, 23 Litros Bifunción D223dg", 20, "https://www.megatone.net/images//Articulos/zoom2x/32/MKT0005BGH-1.jpg", "Microonda Daewoo ", 400846m },
                    { new Guid("9d4e42fd-f6d2-4b1e-8a62-3debc0df7091"), 5, "Planchita de pelo, No recargable, Potencia Total 2400 ", 0, "https://www.megatone.net/Images/Articulos/zoom2x/97/PLA2118GAM.jpg", "Plancha Elegance Gamma", 101000m },
                    { new Guid("a3fa73c6-c249-4c96-9f1e-dbce31d788e4"), 4, "Silla Comedor, Nórdica Eames, Diseño Moderno, Color Verde", 0, "https://www.megatone.net/images/Articulos/zoom2x/339/MKT0250VIV.jpg", "Silla Comedor Vita Meet Makom", 179000m },
                    { new Guid("a5397067-d82c-4e24-a6db-8ece92f37567"), 5, "Balanza Digital Vidrio Templado Hasta 150Kg", 0, "https://www.megatone.net/images//Articulos/zoom2x/78/MKT0132PHO-1.jpg", "Balanza Digital Atma Ba7504n", 23400m },
                    { new Guid("aa4048d9-f5f3-42d2-b422-e1d312e428be"), 5, "Lavable Con Agua, Recargable, Color Negro", 0, "https://www.megatone.net/Images/Articulos/zoom/76/AFE2724PHI.jpg?version=35", "Afeitadora Oneblade Qp2724, Philips", 52999m },
                    { new Guid("aa941147-5944-4569-bcda-d080af37e814"), 9, "Autor Rick Riordan, Libro tapa blanda", 0, "https://www.penguinlibros.com/ar/3477641-thickbox_default/la-torre-de-neron-las-pruebas-de-apolo-5.jpg", "La torre de Nerón, Las pruebas de Apolo 5", 29900m },
                    { new Guid("b02339db-3d36-4285-98d1-8ff2cfd82e04"), 6, "Rodado 29, Talle 18, Color Blanco", 0, "https://www.megatone.net/Images/Articulos/zoom2x/104/BIC2920NRD.jpg", "Bicicleta Mountain Bike Nordic", 320000m },
                    { new Guid("b50fa98f-2049-408c-a6c2-7b28701f7a81"), 7, "Con Lentejuelas Reversibles y Protecciones, Talle 36", 0, "https://www.megatone.net/images/Articulos/zoom2x/257/MKT0104DNC.jpg", "Patines Lamborghini", 98020m },
                    { new Guid("bf1eb3d3-b51f-4f47-b751-e0570c2bda4f"), 4, "Colchón 1 Plaza Resorte Bonnell Babel 0.80 X 1.90", 0, "https://www.megatone.net/Images/Articulos/zoom/140/CHO7062IDL.jpg?version=35", "Colchón Bonnell Babel Inducol", 216999m },
                    { new Guid("c738ba3b-18bb-4458-9347-81e09791c4e2"), 7, "Caminador musical con panel didactico", 0, "https://www.megatone.net/images//Articulos/zoom2x/325/MKT0616ATR-1.jpg", "Caminador Musical Bebesit 1226", 52280m },
                    { new Guid("c9451962-9198-4963-9d18-de05a83d199e"), 7, "Silla de comer, Color rosa", 0, "https://www.megatone.net/images/Articulos/zoom2x/119/MKT0203DNC.jpg", "Sillita De Comer Booster Lamborghini", 97860m },
                    { new Guid("d28f55a7-13e5-4f4c-b91a-b769250b0f86"), 3, "Zapatillas de running, color negro, talle 44", 0, "https://assets.adidas.com/images/w_383,h_383,f_auto,q_auto,fl_lossy,c_fill,g_auto/2881496d3d514a33905ef338f92dc37d_9366/zapatillas-de-running-adizero-sl.jpg", "Zapatillas Adizero Adidas", 171999m },
                    { new Guid("d996fb77-a8e1-4aff-99c8-c814eddba425"), 9, "Autor Dibu Martinez, Libro tapa blanda", 0, "https://www.penguinlibros.com/ar/2733557-thickbox_default/dibu-martinez-pasion-por-el-futbol.jpg", "Pasión por el fútbol", 12800m },
                    { new Guid("d9a4d325-e673-4ef9-898b-068588496974"), 6, "Con regulador, Visera, Color Azul", 0, "https://www.megatone.net/Images/Articulos/zoom2x/232/CAS0033SLP.jpg", "Casco Ciclismo Wt-032", 27600m },
                    { new Guid("ddc86d5a-5038-488d-bdea-4a4433e51cf8"), 5, "Uso En Humedo, No recargable, Potencia Total 2400 ", 0, "https://www.megatone.net/images/articulos/zoom2x/97/SEC0215GAM.jpg", "Secador De Pelo Eleganza Gama", 84800m },
                    { new Guid("e1eb20b6-0f03-4e14-afad-062848f5ff36"), 8, "Ferrero x140g", 0, "https://www.golomax.com.ar/uploads/centum/articles/home/7003428_1.jpg", "Nutella", 2565m },
                    { new Guid("eb35843e-5ea0-492b-876a-b8146ef60685"), 6, "Rodado 26, Con 7 Velocidades,Talle 18, Color Azul", 0, "https://www.megatone.net/images//Articulos/zoom2x/104/MKT0379DNC-1.jpg", "Bicicleta De Paseo Lamborghini", 350490m }
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
