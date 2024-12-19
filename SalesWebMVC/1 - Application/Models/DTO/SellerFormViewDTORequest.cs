using SalesWebMVC.Data.Entity;

namespace SalesWebMVC.Models.DTO
{
    public class SellerFormViewDTORequest
    {
        public SellerEntityDTORequest Seller { get; set; }
        public IEnumerable<DepartmentEntity> Department { get; set; } = new List<DepartmentEntity>();
    }
}

