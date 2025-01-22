using SalesWebMVC.Data.Entity;
using SalesWebMVC.Patterns;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMVC._3___Data.Entity
{

    [Table("TB_VENDAPRODUTO")]
    public class SalesProductEntity : EntityPattern
    {
        public SalesRecordEntity SalesRecord { get; set; }
       
        [Column("fk_salesrecord")]
        public int SalesRecordId { get; set; }


        public ProductEntity Product { get; set; }


        [DisplayName("Product")]
        [Column("fk_produto")]
        public int  ProductId { get; set; }

        public  int   Quantity { get; set; }

        public SalesProductEntity(int id, SalesRecordEntity salesRecordEntity, ProductEntity productEntity , int quantity) 
            : base(id)
        {
            Quantity = quantity;
            SalesRecord = salesRecordEntity;
            Product = productEntity;
        }

        public SalesProductEntity()
        {
        }
    }
}
