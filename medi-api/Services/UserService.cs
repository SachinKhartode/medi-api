using medi_api.dataStore;
using medi_api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace medi_api.Services
{
    public class UserService
    {
        mediEntities context = new mediEntities();

        public string GetUser(User user)
        {
            try
            {
                if(user.UserId == "admin" && user.Password == "admin")
                {
                    return user.UserId;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
         

    }
}