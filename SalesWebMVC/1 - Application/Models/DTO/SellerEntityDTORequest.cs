using SalesWebMVC.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models.DTO
{
    public class SellerEntityDTORequest
    {

        [Required]
        [Display(Name = "Name")]
        public string DsNome { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string DsEmail { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DhAniversario { get; set; }


        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Salary")]
        public double NrSalario { get; set; }

        public int FkDepartamento { get; set; }

        public DepartmentEntity Department { get; set; }
    }
}
