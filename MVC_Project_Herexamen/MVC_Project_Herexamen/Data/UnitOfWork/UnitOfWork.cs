using MVC_Project_Herexamen.Data.Repositories;
using MVC_Project_Herexamen.Data.Repository;
using MVC_Project_Herexamen.Models;
using System.Threading.Tasks;

namespace MVC_Project_Herexamen.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MVCProjectContext _context;

        public UnitOfWork(MVCProjectContext context)
        {
            _context = context;
            Purchases = new Repository<Purchase>(_context);
            Products = new Repository<Product>(_context);
            Subjects = new Repository<Subject>(_context);
            FileAttachments = new Repository<FileAttachment>(_context);
        }

        public IRepository<Purchase> Purchases { get; private set; }
        public IRepository<Product> Products { get; private set; }
        public IRepository<Subject> Subjects { get; private set; }
        public IRepository<FileAttachment> FileAttachments { get; private set; }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
