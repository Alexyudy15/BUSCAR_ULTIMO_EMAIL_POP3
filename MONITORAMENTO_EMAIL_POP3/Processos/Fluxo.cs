using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONITORAMENTO_EMAIL_POP3.Processos
{
    class Fluxo : MetodosRobo
    {

        /**
        *Autor: Alex Yudy Kitahara
        *Data: 2022/08/23
        **/
        public void Executar(string Enderecohost, string senha, string emailMonitorado)
        {
            MonitoraEmail(Enderecohost, senha,emailMonitorado);
        }


        private void MonitoraEmail(string Enderecohost, string senha, string emailMonitorado)
        {
            try
            {
                AcessarPlataforma(Enderecohost, senha, emailMonitorado);

            }
            catch (Exception ex)
            {

            }
        }






    }
}
