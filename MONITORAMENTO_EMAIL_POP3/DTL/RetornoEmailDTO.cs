using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONITORAMENTO_EMAIL_POP3.DTL
{
    public static class RetornoEmailDTO
    {
        public static string Assunto { get; set; }
        public static string Corpo { get; set; }
        public static string Data { get; set; }
        public static string Token { get; set; }
    }
}
