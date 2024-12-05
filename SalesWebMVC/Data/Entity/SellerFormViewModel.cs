namespace SalesWebMVC.Data.Entity
{
    public class SellerFormViewModel
    {
        public SellerEntity Seller { get; set; }
        public IEnumerable<DepartmentEntity> Department { get; set; } = new List<DepartmentEntity>();

    }
}
