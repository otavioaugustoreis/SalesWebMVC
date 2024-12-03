using SalesWebMVC.Patterns;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMVC.Data.Entity
{
    public class SellerEntity : EntityPattern
    {
        [Column("ds_email")]
        public string DsEmail { get; set; }

        [Column("ds_nome")]
        public string DsNome { get; set; }

        [Column("dh_aniversario")]
        public DateTime DhAniversario { get; set; }

        [Column("nr_salario")]
        public double NrSalario { get; set; }

        public DepartmentEntity Department { get; set; }

        [Column("fk_departamento")]
        public int  FkDepartamento { get; set; }

        public List<SalesRecordEntity> SalesRecords { get; set; }

        public SellerEntity() : base() { }

        public SellerEntity(int id, string dsEmail, string dsNome, DateTime dhAniversario, double nrSalario, DepartmentEntity departmentEntity) :
            base(id)
        {
            DsEmail = dsEmail;
            DsNome = dsNome;
            DhAniversario = dhAniversario;
            NrSalario = nrSalario;
            Department = departmentEntity;
        }

        public void addSales(SalesRecordEntity salesRecordEntity)
        {
            SalesRecords.Add(salesRecordEntity);
        }
    }
}
