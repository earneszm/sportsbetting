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
    public class IdentityTelerikDataAcessUserStore : IUserStore<User>, IUserPasswordStore<User>, IUserLoginStore<User>
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

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }
        

        public Task<User> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByNameAsync(string userName)
        {
            this.ThrowIfDisposed();
            return Task.FromResult<User>(this.Context.Users.FirstOrDefault(o => o.UserName == userName));
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            throw new NotImplementedException();
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


        
    }
}