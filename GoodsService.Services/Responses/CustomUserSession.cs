using System;
using GoodsService.Services.Dtos;
using ServiceStack.ServiceInterface.Auth;

namespace GoodsService.Services.Responses
{
    public class CustomUserSession : AuthUserSession
    {
        public LoginResultDto LoginResult { get; set; }
    }
}