using CleanCode.Examples.Infrastructure;

namespace CleanCode.Examples
{
    class Example11_Result
    {
        UserContext db;

        public void Authenticate(string login, string password)
        {
            var user = db.Find(login);

            if (user == null)
            {
                return;
            }

            if (CheckPassword(user, password))
            {
                Session.Init(user);
            }
        }

        public bool CheckPassword(User user, string password)
        {
            if (user.Password == password)
            {
                return true;
            }

            return false;
        }
    }
}
