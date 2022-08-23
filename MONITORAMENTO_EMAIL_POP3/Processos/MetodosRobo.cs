using MONITORAMENTO_EMAIL_POP3.DTL;
using MONITORAMENTO_EMAIL_POP3.Email;
using MONITORAMENTO_EMAIL_POP3.Robo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MONITORAMENTO_EMAIL_POP3.Processos
{

    /**
     *Autor: Alex Yudy Kitahara
     *Data: 2022/08/23
     *Descrição: Classe responsável por guardar os métodos
     **/

    
    class MetodosRobo
    {
        Browser brw = null;

        protected void AcessarPlataforma(string Enderecohost, string senha, string emailMonitorado)
        {
            try
            {
                    BuscarEmail(Enderecohost,senha,emailMonitorado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BuscarEmail(string username, string senha, string emailMonitorado)
        {
            try
            {
                
                var email = ServerEmail.GetLastEmail("pop3.tmktbrasil.com.br", 110, false, username, senha, emailMonitorado);
                
                if (email != null)
                {
                    if (!String.IsNullOrEmpty(email.Headers.Subject) && !String.IsNullOrEmpty(email.MPText))
                    {
                        RetornoEmailDTO.Assunto = email.Headers.Subject;
                        RetornoEmailDTO.Corpo = email.MPText;
                    }
                    else if (String.IsNullOrEmpty(email.Headers.Subject) && !String.IsNullOrEmpty(email.MPText))
                    {
                        RetornoEmailDTO.Corpo = email.MPText;
                    }
                    else if (!String.IsNullOrEmpty(email.Headers.Subject) && String.IsNullOrEmpty(email.MPText))
                    {
                        RetornoEmailDTO.Assunto = email.Headers.Subject;
                    }
                }
                else
                {
                    RetornoEmailDTO.Corpo = "Não foi localizado nenhum E-mail.";
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

