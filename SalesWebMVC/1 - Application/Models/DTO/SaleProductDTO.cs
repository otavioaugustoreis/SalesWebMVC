using Microsoft.EntityFrameworkCore.Query;
using SalesWebMVC._3___Data.Entity;
using SalesWebMVC.Controllers;
using SalesWebMVC.Data.Entity;

namespace SalesWebMVC.Models.DTO
{
    public class SaleProductDTO
    {
        public IEnumerable<SellerEntity> SellerEntity { get; set; } = new List<SellerEntity>();
        public  IEnumerable<ProductEntity>     ProductEntity { get; set; } =  new List<ProductEntity>();
    }
}
