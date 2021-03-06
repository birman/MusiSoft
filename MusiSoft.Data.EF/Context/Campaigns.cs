//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusiSoft.Data.EF.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Campaigns
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Campaigns()
        {
            this.MusicGenres = new HashSet<MusicGenres>();
            this.CampaignsCustomers = new HashSet<CampaignsCustomers>();
        }
    
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Objective { get; set; }
        public string Description { get; set; }
        public int MusicalGenreId { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual Companies Companies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MusicGenres> MusicGenres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampaignsCustomers> CampaignsCustomers { get; set; }
    }
}
