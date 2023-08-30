using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TP2.Models;
using TP2.Models.Data;
using TP2.Utility;

namespace TP2.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly TPDbContext _baseDonnees;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            TPDbContext baseDonnees)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _baseDonnees = baseDonnees;
        }


        public void Initialize()
        {
            try
            {
                if (_baseDonnees.Database.GetPendingMigrations().Count() > 0)
                {
                    _baseDonnees.Database.Migrate();
                }
            }
            catch (Exception ex) { }

            if (!_roleManager.RoleExistsAsync(AppConstants.AdminRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(AppConstants.AdminRole))
                    .GetAwaiter().GetResult();

                _roleManager.CreateAsync(new IdentityRole(AppConstants.ChefEquipeRole))
                    .GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(AppConstants.VendeurRole))
                    .GetAwaiter().GetResult();

                // Créer un User pour le rôle Admin
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Honganh@movieblue.com",
                    Email = "   Honganh@movieblue.com",
                    NickName = "Anh Nguyen",
                    PhoneNumber = "1111111111",
                    EmailConfirmed = true
                }, "AdminRole123@").GetAwaiter().GetResult();
                ApplicationUser user = _baseDonnees.ApplicationUsers.FirstOrDefault(u => u.Email == "Honganh@movieblue.com");
                _userManager.AddToRoleAsync(user, AppConstants.AdminRole)
                    .GetAwaiter().GetResult();

                // Créer  User pour le rôle Chef d'equipe
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "ChefEquipe@movieblue.com",
                    Email = "ChefEquipe@movieblue.com",
                    NickName = "Chef D'équipe",
                    PhoneNumber = "1111111111",
                    EmailConfirmed = true,
                }, "ChefEquipeRole123*").GetAwaiter().GetResult();
                ApplicationUser user2 = _baseDonnees.ApplicationUsers.FirstOrDefault(u => u.Email == "ChefEquipe@movieblue.com");
                _userManager.AddToRoleAsync(user2, AppConstants.ChefEquipeRole)
                    .GetAwaiter().GetResult();

               

                // Créer  User pour le rôle Vendeur
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Vendeur1@movieblue.com",
                    Email = "Vendeur1@movieblue.com",
                    NickName = "Vendeur1",
                    PhoneNumber = "1111111111",
                    EmailConfirmed = true,
                }, "Vendeur123*").GetAwaiter().GetResult();
                ApplicationUser user4 = _baseDonnees.ApplicationUsers.FirstOrDefault(u => u.Email == "Vendeur1@movieblue.com");
                _userManager.AddToRoleAsync(user4, AppConstants.VendeurRole)
                    .GetAwaiter().GetResult();


            }
        }

    }
}

