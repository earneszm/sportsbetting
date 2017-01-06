using Eagle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;

namespace Eagle
{
    public partial class DataContext : OpenAccessContext
    {
        private static string connectionStringName = @"connectionId";

        private static BackendConfiguration backend =
            GetBackendConfiguration();

        private static MetadataSource metadataSource =
            new DataContextMetadataSource();

        public DataContext()
            : base(connectionStringName, backend, metadataSource)
        { }

        public IQueryable<Bet> Bets
        {
            get
            {
                return this.GetAll<Bet>();
            }
        }

        public IQueryable<User> Users
        {
            get
            {
                return this.GetAll<User>();
            }
        }


        public static BackendConfiguration GetBackendConfiguration()
        {
            BackendConfiguration backend = new BackendConfiguration();
            backend.Backend = "MsSql";
            backend.ProviderName = "System.Data.SqlClient";

            return backend;
        }
    }
}
