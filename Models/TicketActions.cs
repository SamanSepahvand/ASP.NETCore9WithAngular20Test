using CoreAngular1.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace YourApp.Models
{
    [Table("TicketActions")]
    public class TicketActions
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Tickets Ticket { get; set; } = null!;

        public int UserId { get; set; }
        public CachedUsers User { get; set; } = null!;

        public string ActionType { get; set; } = null!;
        public string? ActionNote { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
