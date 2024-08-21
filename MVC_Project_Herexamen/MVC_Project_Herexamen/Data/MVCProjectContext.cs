using Microsoft.EntityFrameworkCore;

namespace MVC_Project_Herexamen.Data
{
    public class MVCProjectContext :DbContext
    {
        public MVCProjectContext(DbContextOptions<MVCProjectContext> options) : base(options) { }



    }
}
