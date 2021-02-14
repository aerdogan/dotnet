using System;

namespace GameProject.Concrete
{
    public class GameManager : IGamerService
    {
        public void Add(Gamer gamer)
        {
            Console.WriteLine("Game Added!");
        }

        public void Update(Gamer gamer)
        {
            Console.WriteLine("Game Updated!");
        }

        public void Delete(Gamer gamer)
        {
            Console.WriteLine("Game Deleted!");
        }
    }
}
