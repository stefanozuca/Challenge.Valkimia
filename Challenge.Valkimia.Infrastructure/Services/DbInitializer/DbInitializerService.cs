using Challenge.Valkimia.Infrastructure.DbContexts;
using Challenge.Valkimia.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Valkimia.Infrastructure.Services
{
    public class DbInitializerService : IDbInitializerService
    {
        #region Fields
        private static string USER = "DbInitializer";
        private readonly IdentityDbContext _identityContext;
        private readonly ChallengeValkimiaContext _applicationContext;

        #endregion Fields

        #region Constructor

        public DbInitializerService(IdentityDbContext identityContext,
            ChallengeValkimiaContext applicationContext)
        {
            _identityContext = identityContext;
            _applicationContext = applicationContext;
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Execute migrations
        /// </summary>
        public void Migrate()
        {
            _identityContext.Database.Migrate();
            _applicationContext.Database.Migrate();
        }

        public void Seed()
        {
            var applicationRoles = _identityContext.Roles;
            if (!applicationRoles.Any())
            {
                applicationRoles.Add(new ApplicationRole() { Id = "e5adff57-b654-4f30-b6a7-c818e86cda8e", ConcurrencyStamp = "6a1bfaad-4414-4593-895c-a100aedd1741", Name = "User", NormalizedName = "USER" });
                applicationRoles.Add(new ApplicationRole() { Id = "40e668a2-8a53-4907-817c-e4f8c8f72fb4", ConcurrencyStamp = "b47ee50f-0b94-42bd-858c-2f4bacd4bb50", Name = "Admin", NormalizedName = "ADMIN" });
                applicationRoles.Add(new ApplicationRole() { Id = "8fa3842a-98a4-475b-8926-fce6efdc3e6f", ConcurrencyStamp = "b3a92cb9-8d66-47d4-9670-4e110447b887", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" });
            }

            _identityContext.SaveChanges();
            _applicationContext.SaveChanges();
        }

        #endregion Public Methods
    }
}
