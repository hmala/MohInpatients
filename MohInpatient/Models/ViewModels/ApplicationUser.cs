﻿using Microsoft.AspNetCore.Identity;

namespace MOHIdentity.Models
{
    public class ApplicationUser :IdentityUser
    {
         public string? Gender { get; set; }
         public string? Address { get; set; }

    }
}
