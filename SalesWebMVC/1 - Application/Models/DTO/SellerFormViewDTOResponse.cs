using SalesWebMVC.Data.Entity;

namespace SalesWebMVC.Models.DTO
{
    public class SellerFormViewDTOResponse
    {
        public SellerEntityDTOResponse Seller { get; set; }
        public IEnumerable<DepartmentEntity> Department { get; set; } = new List<DepartmentEntity>();

    }
}
