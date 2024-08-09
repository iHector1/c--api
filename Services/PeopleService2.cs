using WebApplication1.Controllers;
namespace WebApplication1.Services
{
    public class PeopleService2 :IPeopleService
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name) || people.Name.Length < 3)
            {
                return false;
            }
            return true;
        }
    }
}
