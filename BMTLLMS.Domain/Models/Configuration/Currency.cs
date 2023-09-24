using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.Models.Configuration
{
    public class Currency
    {
        public Int64 Id { get; set; }

        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets and spaces are allowed.")]
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public Boolean? IsActive { get; set; }
        public Int64 Creator { get; set; }
        public DateTime? CreationDate { get; set; }
        public Int64? Modifier { get; set; }
        public DateTime? ModificationDate { get; set; }


    }
}
