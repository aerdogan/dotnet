using GameProject;
using GameProject.Concrete;
using GameProject.Entities;

namespace GameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Let's increase the attraction */
            Campaign campaign1 = new Campaign() { CampaingId = 1, CampaingName = "New Year Campaign", DiscountRate = 7 };
            Campaign campaign2 = new Campaign() { CampaingId = 2, CampaingName = "Best Player Campaign", DiscountRate = 10 };

            CampaignManager campaignManager = new CampaignManager();
            campaignManager.Add(campaign1);
            campaignManager.Add(campaign2);

            /* players are ready */
            GamerManager gamerManager = new GamerManager(new UserValidationManager());

            Gamer gamer1 = new Gamer();
            gamer1.Id = 1;
            gamer1.FirstName = "gamer 1";
            gamer1.LastName = "lastname 1";
            gamer1.IdentityNumber = "00000000001";
            gamer1.BirthOfYear = 2005;
            gamerManager.Add(gamer1);

            Gamer gamer2 = new Gamer();
            gamer2.Id = 2;
            gamer2.FirstName = "gamer 2";
            gamer2.LastName = "lastname 2";
            gamer2.IdentityNumber = "00000000002";
            gamer2.BirthOfYear = 2004;
            gamerManager.Add(gamer2);

            /*Games in Stock */
            Game game1 = new Game() { GameName = "Tetris", GameId = 1, Price = 20, Discount = 5 };
            Game game2 = new Game() { GameName = "Pacman", GameId = 2, Price = 17, Discount = 3 };
            Game game3 = new Game() { GameName = "Mario",  GameId = 3, Price = 25, Discount = 5 };

            /* Let's sell some fun.. */
            SalesManager salesManager = new SalesManager();
            salesManager.Sales(gamer1, game2);
            salesManager.CampaignSales(game2, gamer1, campaign2);
        }
    }
}
