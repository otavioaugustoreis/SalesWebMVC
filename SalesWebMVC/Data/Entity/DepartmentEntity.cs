using SalesWebMVC.Patterns;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMVC.Data.Entity
{
    public class DepartmentEntity : EntityPattern
    {
        
        [Column("DsNome")]
        public string DsNome { get; set; }

        public List<SellerEntity> ListSeller { get; set; } = new List<SellerEntity>();

        public DepartmentEntity(int id, string DsNome) : base(id)
        {
            this.DsNome = DsNome;
        }

        public DepartmentEntity() :
            base()
        {
        }

        public void AddSeller(SellerEntity seller)
        {
            ListSeller.Add(seller);
        }



        
    }
}
