using CoreAngular1.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace YourApp.Models
{
    [Table("TicketTransfers")]
    public class TicketTransfers
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Tickets Ticket { get; set; } = null!;

        public int FromUserId { get; set; }
        public CachedUsers FromUser { get; set; } = null!;

        public int ToUserId { get; set; }
        public CachedUsers ToUser { get; set; } = null!;

        public int? FromDepartmentId { get; set; }
        public Departments? FromDepartment { get; set; }

        public int? ToDepartmentId { get; set; }
        public Departments? ToDepartment { get; set; }

        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
