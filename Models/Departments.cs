using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace YourApp.Models
{
    [Table("Departments")]
    public class Departments
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int? ParentDepartmentId { get; set; }
        public Departments? ParentDepartment { get; set; }
        public ICollection<Departments> ChildDepartments { get; set; } = new List<Departments>();


        [InverseProperty("FromDepartment")]
        public ICollection<Tickets>? FromTickets { get; set; }

        [InverseProperty("ToDepartment")]
        public ICollection<Tickets>? ToTickets { get; set; }
    }
}
