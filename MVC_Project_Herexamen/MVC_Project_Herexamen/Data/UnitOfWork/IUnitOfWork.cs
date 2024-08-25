using MVC_Project_Herexamen.Data.Repository;
using MVC_Project_Herexamen.Models;
using System.Threading.Tasks;

namespace MVC_Project_Herexamen.Data
{
    public interface IUnitOfWork
    {
        IRepository<Purchase> Purchases { get; }
        IRepository<Product> Products { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<FileAttachment> FileAttachments { get; }
        Task<int> SaveAsync();
    }
}
