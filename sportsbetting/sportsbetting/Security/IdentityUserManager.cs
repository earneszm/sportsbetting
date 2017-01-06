using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using System;
using System.Configuration;
using Eagle.Entities;
using Eagle;

namespace sportsbetting.Security
{
        // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
        public class IdentityUserManager : UserManager<User>
        {
            public IdentityUserManager(IUserStore<User> store)
                : base(store)
            {
            }

            public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options, IOwinContext context)
            {
                var manager = new IdentityUserManager(new IdentityTelerikDataAcessUserStore(context.Get<DataContext>()));

                // Configure validation logic for usernames
                //manager.UserValidator = new UserValidator<User>(manager)
                //{
                //    AllowOnlyAlphanumericUserNames = false,
                //    RequireUniqueEmail = true
                //};

                //// Configure validation logic for passwords
                //manager.PasswordValidator = new PasswordValidator
                //{
                //    RequiredLength = 6,
                //    RequireNonLetterOrDigit = true,
                //    RequireDigit = true,
                //    RequireLowercase = true,
                //    RequireUppercase = true,
                //};

                //// Configure user lockout defaults
                //manager.UserLockoutEnabledByDefault = true;
                //manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //manager.MaxFailedAccessAttemptsBeforeLockout = 5;

                //// Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
                //// You can write your own provider and plug it in here.
                ////manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
                ////{
                ////    MessageFormat = "Your security code is {0}"
                ////});
                ////manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
                ////{
                ////    Subject = "Security Code",
                ////    BodyFormat = "Your security code is {0}"
                ////});
                //manager.EmailService = new EmailService();
                //manager.SmsService = new SmsService();
                //var dataProtectionProvider = options.DataProtectionProvider;
                //if (dataProtectionProvider != null)
                //{
                //    manager.UserTokenProvider =
                //        new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
                //}
                return manager;
            }
        
    }
}