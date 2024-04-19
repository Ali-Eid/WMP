using System;
using Microsoft.AspNetCore.Identity;

namespace WMBProject.Data.Entities
{
    public partial class User : IdentityUser<long>
    {
        public User()
        {
            UserInvoices = new HashSet<Invoice>();
        }
        public required string Username { get; set; }

        public required string Password { get; set; }

        public string? FirstName { get; set; } = null;

        public string? LastName { get; set; } = null;

        public string? Address { get; set; }

        public string? RefreshToken { get; set; }

        public string? VerificationCode { get; set; }

        public bool IsActive { get; set; } = true;

        public bool Deleted { get; set; } = false;

        public ICollection<Invoice> UserInvoices { get; set; }

    }
}

