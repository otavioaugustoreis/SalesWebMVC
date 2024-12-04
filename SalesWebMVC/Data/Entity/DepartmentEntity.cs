using SalesWebMVC.Patterns;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SalesWebMVC.Data.Entity
{
    //Departamento 
    public class DepartmentEntity : EntityPattern
    {
        
        [Column("DsNome")]
        public string DsNome { get; set; }

        [JsonIgnore]
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
