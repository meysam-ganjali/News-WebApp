﻿using Microsoft.AspNetCore.Identity;

namespace News.Domain.Models;

public class ApplicationUser: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsActive { get; set; } = true;
}