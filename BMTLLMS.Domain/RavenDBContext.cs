using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain
{
    public class RavenDBContext:DbContext
    { 
        public RavenDBContext(DbContextOptions<RavenDBContext> options) : base(options)
        {

        }
    }
}
