﻿using System.Collections.Generic;

namespace VicStelmak.CIAA.Infrastructure.Identity.Models
{
    /// <summary>
    /// User model.
    /// </summary>
    public class CustomIdentityUserModel
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? LockedOut { get; set; }
        public IEnumerable<string>? Roles { get; set; }
        public IEnumerable<KeyValuePair<string, string>>? Claims { get; set; }
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
    }
}
