using CleanCode.Examples.Infrastructure;

namespace CleanCode.Examples
{
    class Example8
    {
        private ClientContext db;

        public void SendEmailToListOfClients(string[] clients)
        {
            foreach (var client in clients)
            {
                var clientRecord = db.Find(client);
                if (clientRecord.IsActive())
                {
                    Email(client);
                }
            }
        }

        private void Email(string client)
        {
            //send email
        }
    }
}
