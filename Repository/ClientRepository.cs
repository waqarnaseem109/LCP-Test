﻿using System;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ClientRepository:RepositoryBase<Client>,IClientRepository
    {
        public ClientRepository(RepositoryContext context):base(context)
        {
        }
    }
}

