using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.Dtos
{
    public class AccountResultResponse
    {
        public AccountResultResponse(bool succeeded, ClaimsPrincipal claimsPrincipal = null, UserBaseModel user = null)
        {
            Succeeded = succeeded;
            User = user;
            ClaimsPrincipal = claimsPrincipal;
        }

        public bool Succeeded { get; set; }
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
        public UserBaseModel User { get; set; }
    }
}