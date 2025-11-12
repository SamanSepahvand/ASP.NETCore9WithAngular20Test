using CoreAngular1.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace YourApp.Models
{
    [Table("TicketMessages")]
    public class TicketMessages
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Tickets Ticket { get; set; } = null!;

        public int SenderId { get; set; }
        public CachedUsers Sender { get; set; } = null!;

        public string Message { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<TicketAttachments>? Attachments { get; set; }
    }

}
