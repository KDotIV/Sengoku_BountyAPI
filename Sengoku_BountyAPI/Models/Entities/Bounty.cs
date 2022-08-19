using Sengoku_BountyAPI.Models.Entities.Core;

namespace Sengoku_BountyAPI.Models.Entities
{
    public class Bounty : Entity
    {
        public double TotalAmount { get; set; }
        public string BountyName { get; set; }
        public string BountyClaimer { get; set; }
    }
}