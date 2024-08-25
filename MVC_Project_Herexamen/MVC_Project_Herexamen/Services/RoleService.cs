using Microsoft.AspNetCore.Identity;

namespace MVC_Project_Herexamen.Services
{
    public class RoleService
    {
        #region Privates
        private readonly RoleManager<IdentityRole> _roleManager;
        #endregion

        #region Publics
        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        #endregion

        #region Methods
        public async Task CreateRolesAsync()
        {
            string[] roleNames = { "Beheerder", "Leerkracht", "Directie", "Boekhouding" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
        #endregion
    }
}
