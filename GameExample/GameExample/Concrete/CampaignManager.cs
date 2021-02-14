using GameProject.Abstract;
using GameProject.Entities;
using System;

namespace GameProject.Concrete
{
    public class CampaignManager : ICampaignService
    {
        public void Add(Campaign campaign)
        {
            Console.WriteLine("Campaign Added!");
        }

        public void Update(Campaign campaign)
        {
            Console.WriteLine("Campaign Updated!");
        }

        public void Delete(Campaign campaign)
        {
            Console.WriteLine("Campaign Deleted!");
        }
    }
}
