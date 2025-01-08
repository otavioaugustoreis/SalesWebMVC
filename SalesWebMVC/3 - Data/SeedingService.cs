using SalesWebMVC._3___Data.Entity;
using SalesWebMVC.Data.Entity;
using SalesWebMVC.Data.Enums;
using System.Security.Cryptography.Pkcs;

namespace SalesWebMVC.Data
{
    //Usado para pupular as tabelas
    public class SeedingService
    {
        private AppDbContext _context;

        public SeedingService(AppDbContext context)
        {
            _context = context;
        }

        public void Seeding()
        {
            if (_context.Departments.Any() ||
               _context.Seller.Any() ||
               _context.Sales.Any() ||
               _context.Product.Any() ||
               _context.SalesProduct.Any())
            {
                return;
            }
            ProductEntity p1 = new(1, "Placa mãe", 5);
            ProductEntity p2 = new(2, "Placa de video", 5);
            ProductEntity p3 = new(3, "Memoria RAM", 5);
            ProductEntity p4 = new(4, "Micro-ondas", 5);
            ProductEntity p5 = new(5, "Secador", 5);
            ProductEntity p6 = new(6, "Chapinha", 5);
            ProductEntity p7 = new(7, "Camiseta ", 5);
            ProductEntity p8 = new(8, "Calça ", 5);
            ProductEntity p9 = new(9, "Meia", 5);
            ProductEntity p10 = new(10, "Monitor", 5);
            ProductEntity p11 = new(11, "Teclado", 5);
            ProductEntity p12 = new(12, "Mouse", 5);
            ProductEntity p13 = new(13, "Fone de Ouvido", 5);
            ProductEntity p14 = new(14, "Câmera", 5);
            ProductEntity p15 = new(15, "Geladeira", 5);
            ProductEntity p16 = new(16, "Fogão", 5);
            ProductEntity p17 = new(17, "Vestido", 5);
            ProductEntity p18 = new(18, "Terno", 5);
            ProductEntity p19 = new(19, "Tênis", 5);
            ProductEntity p20 = new(20, "Relógio", 5);

            DepartmentEntity d1 = new DepartmentEntity(1, "Computers");
            DepartmentEntity d2 = new DepartmentEntity(2, "Eletronics");
            DepartmentEntity d3 = new DepartmentEntity(3, "Fashion");

            SellerEntity s1 = new SellerEntity(1, "oaugust265@gmail.com", "Otavio Augusto", new DateTime(2005, 03, 20), 1981.00, d1);
            SellerEntity s2 = new SellerEntity(2, "brukita@gmail.com", "Bruna Kitahara", new DateTime(2005, 01, 21), 2000.00, d1);
            SellerEntity s3 = new SellerEntity(3, "marcos@gmail.com", "Marcos", new DateTime(2003, 04, 21), 1981.00, d1);
            SellerEntity s4 = new SellerEntity(4, "felipe@gmail.com", "Felipe", new DateTime(2002, 05, 22), 5000.00, d2);
            SellerEntity s5 = new SellerEntity(5, "lucas@gmail.com", "Lucas", new DateTime(2001, 06, 23), 4000.00, d2);
            SellerEntity s6 = new SellerEntity(6, "artur@gmail.com", "Artur", new DateTime(2000, 07, 24), 3000.00, d2);
            SellerEntity s7 = new SellerEntity(7, "eduardo@gmail.com", "Eduardo", new DateTime(1999, 08, 25), 1500.00, d3);
            SellerEntity s8 = new SellerEntity(8, "leticia@gmail.com", "Leticia", new DateTime(1998, 09, 26), 1781.00, d3);
            SellerEntity s9 = new SellerEntity(9, "jonas@gmail.com", "Jonas", new DateTime(1997, 10, 27), 1900.00, d3);

            SalesRecordEntity sr1 = new SalesRecordEntity(1, SaleStatus.BILLED, 3000.00, s1);
            SalesRecordEntity sr2 = new SalesRecordEntity(2, SaleStatus.BILLED, 4000.00, s2);
            SalesRecordEntity sr3 = new SalesRecordEntity(3, SaleStatus.BILLED, 5000.00, s3);
            SalesRecordEntity sr4 = new SalesRecordEntity(4, SaleStatus.BILLED, 6000.00, s4);
            SalesRecordEntity sr5 = new SalesRecordEntity(5, SaleStatus.BILLED, 7000.00, s5);
            SalesRecordEntity sr6 = new SalesRecordEntity(6, SaleStatus.BILLED, 8000.00, s6);
            SalesRecordEntity sr7 = new SalesRecordEntity(7, SaleStatus.BILLED, 9000.00, s7);
            SalesRecordEntity sr8 = new SalesRecordEntity(8, SaleStatus.BILLED, 1000.00, s8);
            SalesRecordEntity sr9 = new SalesRecordEntity(9, SaleStatus.BILLED, 1100.00, s9);
            SalesRecordEntity sr10 = new SalesRecordEntity(10, SaleStatus.BILLED, 1200.00, s1);
            SalesRecordEntity sr11 = new SalesRecordEntity(11, SaleStatus.BILLED, 1300.00, s2);
            SalesRecordEntity sr12 = new SalesRecordEntity(12, SaleStatus.BILLED, 1400.00, s3);
            SalesRecordEntity sr13 = new SalesRecordEntity(13, SaleStatus.BILLED, 1500.00, s4);
            SalesRecordEntity sr14 = new SalesRecordEntity(14, SaleStatus.BILLED, 1600.00, s5);
            SalesRecordEntity sr15 = new SalesRecordEntity(15, SaleStatus.BILLED, 1700.00, s6);
            SalesRecordEntity sr16 = new SalesRecordEntity(16, SaleStatus.BILLED, 1800.00, s7);
            SalesRecordEntity sr17 = new SalesRecordEntity(17, SaleStatus.BILLED, 1900.00, s8);
            SalesRecordEntity sr18 = new SalesRecordEntity(18, SaleStatus.BILLED, 2000.00, s9);
            SalesRecordEntity sr19 = new SalesRecordEntity(19, SaleStatus.BILLED, 2100.00, s1);
            SalesRecordEntity sr20 = new SalesRecordEntity(20, SaleStatus.BILLED, 2200.00, s2);

            SalesProductEntity sp1 = new(1, sr1, p1, 2);
            SalesProductEntity sp2 = new(2, sr1, p10, 1);
            SalesProductEntity sp3 = new(3, sr2, p2, 3);
            SalesProductEntity sp4 = new(4, sr2, p11, 2);
            SalesProductEntity sp5 = new(5, sr3, p3, 1);
            SalesProductEntity sp6 = new(6, sr3, p12, 2);
            SalesProductEntity sp7 = new(7, sr4, p4, 4);
            SalesProductEntity sp8 = new(8, sr4, p13, 3);
            SalesProductEntity sp9 = new(9, sr5, p5, 2);
            SalesProductEntity sp10 = new(10, sr5, p14, 1);
            SalesProductEntity sp11 = new(11, sr6, p6, 3);
            SalesProductEntity sp12 = new(12, sr6, p15, 1);
            SalesProductEntity sp13 = new(13, sr7, p7, 5);
            SalesProductEntity sp14 = new(14, sr7, p16, 2);
            SalesProductEntity sp15 = new(15, sr8, p8, 3);
            SalesProductEntity sp16 = new(16, sr8, p17, 4);
            SalesProductEntity sp17 = new(17, sr9, p9, 1);
            SalesProductEntity sp18 = new(18, sr9, p18, 2);
            SalesProductEntity sp19 = new(19, sr10, p19, 2);
            SalesProductEntity sp20 = new(20, sr10, p20, 1);
            SalesProductEntity sp21 = new(21, sr11, p1, 2);
            SalesProductEntity sp22 = new(22, sr11, p2, 3);
            SalesProductEntity sp23 = new(23, sr12, p3, 4);
            SalesProductEntity sp24 = new(24, sr12, p4, 1);
            SalesProductEntity sp25 = new(25, sr13, p5, 3);
            SalesProductEntity sp26 = new(26, sr13, p6, 2);
            SalesProductEntity sp27 = new(27, sr14, p7, 5);
            SalesProductEntity sp28 = new(28, sr14, p8, 3);
            SalesProductEntity sp29 = new(29, sr15, p9, 1);
            SalesProductEntity sp30 = new(30, sr15, p10, 2);


            _context.Departments.AddRange(d1, d2, d3);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6, s7, s8, s9);
            _context.Sales.AddRange(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10, sr11, sr12, sr13, sr14, sr15, sr16, sr17, sr18, sr19, sr20);
            _context.Product.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20);

            _context.SalesProduct.AddRange(new List<SalesProductEntity>
            {
                sp1, sp2, sp3, sp4, sp5, sp6, sp7, sp8, sp9, sp10,
                sp11, sp12, sp13, sp14, sp15, sp16, sp17, sp18, sp19, sp20,
                sp21, sp22, sp23, sp24, sp25, sp26, sp27, sp28, sp29, sp30
            });

            _context.SaveChanges();
        }

    }
}
