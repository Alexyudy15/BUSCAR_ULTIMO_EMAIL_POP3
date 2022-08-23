using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONITORAMENTO_EMAIL_POP3.DTL
{
    class FilaDTO
    {
        public string MessageID { get; set; }
        public string Link { get; set; }
        public string Data { get; set; }
        public string Acao { get; set; }

        public FilaDTO(string message, string link, string data, string acao)
        {
            MessageID = message;
            Link = link;
            Data = data;
            Acao = acao;

        }

        public FilaDTO()
        {
        }
    }
}
