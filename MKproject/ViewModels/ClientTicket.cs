using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKproject.ViewModels
{
    public class ClientTicket
    {
        public string TicketId { get; set; }
        public int ClientId { get; set; }
        public string DeviceIp { get; set; }
        public int IsMainDevice { get; set; }
        public int IsUsed { get; set; }
    }

}
