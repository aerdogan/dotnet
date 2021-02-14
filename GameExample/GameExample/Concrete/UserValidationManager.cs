namespace GameProject
{
    public class UserValidationManager : IUserValidationService
    {
        public bool Validate(Gamer gamer)
        {
            bool result = false;
            if (gamer.FirstName =="gamer 1" && gamer.LastName == "lastname 1" && gamer.IdentityNumber== "00000000001")
            {
                result = true;
            }
            return result;
        }
    }
}
