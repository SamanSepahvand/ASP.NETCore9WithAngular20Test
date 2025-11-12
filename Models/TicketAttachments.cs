using CoreAngular1.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace YourApp.Models
{
    [Table("TicketAttachments")]
    public class TicketAttachments
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Tickets Ticket { get; set; } = null!;

        public int? MessageId { get; set; }
        public TicketMessages? Message { get; set; }

        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;

        public int UploadedBy { get; set; }
        public CachedUsers Uploader { get; set; } = null!;

        public DateTime UploadedAt { get; set; } = DateTime.Now;
    }

}
