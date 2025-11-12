using CoreAngular1.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace YourApp.Models
{
    [Table("Tickets")]
    public class Tickets
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CreatedBy { get; set; }
        public CachedUsers Creator { get; set; } = null!;

        public int? FromDepartmentId { get; set; }
        public Departments? FromDepartment { get; set; }

        public int? ToDepartmentId { get; set; }
        public Departments? ToDepartment { get; set; }

        public string Status { get; set; } = "Open";
        public string Priority { get; set; } = "Normal";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ClosedAt { get; set; }

        public ICollection<TicketMessages> Messages { get; set; } = new List<TicketMessages>();
        public ICollection<TicketTransfers> Transfers { get; set; } = new List<TicketTransfers>();
        public ICollection<TicketAttachments> Attachments { get; set; } = new List<TicketAttachments>();
        public ICollection<TicketAccess> Accesses { get; set; } = new List<TicketAccess>();
    }

}
