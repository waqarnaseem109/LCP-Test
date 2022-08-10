using System;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IClientRepository _client;

       
        public IClientRepository Client
        {
            get
            {
                if(_client == null)
                {
                    _client = new ClientRepository(_repoContext);
                }
                return _client;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChangesAsync();
        }
    }
}

