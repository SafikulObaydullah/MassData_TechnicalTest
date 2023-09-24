﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Contracts
{
    public interface IFacadeRegistration
    {
        void AddInfrastucture(IServiceCollection service, string conStr);
    }
}
