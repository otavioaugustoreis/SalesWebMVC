using SalesWebMVC.Data.Enums;
using SalesWebMVC.Patterns;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMVC.Data.Entity
{
    public class SalesRecordEntity : EntityPattern
    {

        public SaleStatus SaleStatus { get; set; }

        [Column("ds_valor")]
        public double Valor { get; set; }

        [Column("fk_seller")]
        public int FkSeller { get; set; }
        public SellerEntity Seller { get; set; }

        public SalesRecordEntity() 
            : base()
        { 
        }

        public SalesRecordEntity(SaleStatus saleStatus, double valor , SellerEntity seller)
        {
            SaleStatus = saleStatus;
            Valor = valor;
            Seller = seller;
        }
    }
}
