using System;
namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IClientRepository Client { get; }

        void Save();
    }
}

