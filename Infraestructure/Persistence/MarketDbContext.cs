using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Persistence
{
    public class MarketDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SaleProduct> SaleProducts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=WebApiMarket;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasKey(x => x.CategoryId);

                entity.Property(x => x.Name)
                .HasMaxLength(100);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale");

                entity.HasKey(x => x.SaleId);

                entity.Property(x => x.TotalPay)
                .HasColumnType("decimal( 15, 2)")
                .IsRequired();

                entity.Property(x => x.Subtotal)
               .HasColumnType("decimal( 15, 2)")
               .IsRequired();

                entity.Property(x => x.TotalDiscount)
                .HasColumnType("decimal( 15, 2)")
                .IsRequired();

                entity.Property(x => x.Taxes)
                .HasColumnType("decimal( 15, 2)")
                .IsRequired();

                entity.Property(x => x.Date)
                .IsRequired();

            });

            modelBuilder.Entity<SaleProduct>(entity =>
            {
                entity.ToTable("SaleProduct");

                entity.HasKey(x => x.ShoppingCartId);

                entity.Property(x => x.Sale)
                .IsRequired();

                entity.Property(x => x.Product)
               .IsRequired();

                entity.Property(x => x.Quantity)
                .IsRequired();

                entity.Property(x => x.Price)
                .HasColumnType("decimal( 15, 2)")
                .IsRequired();

                entity.Property(x => x.Discount);

                entity.HasOne(x => x.SaleTable).WithMany(a => a.SalesProducts).HasForeignKey(x => x.Sale);
                entity.HasOne(x => x.ProductTable).WithMany(a => a.SaleProducts).HasForeignKey(x => x.Product);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasKey(x => x.ProductId);

                entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(x => x.Description)
                .HasMaxLength(int.MaxValue);

                entity.Property(x => x.Price)
                .HasColumnType("decimal( 15, 2)")
                .IsRequired();

                entity.Property(x => x.Category)
                .IsRequired();

                entity.Property(x => x.Discount);

                entity.HasOne(x => x.CategoryTable).WithMany(a => a.Products).HasForeignKey(x => x.Category);
            });

            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryId = 1,
                Name = "Electrodomestico"
            },
            new Category
            {
                CategoryId = 2,
                Name = "Tecnología y Electrónica"
            },
            new Category
            {
                CategoryId = 3,
                Name = "Moda y Accesorios"
            },
            new Category
            {
                CategoryId = 4,
                Name = "Hogar y Decoración"
            },
            new Category
            {
                CategoryId = 5,
                Name = "Salud y Belleza"
            },
            new Category
            {
                CategoryId = 6,
                Name = "Deportes y Ocio"
            },
             new Category
             {
                 CategoryId = 7,
                 Name = "Juguetes y Juegos"
             },
            new Category
            {
                CategoryId = 8,
                Name = "Alimentos y Bebidas"
            },
             new Category
             {
                 CategoryId = 9,
                 Name = "Libros y Material Educativo"
             },
            new Category
            {
                CategoryId = 10,
                Name = "Jardinería y Bricolaje"
            });
            modelBuilder.Entity<Product>().HasData(
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Lavarropa Drean",
                 Description = "Lavarropa automatico Drean Next 6.06 Eco, 6kl, Blanco",
                 Price = 740299,
                 Category = 1,
                 Discount = 20,
                 ImageUrl = "https://megatonedigital.vteximg.com.br/arquivos/ids/156425-520-520/135728_01.jpg?v=638265420231900000"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Microonda Daewoo ",
                 Description = "Microonda Daewoo, 23 Litros Bifunción D223dg",
                 Price = 400846,
                 Category = 1,
                 Discount = 20,
                 ImageUrl = "https://www.megatone.net/images//Articulos/zoom2x/32/MKT0005BGH-1.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Heladera Conqueror",
                 Description = "Heladera Conqueror, 329L 2F-1600bda ",
                 Price = 732299,
                 Category = 1,
                 Discount = 20,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom2x/35/HEL1688CNQ.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Cocina Florencia",
                 Description = " Cocina Florencia 5518F Inoxidable Multigas Con 4 Hornallas",
                 Price = 519399,
                 Category = 1,
                 Discount = 20,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom2x/31/COC5518FLO.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Celular Sansung A34",
                 Description = "Celular Liberado A34 Gris 128 Gb, Ram 6 Gb, Octa Core",
                 Price = 695999,
                 Category = 2,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom2x/209/02/KIT3463SSG.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Notebook PCBOX",
                 Description = "Notebook Cel Fire Glw2, Ram 4G, SSD 128 Gb, Pantalla 14",
                 Price = 499999,
                 Category = 2,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom2x/200/04/NOT2128PCB.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Joystick Xbox",
                 Description = "Joystick Robot Con Conexión Inalámbrica, Microsoft",
                 Price = 129999,
                 Category = 2,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom2x/235/JOY6910MIC.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Tablet Wave 7 Exo",
                 Description = "Tablet Wave 7 Dual I726a10, 2Gb, Ram 16Gb, Wifi",
                 Price = 134999,
                 Category = 2,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images//Articulos/zoom2x/224/MKT0054EXO-1.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Reloj Smartwatch Nt04",
                 Description = "Reloj Inteligente, Negro, Bluetooth, Android, Notificaciones, Resistente al agua",
                 Price = 33798,
                 Category = 3,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images/Articulos/zoom2x/239/MKT0034DXE.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Lentes de Sol Exclamation",
                 Description = "Anteojos de sol, Negro mate, lente gris ",
                 Price = 129000,
                 Category = 3,
                 Discount = 0,
                 ImageUrl = "https://infinit.la/cdn/shop/products/6_f14d1e1f-e535-42e0-84ce-07c9f0aa93eb.jpg?v=1681141624&width=800"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Zapatillas Adizero Adidas",
                 Description = "Zapatillas de running, color negro, talle 44",
                 Price = 171999,
                 Category = 3,
                 Discount = 0,
                 ImageUrl = "https://assets.adidas.com/images/w_383,h_383,f_auto,q_auto,fl_lossy,c_fill,g_auto/2881496d3d514a33905ef338f92dc37d_9366/zapatillas-de-running-adizero-sl.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Riñonera Adicolor Adidas",
                 Description = "Riñonera Adicolor Classic",
                 Price = 35999,
                 Category = 3,
                 Discount = 0,
                 ImageUrl = "https://assets.adidas.com/images/w_383,h_383,f_auto,q_auto,fl_lossy,c_fill,g_auto/5460d79ff58c46dcac93ae6701128b5e_9366/rinonera-adicolor-classic.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Colchón Bonnell Babel Inducol",
                 Description = "Colchón 1 Plaza Resorte Bonnell Babel 0.80 X 1.90",
                 Price = 216999,
                 Category = 4,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom/140/CHO7062IDL.jpg?version=35"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Sillón American Wood",
                 Description = "Sillón De 3 Cuerpos, Esquinero,1.85Mts, Chenille Gris ",
                 Price = 600000,
                 Category = 4,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom2x/270/MKT0022AWO.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Divan Inmacol",
                 Description = "Divan Cama Pacifico, Madera, Ancho 90 Cm, largo 204 Cm",
                 Price = 259000,
                 Category = 4,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom2x/273/DIV0001INM.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Silla Comedor Vita Meet Makom",
                 Description = "Silla Comedor, Nórdica Eames, Diseño Moderno, Color Verde",
                 Price = 179000,
                 Category = 4,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images/Articulos/zoom2x/339/MKT0250VIV.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Afeitadora Oneblade Qp2724, Philips",
                 Description = "Lavable Con Agua, Recargable, Color Negro",
                 Price = 52999,
                 Category = 5,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom/76/AFE2724PHI.jpg?version=35"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Secador De Pelo Eleganza Gama",
                 Description = "Uso En Humedo, No recargable, Potencia Total 2400 ",
                 Price = 84800,
                 Category = 5,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images/articulos/zoom2x/97/SEC0215GAM.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Plancha Elegance Gamma",
                 Description = "Planchita de pelo, No recargable, Potencia Total 2400 ",
                 Price = 101000,
                 Category = 5,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom2x/97/PLA2118GAM.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Balanza Digital Atma Ba7504n",
                 Description = "Balanza Digital Vidrio Templado Hasta 150Kg",
                 Price = 23400,
                 Category = 5,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images//Articulos/zoom2x/78/MKT0132PHO-1.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Casco Ciclismo Wt-032",
                 Description = "Con regulador, Visera, Color Azul",
                 Price = 27600,
                 Category = 6,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom2x/232/CAS0033SLP.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Bicicleta Mountain Bike Nordic",
                 Description = "Rodado 29, Talle 18, Color Blanco",
                 Price = 320000,
                 Category = 6,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom2x/104/BIC2920NRD.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Cinta Caminadora Randers Arg-407",
                 Description = "Velocidad 12 Km/h, Peso Máximo Soportado 100 kl",
                 Price = 716519,
                 Category = 6,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images//Articulos/zoom2x/111/MKT0650ATR-1.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Bicicleta De Paseo Lamborghini",
                 Description = "Rodado 26, Con 7 Velocidades,Talle 18, Color Azul",
                 Price = 350490,
                 Category = 6,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images//Articulos/zoom2x/104/MKT0379DNC-1.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Patines Lamborghini",
                 Description = "Con Lentejuelas Reversibles y Protecciones, Talle 36",
                 Price = 98020,
                 Category = 7,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images/Articulos/zoom2x/257/MKT0104DNC.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Sillita De Comer Booster Lamborghini",
                 Description = "Silla de comer, Color rosa",
                 Price = 97860,
                 Category = 7,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images/Articulos/zoom2x/119/MKT0203DNC.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Caminador Musical Bebesit 1226",
                 Description = "Caminador musical con panel didactico",
                 Price = 52280,
                 Category = 7,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images//Articulos/zoom2x/325/MKT0616ATR-1.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Moto a batería Bmw K1300",
                 Description = "Moto a batería, Color azul y negro",
                 Price = 530000,
                 Category = 7,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images//Articulos/zoom2x/362/MKT0032BBS-1.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Coca Cola 500 ml",
                 Description = "Gaseosa 500 ml",
                 Price = 750,
                 Category = 8,
                 Discount = 0,
                 ImageUrl = "https://cdn.tiendanegocio.com/gallery/17745/img_17745_18b20896ea8.jpeg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Dv Catena Malbec",
                 Description = "Vino malbec 750 ml",
                 Price = 15800,
                 Category = 8,
                 Discount = 0,
                 ImageUrl = "https://cdn.tiendanegocio.com/gallery/17745/img_17745_18b4b8c013b.jpeg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Cafe Dolca",
                 Description = "Cafe torrado, 170 GR",
                 Price = 1900,
                 Category = 8,
                 Discount = 0,
                 ImageUrl = "https://cdn.tiendanegocio.com/gallery/17745/img_17745_18b1f7b2bf9.jpeg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Nutella",
                 Description = "Ferrero x140g",
                 Price = 2565,
                 Category = 8,
                 Discount = 0,
                 ImageUrl = "https://www.golomax.com.ar/uploads/centum/articles/home/7003428_1.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Pasión por el fútbol",
                 Description = "Autor Dibu Martinez, Libro tapa blanda",
                 Price = 12800,
                 Category = 9,
                 Discount = 0,
                 ImageUrl = "https://www.penguinlibros.com/ar/2733557-thickbox_default/dibu-martinez-pasion-por-el-futbol.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Parque Jurásico",
                 Description = "Autor Michael Crichton, Libro tipo bolsillo",
                 Price = 23500,
                 Category = 9,
                 Discount = 0,
                 ImageUrl = "https://www.penguinlibros.com/ar/3243614-thickbox_default/parque-jurasico-jurassic-park.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "La torre de Nerón, Las pruebas de Apolo 5",
                 Description = "Autor Rick Riordan, Libro tapa blanda",
                 Price = 29900,
                 Category = 9,
                 Discount = 0,
                 ImageUrl = "https://www.penguinlibros.com/ar/3477641-thickbox_default/la-torre-de-neron-las-pruebas-de-apolo-5.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Ready player Two",
                 Description = "Autor Ernest Cline, Libro tapa blanda",
                 Price = 30800,
                 Category = 9,
                 Discount = 0,
                 ImageUrl = "https://www.penguinlibros.com/ar/3495318-thickbox_default/ready-player-two.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Reposera para jardín EMC",
                 Description = "Material madera",
                 Price = 246800,
                 Category = 10,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images//Articulos/zoom2x/343/MKT0425EMC-1.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Reposera para jardín EMC",
                 Description = "Material madera",
                 Price = 246800,
                 Category = 10,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images//Articulos/zoom2x/343/MKT0425EMC-1.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Parrilla portátil carbón balcon Mor Amazonas",
                 Description = "Parrilla portátil, plegable para camping",
                 Price = 64900,
                 Category = 10,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/images/Articulos/zoom2x/316/MKT0048IUR.jpg"
             },
             new Product
             {
                 ProductId = Guid.NewGuid(),
                 Name = "Gazebo Rafia Exahome",
                 Description = "Gazebo de 6X3, con puerta y ventanas, Color blanco",
                 Price = 430000,
                 Category = 10,
                 Discount = 0,
                 ImageUrl = "https://www.megatone.net/Images/Articulos/zoom2x/114/MKT0058RBJ.jpg"
             });
        }
    }
}
    