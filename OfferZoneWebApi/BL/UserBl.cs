using DAL.Models;
using OfferZoneWebApi.Models;

namespace OfferZoneWebApi.BL
{
    public class UserBl
    {
        public static List<User> GetUsers(string email,string password)
        {
            using (var entity = new sampleContext())
            {
                var user = entity.Users.Where(x => x.Email == email && x.PassWord == password).ToList();
                return user;
            };
        }

        public static string registerUser(User user)
        {
            using(var entity = new sampleContext())
            {
                var _user = entity.Users.FirstOrDefault(x => x.Email == user.Email);
                if( _user == null)
                {
                    var newUser = new User()
                    {
                        Email = user.Email,
                        PassWord = user.PassWord,
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                    };
                    entity.Users.Add(newUser);
                    entity.SaveChanges();
                    return "User Registered Successfully";
                }
                else
                {
                    return "Email Already Exist";
                }
            }
        }

    }
}
