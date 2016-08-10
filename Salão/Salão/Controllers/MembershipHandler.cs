using Salão.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace Salão.Controllers
{
    internal class MembershipHandler
    {
        public const string ADMINROLE = "Admin";
        public const string EMPLOYEEROLE = "Employee";

        private UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        private RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        public bool CreateUser(ApplicationUser user, string password)
        {
            var result = _userManager.Create(user, password);
            return result.Succeeded;
        }

        public void Login(ApplicationUser user, HttpContextBase context)
        {
            var SignInManager = context.GetOwinContext().Get<ApplicationSignInManager>();
            SignInManager.SignIn(user, false, false);
        }

        public void SetRoleAdmin(string userId)
        {
            if (!_roleManager.RoleExists(ADMINROLE))
            {
                IdentityRole role = new IdentityRole(ADMINROLE);
                _roleManager.Create(role);
            }
            _userManager.AddToRole(userId, ADMINROLE);
        }

        public void SetRoleEmployee(string userId)
        {
            if (!_roleManager.RoleExists(EMPLOYEEROLE))
            {
                IdentityRole role = new IdentityRole(EMPLOYEEROLE);
                _roleManager.Create(role);
            }
            _userManager.AddToRole(userId, EMPLOYEEROLE);
        }
    }
}