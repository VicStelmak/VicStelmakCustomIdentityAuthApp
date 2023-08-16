namespace VicStelmak.CIAA.Infrastructure.Identity
{
    /// <summary>
    /// General response object.
    /// </summary>    
    public class IdentityManagementResponse
    {
        public bool Success { get; internal set; } = false;
        public string Messages { get; internal set; } = string.Empty;
    }
}

