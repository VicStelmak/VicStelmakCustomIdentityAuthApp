using System.Collections.Generic;

namespace VicStelmak.CIAA.Infrastructure.Identity.Models
{
    /// <summary>
    /// Role model.
    /// </summary>    
    public class CustomIdentityRoleModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<KeyValuePair<string, string>>? Claims { get; set; }
    }
}

