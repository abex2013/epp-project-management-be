﻿using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.Interface.Service;
using Excellerent.SharedModules.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Domain.Interfaces.Services
{
    public interface IDeviceDetailsService : ICRUD<DeviceDetailsEntity, DeviceDetails>
    {
    }
}
