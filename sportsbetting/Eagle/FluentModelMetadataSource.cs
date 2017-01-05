using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;

namespace Eagle
{
    public partial class FluentModelMetadataSource : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations =
                new List<MappingConfiguration>();

            var customerMapping = new MappingConfiguration<Bet>();
            customerMapping.MapType(bet => new
            {
                BetID = bet.BetID,
                Comment = bet.Comment,
                HomeTeam = bet.HomeTeam,
                AwayTeam = bet.AwayTeam,
                FinalScore = bet.FinalScore,
                AddedOn = bet.AddedOn
            }).ToTable("Bet");
            customerMapping.HasProperty(c => c.BetID).IsIdentity(KeyGenerator.Autoinc);

            DateTimePropertyConfiguration dateTimePropertyConfig = customerMapping.HasProperty(p => p.AddedOn);
            dateTimePropertyConfig.IsCalculatedOn(DateTimeAutosetMode.Insert);

            configurations.Add(customerMapping);

            return configurations;
        }
    }
}
