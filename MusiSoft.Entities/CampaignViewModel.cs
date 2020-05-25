using System;
using System.ComponentModel.DataAnnotations;

namespace MusiSoft.Entities
{
    public class CampaignViewModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Objective { get; set; }
        public string Description { get; set; }
        public int MusicalGenreId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}