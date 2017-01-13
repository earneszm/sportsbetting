using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eagle.Entities;
using System.Threading.Tasks;
using Eagle;

namespace sportsbetting.Security
{
    public class IdentityTelerikDataAcessUserStore : IUserStore<User>, IUserPasswordStore<User>, IUserLoginStore<User>, IUserLockoutStore<User, string>,
        IUserTwoFactorStore<User, string>
    {
        private bool _disposed;
        public DataContext Context { get; set; }
        public bool DisposeContext { get; set; }
        public bool AutoSaveChanges { get; set; }

        public IdentityTelerikDataAcessUserStore (DataContext context)
        {
            this.Context = context;
            this.AutoSaveChanges = true;
            this.DisposeContext = true;
        }

        private async Task SaveChanges()
        {
            if (this.AutoSaveChanges)
            {
                await Task.Run(() =>
                    this.Context.SaveChanges());
            }
        }

        public async Task CreateAsync(User user)
        {
            this.ThrowIfDisposed();

            user.Id = Guid.NewGuid().ToString();

            // Load the contact record here so we can write to it also
            //if (user.ContactID != null && user.Contact == null)
            //    user.Contact = this.Context.Get<Contact>(user.ContactID.Value);

            this.Context.Add(user);
            await this.SaveChanges();
        }

        public async Task DeleteAsync(User user)
        {
            this.ThrowIfDisposed();
            this.Context.Delete(user);

            await this.SaveChanges();
        }
        

        public Task<User> FindByIdAsync(string userId)
        {
            this.ThrowIfDisposed();
            return Task.FromResult<User>(this.Context.Users.FirstOrDefault(o => o.Id == userId));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            this.ThrowIfDisposed();
            return Task.FromResult<User>(this.Context.Users.FirstOrDefault(o => o.UserName == userName));
        }

        public async Task UpdateAsync(User user)
        {
            this.ThrowIfDisposed();

            await this.SaveChanges();
        }

        #region Dispose

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                if (this.DisposeContext && disposing && this.Context != null)
                    this.Context.Dispose();

                this._disposed = true;
                this.Context = null;
            }
        }

        private void ThrowIfDisposed()
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().Name);
        }
        #endregion

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            this.ThrowIfDisposed();
            if (user == null)
                throw new ArgumentNullException("user");

            user.PasswordHash = passwordHash;
            return Task.FromResult<int>(0);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            this.ThrowIfDisposed();
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult<string>(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult<bool>(user.PasswordHash != null);
        }

        public Task AddLoginAsync(User user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(User user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            DateTimeOffset offset = DateTime.UtcNow.AddDays(-1);

            //if (user.LockoutEndDate.HasValue)
            //    offset = user.LockoutEndDate.Value;

            return Task.FromResult(offset);
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            //return Task.FromResult(DataUtils.CastAs<int>(user.LockoutAttempts));
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(true);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(false);
            throw new NotImplementedException();
        }
    }
}