using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketSystemProject.Models;

namespace TicketSystemProject.Data
{
    public class TicketSystemProjectContext : DbContext
    {
        public TicketSystemProjectContext(DbContextOptions<TicketSystemProjectContext> options) : base(options)
        {
        }

        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<TicketStatusModel> TicketStatuses { get; set; }
    }
}
