using HtmlAgilityPack;
using OpenPop.Mime.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONITORAMENTO_EMAIL_POP3.DTL
{
    public class EmailDTO
    {


        public OpenPop.Mime.Message Message { get; set; }
        public MessageHeader Headers { get; set; }
        public HtmlDocument HtmlBody { get; set; }
        public String MPText { get; set; }



        public EmailDTO(OpenPop.Mime.Message message, MessageHeader headers)
        {
            Message = message;
            Headers = headers;
            MPText = TextBody(message);
            //HtmlBody = ObterCorpoHTML(message);
        }


        public String TextBody(OpenPop.Mime.Message message)
        {
            OpenPop.Mime.MessagePart mpText;
            String Body = null;
            mpText = message.FindFirstPlainTextVersion();
            if (mpText != null)
            {
                Body = mpText.GetBodyAsText();
            }
            return Body;
        }

        //public HtmlDocument ObterCorpoHTML(OpenPop.Mime.Message message)
        //{
        //    HtmlDocument documento = new HtmlDocument();
        //    documento.LoadHtml(message.ToMailMessage().Body.ToString());
        //    string Corpo = message.ToMailMessage().Body;
        //    return documento;
        //}
    }
}
