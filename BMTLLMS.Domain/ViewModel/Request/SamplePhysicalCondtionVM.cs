﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Request
{
    public class SamplePhysicalCondtionVM
   {
        public Int64 ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Boolean? IsActive { get; set; }

   }
}
