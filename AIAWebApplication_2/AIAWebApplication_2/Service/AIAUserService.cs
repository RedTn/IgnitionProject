using AIAWebApplication_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIAWebApplication_2.Service
{
    public class AIAUserService
    {
        ApplicationDbContext db;
        public AIAUserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateAIAAccount(string userName, string firstName, string lastName, string userId)
        {
            AIAUser user = new AIAUser { UserName = userName, FirstName = firstName, LastName = lastName, ApplicationUserId = userId, CanUseSystem = 1 };
            db.AIAUsers.Add(user);
            db.SaveChanges();
        }
    }
}