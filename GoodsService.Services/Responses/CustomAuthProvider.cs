using System;

using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using GoodsService.Core.Data;
using GoodsService.Core;

namespace GoodsService.Services.Responses
{
    internal class CustomAuthProvider : CredentialsAuthProvider
    {
       

        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            string s = CheckUser(userName, password);
            if (string.IsNullOrWhiteSpace(s))
            {
                var session = (CustomUserSession) authService.GetSession(false);
                session.UserName = userName;
                //session.UserID = curUser.Id;
                //session.UserAuthId = curUser.Id.ToString();
                session.IsAuthenticated = true;

                return true;
            }
            return false;
        }
        
        private string CheckUser(string userName, string password)
        {
            //IRepository<User> rep = AppEx.Container.GetRepository<User>();
            //var s = password.SHA512Encrypt();
            //curUser  = rep.GetEntity(t => t.Name == userName && t.HashedPassword ==s );

            //if(curUser!=null)
                return "成功";

            return "";
        }
    }
}