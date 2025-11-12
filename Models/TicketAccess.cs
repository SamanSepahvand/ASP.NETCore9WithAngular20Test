using CoreAngular1.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace YourApp.Models
{
    [Table("TicketAccess")]
    public class TicketAccess
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Tickets Ticket { get; set; } = null!;

        public int UserId { get; set; }
        public CachedUsers User { get; set; } = null!;

        public bool CanView { get; set; } = true;
        public bool CanReply { get; set; } = true;
        public bool CanRefer { get; set; } = false;
    }


}
