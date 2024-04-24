using System;
namespace WMBProject.Core.Features.Authentication.Queries.Responses
{
    public class GetUserResponse
    {
        public int Id { get; set; } 

        public string? Email { get; set; } 

        public string? Address { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

    }
}

