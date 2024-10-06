using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Assig1.ViewModels
{
    public class OffenceDetail
    {
        [Display(Name = "Offence Code")]
        public string OffenceCode { get; set; }

        [Display(Name = "Offence Description")]
        public string Description { get; set; }

        [Display(Name = "Expiation Fee")]
        public int? ExpiationFee { get; set; }

        [Display(Name = "Adult Levy")]
        public int? AdultLevy { get; set; }

        [Display(Name = "Corporate Fee")]
        public int? CorporateFee { get; set; }

        [Display(Name = "Total Fee")]
        public int? TotalFee { get; set; }

        [Display(Name = "Demerit Points")]
        public int? DemeritPoints { get; set; }

        [Display(Name = "Section Code")]
        public string SectionCode { get; set; }

        [Display(Name = "Section Name")]
        public string SectionName { get; set; }

        [Display(Name = "SectionId")]
        public int SectionId { get; set; }

        [Display(Name = "Category Id")]
        public int? CategoryId { get; set; }

        [Display(Name = "Expiation Category")]
        public string CategoryName { get; set; }
    }
}
