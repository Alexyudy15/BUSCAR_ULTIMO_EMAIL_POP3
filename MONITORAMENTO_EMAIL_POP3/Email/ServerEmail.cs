using MONITORAMENTO_EMAIL_POP3.DTL;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONITORAMENTO_EMAIL_POP3.Email
{
    static class ServerEmail
    {


        public static List<EmailDTO> GetAllEmailsFrom(string server, int port, bool useSsl, string username, string password, string EmailFrom)
        {
            List<EmailDTO> emails = new List<EmailDTO>();

            using (Pop3Client client = new Pop3Client())
            {
                client.Connect(server, port, useSsl);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                for (int i = client.GetMessageCount(); i > 0; i--)
                {
                    if (client.GetMessageHeaders(i).From.HasValidMailAddress && client.GetMessageHeaders(i).From.Address.ToLower().Equals(EmailFrom.ToLower()))
                    {
                        emails.Add(new EmailDTO(client.GetMessage(i), client.GetMessageHeaders(i)));
                    }
                }
                client.Disconnect();
            }
            return emails;
        }

        /// <summary>
        /// Retorna ultimo ema
        /// recente.
        /// </summary>
        public static EmailDTO GetLastEmail(string server, int port, bool useSsl, string username, string password, string EmailFrom)
        {
            try
            {
                EmailDTO email = null;
                using (Pop3Client client = new Pop3Client())
                {
                    client.Connect(server, port, useSsl);

                    // Authenticate ourselves towards the server
                    client.Authenticate(username, password);

                    for (int i = client.GetMessageCount(); i > 0; i--)
                    {
                        if (client.GetMessageHeaders(i).From.HasValidMailAddress && client.GetMessageHeaders(i).From.Address.ToLower().Equals(EmailFrom.ToLower()))
                        {
                            if (email == null)
                            {
                                email = new EmailDTO(client.GetMessage(i), client.GetMessageHeaders(i));
                            }
                        }
                    }
                    client.Disconnect();
                }
                return email;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
