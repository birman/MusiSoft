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
    
    public partial class CampaignsCustomers
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CampaignId { get; set; }
        public System.DateTime CreationDate { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual Campaigns Campaigns { get; set; }
    }
}
