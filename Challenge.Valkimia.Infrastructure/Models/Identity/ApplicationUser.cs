using Microsoft.AspNetCore.Identity;

namespace Challenge.Valkimia.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        #region Constants

        public const string MustChangePasswordClaimType = "user:mustchangepassword";
        public const string FullNameClaimType = "user:fullname";

        #endregion

        /// <summary>
        /// The user's lastname
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// The user's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Flag indicating whether user is active
        /// </summary>
        public bool IsActive { get; set; } = false;

        /// <summary>
        /// Flag indicating that user must change his password
        /// </summary>
        public bool MustChangePassword { get; set; } = false;

        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<ApplicationUserRole> Roles { get; } = new List<ApplicationUserRole>();
    }
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
