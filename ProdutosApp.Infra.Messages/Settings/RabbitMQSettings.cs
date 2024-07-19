using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Messages.Settings
{
    /// <summary>
    /// Classe para mapeamento dos patametros do RabbitMQ
    /// </summary>
    public class RabbitMQSettings
    {
        public string? Hostname { get; set; }
        public int? Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Queue { get; set; }
    }
}
