using CoreAngular1.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourApp.Models
{
    [Table("CachedUserRoles")]
    public class CachedUserRoles
    {
        public int UserId { get; set; }          // معادل ستون UserId
        public CachedUsers User { get; set; } = null!;  // Navigation به کاربر

        public int RoleId { get; set; }          // معادل ستون RoleId
        public CachedRoles Role { get; set; } = null!;  // Navigation به نقش


    }
}
