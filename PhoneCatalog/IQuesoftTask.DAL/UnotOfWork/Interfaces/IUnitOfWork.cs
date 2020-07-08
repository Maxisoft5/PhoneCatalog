using IQuesoftTask.DAL.Repositories;
using System;

namespace IQuesoftTask.DAL.UnotOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        BranchRepository Branches { get; }
        ProductRepository Products { get; }
        PurchaseRepository Purchases { get; }
        SellerRepository Sellers { get; }
        void Save();
    }
}
