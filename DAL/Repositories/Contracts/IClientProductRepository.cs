﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Contracts
{
    public interface IClientProductRepository : IRepository<ClientProduct>
    {
        Task<ClientProduct?> GetClientProductDetailsById(string id);

    }
}
