using GameProject.Abstract;
using GameProject.Entities;
using System;

namespace GameProject.Concrete
{
    public class SalesManager : ISalesService
    {
        public void Sales(Gamer gamer, Game game)
        {
            Console.WriteLine(gamer.FirstName + " bought the " + game.GameName);
        }

        public void CampaignSales(Game game, Gamer gamer, Campaign campaign)
        {
            Console.WriteLine(gamer.FirstName + " bought the "+ game.GameName +"  with a " + campaign.CampaingName);
        }
    }
}
