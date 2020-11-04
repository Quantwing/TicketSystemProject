using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketSystemProject.Models
{
    public class TicketStatusModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
