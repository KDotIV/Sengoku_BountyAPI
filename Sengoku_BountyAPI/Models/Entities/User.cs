using Sengoku_BountyAPI.Models.Entities.Core;

namespace Sengoku_BountyAPI.Models.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Bounty> GivenBounties { get; set; }
        public string Region { get; set; }
        public List<string> Games { get; set; }

        public User(string userName, string password, List<Bounty> currentBounty, string region, List<string> games)
        {
            UserName = userName;
            Password = password;
            GivenBounties = currentBounty;
            Region = region;
            Games = games;
        }
    }
}
