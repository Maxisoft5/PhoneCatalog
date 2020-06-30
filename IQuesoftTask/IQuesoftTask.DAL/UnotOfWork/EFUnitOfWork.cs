using IQuesoftTask.DAL.EF;
using IQuesoftTask.DAL.Repositories;
using IQuesoftTask.DAL.UnotOfWork.Interfaces;
using System;

namespace IQuesoftTask.DAL.UnotOfWork
{
    internal class EFUnitOfWork : IUnitOfWork
    {
        private CatalogDbContext _context;
        private BranchRepository _branchRepository;
        private ProductRepository _productRepository;
        private SellerRepository _sellerRepository;
        private PurchaseRepository _purchaseRepository;
        private bool _disposed = false;
        public EFUnitOfWork(string connectionString)
        {
            _context = new CatalogDbContext(connectionString);
        }
        public BranchRepository Branches
        {
            get
            {
                if (_branchRepository == null)
                    _branchRepository = new BranchRepository(_context);
                return _branchRepository;
            }
        }
        public ProductRepository Products
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_context);
                return _productRepository;
            }
        }
        public SellerRepository Sellers
        {
            get
            {
                if (_sellerRepository == null)
                    _sellerRepository = new SellerRepository(_context);
                return _sellerRepository;
            }
        }
        public PurchaseRepository Purchases
        {
            get
            {
                if (_purchaseRepository == null)
                    _purchaseRepository = new PurchaseRepository(_context);
                return _purchaseRepository;
            }
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this._disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
