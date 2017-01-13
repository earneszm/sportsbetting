using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;
using Eagle.Entities;

namespace Eagle
{
    public partial class DataContextMetadataSource : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations =
                new List<MappingConfiguration>();

           

            configurations.Add(MapBet());
            configurations.Add(MapUser());

            return configurations;
        }


        private MappingConfiguration MapBet()
        {
            var mapping = new MappingConfiguration<Bet>();
            mapping.MapType(bet => new
            {
                BetID = bet.BetID,
                Comment = bet.Comment,
                HomeTeam = bet.HomeTeam,
                AwayTeam = bet.AwayTeam,
                FinalScore = bet.FinalScore,
                AddedOn = bet.AddedOn
            }).ToTable("Bet");
            mapping.HasProperty(c => c.BetID).IsIdentity(KeyGenerator.Autoinc);

            DateTimePropertyConfiguration dateTimePropertyConfig = mapping.HasProperty(p => p.AddedOn);
            dateTimePropertyConfig.IsCalculatedOn(DateTimeAutosetMode.Insert);

            return mapping;
        }

        private MappingConfiguration MapUser()
        {
            var mapping = new MappingConfiguration<User>();
            mapping.MapType(user => new
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash
            }).ToTable("User");
            mapping.HasProperty(c => c.Id).IsIdentity();

            return mapping;
        }
    }
}
