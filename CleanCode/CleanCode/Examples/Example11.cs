using CleanCode.Examples.Infrastructure;

namespace CleanCode.Examples
{
    class Example11
    {
        UserContext db;

        public bool CheckPassword(string login, string password)
        {
            var user = db.Find(login);

            if (user == null)
            {
                return false;
            }

            if (user.Password == password)
            {
                Session.Init(user);
                return true;
            }

            return false;
        }
    }
}
