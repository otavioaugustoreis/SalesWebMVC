using SalesWebMVC.Data.Entity;
using SalesWebMVC.Data.Enums;

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
               _context.Sales.Any())
            {
                return;
            }


            DepartmentEntity d1 = new DepartmentEntity(1, "Computers");
            DepartmentEntity d2 = new DepartmentEntity(2, "Eletronics");
            DepartmentEntity d3 = new DepartmentEntity(3, "Fashion");



            SellerEntity s1 = new SellerEntity(1, "oaugust265@gmail.com", "Otavio Augusto", new DateTime(2005, 03, 20), 1981.00, d1);
            SellerEntity s2 = new SellerEntity(2, "brukita@gmail.com", "Bruna Kitahara",    new DateTime(2005, 01, 21), 2000.00, d1);
            SellerEntity s3 = new SellerEntity(3, "marcos@gmail.com", "Marcos",   new DateTime(2003, 04, 21), 1981.00, d1);
            SellerEntity s4 = new SellerEntity(4, "felipe@gmail.com", "Felipe",   new DateTime(2002, 05, 22), 5000.00, d2);
            SellerEntity s5 = new SellerEntity(5, "lucas@gmail.com", "Lucas",     new DateTime(2001, 06, 23), 4000.00, d2);
            SellerEntity s6 = new SellerEntity(6, "artur@gmail.com", "Artur",     new DateTime(2000, 07, 24), 3000.00, d2);
            SellerEntity s7 = new SellerEntity(7, "eduardo@gmail.com", "Eduardo", new DateTime(1999, 08, 25), 1500.00, d3);
            SellerEntity s8 = new SellerEntity(8, "leticia@gmail.com", "Leticia", new DateTime(1998, 09, 26), 1781.00, d3);
            SellerEntity s9 = new SellerEntity(9, "jonas@gmail.com", "Jonas",     new DateTime(1997, 10, 27), 1900.00,d3);

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


            _context.Departments.AddRange(d1, d2,d3);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6,s7, s8, s9);

            _context.Sales.AddRange(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10, sr11, sr12, sr13, sr14, sr15, sr16, sr17, sr18, sr19, sr20);

            _context.SaveChanges();
        }

    }
}
