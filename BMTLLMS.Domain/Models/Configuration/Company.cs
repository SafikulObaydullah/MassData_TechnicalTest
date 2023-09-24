using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.Models.Configuration
{
   public class Company
   {
      public Int64 Id { get; set; }
      public string? Name { get; set; }
      public string? Logo { get; set; }
      public string? WebsiteAddress { get; set; }  
      public string? EmailAddress { get; set; } 
      public string? PhoneNumber { get; set; }   
      public string? PhysicalAddress { get; set; } 
      public string? Fax { get; set; }
      public string? LocationLat { get; set; }
      public string? LocationLng { get; set; }
      public Boolean? isActive { get; set; }
      public Int64 Creator { get; set; }
      public DateTime? CreationDate { get; set; }
      public Int64? Modifier { get; set; }
      public DateTime? ModificationDate { get; set; }
   }
}
