using System.Collections.Generic;
using System.Linq;
using CleanCode.Examples.Infrastructure;

namespace CleanCode.Examples
{
    class Example8_Result
    {
        private const string ActiveStatus = "active";
        private ClientContext db;

        public void SendEmailToListOfClients(string[] clients)
        {
            var activeClients = GetActiveCLients(clients);

            foreach (var client in activeClients)
            {
                SendEmail(client);
            }
        }

        private List<Client> GetActiveCLients(string[] clients)
        {
            return db.Find(clients).Where(o => o.Status == ActiveStatus).ToList();
        }


        private void SendEmail(Client client)
        {
            //send email
        }
    }
}
