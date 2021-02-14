using System;

namespace GameProject
{
    public class GamerManager : IGamerService
    {
        IUserValidationService _userValidationService;        
        public GamerManager(IUserValidationService userValidationService)
        {
            _userValidationService = userValidationService;
        }

        public void Add(Gamer gamer)
        {
            if (_userValidationService.Validate(gamer))
            {
                Console.WriteLine("Gamer Added!");
            }
            else
            {
                Console.WriteLine("Error : Gamer isnt added!");
            }
        }

        public void Update(Gamer gamer)
        {
            Console.WriteLine("Gamer Updated!");
        }

        public void Delete(Gamer gamer)
        {
            Console.WriteLine("Gamer Deleted!");
        }

    }
}
