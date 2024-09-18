using Assig1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace Assig1.ViewModels
{
    public class ExpiationSearch
    {
        [Display(Name = "Expiation Search")]
        [StringLength(100, ErrorMessage = "The item name must be less than 100 chracters")]
        public string SearchText { get; set; }

        [Display(Name = "Category Codes")]
        public int? CategoryId { get; set; }

        [Display(Name = "Name of Categories")]
        public SelectList CategoryName { get; set; }

        [Display(Name = "List of Offences")]
        public List<Offence> ItemList { get; set; }


    }
}
