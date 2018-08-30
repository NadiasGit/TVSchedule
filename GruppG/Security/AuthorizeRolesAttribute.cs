using GruppG.Data;
using GruppG.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppG.Security
{
    //Från Eriks FL5
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private readonly string[] userAssignedRole;
        private U4Entities db = new U4Entities();
        private PersonData pd = new PersonData();

        public AuthorizeRolesAttribute(params string[] roles)
        {
            this.userAssignedRole = roles;
        }
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var roles in userAssignedRole)
            {
                authorize = pd.UserInRole(httpContext.User.Identity.Name, roles);

                if (authorize)
                    return authorize;
            }
            return authorize;
        }

    }
}