using Assig1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace Assig1.ViewModels
{
    public class ExpiationStat
    {
        [Display(Name = "Location Id")]
        public int? LocationId { get; set; }

        [Display(Name = "Suburb")]
        public string Suburb { get; set; }

        [Display(Name = "Number of Expiations")]
        public int? TotalIncidents { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}")]
        [Display(Name = "Average Speed of Expiations")]
        public double? AvgSpeed { get; set; }

        [Display(Name = "Highest Recorded Speed")]
        public int? MaxSpeed { get; set; }

        [Display(Name = "Penalty Fee Total")]
        public int? TotalPenaltyFees { get; set; }

        [Display(Name = "Total Fees")]
        public int? TotalFees { get; set; }
    }
}
