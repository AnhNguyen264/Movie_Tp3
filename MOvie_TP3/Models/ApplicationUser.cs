﻿using Microsoft.AspNetCore.Identity;

namespace TP2.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string NickName { get; set; }


        
    }
}
