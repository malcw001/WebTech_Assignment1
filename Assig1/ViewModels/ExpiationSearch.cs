using Assig1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace Assig1.ViewModels
{
    public class ExpiationSearch
    {

        [Display(Name = "Location Id")]
        public int? LocationId { get; set; }

        [Display(Name = "Location")]
        public SelectList Suburb { get; set; }

        [Display(Name = "List of Expiations")]
        public List<Expiation> ExpiationList { get; set; }
    }
}
