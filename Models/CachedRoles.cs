using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourApp.Models
{
    [Table("CachedRole")]
    public class CachedRoles
    {
        [Key]
        public int Id { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public CachedRoles? Parent { get; set; }

        public ICollection<CachedRoles> Children { get; set; } = new List<CachedRoles>();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        // Navigation property برای رابطه با CachedUserRoles
        public ICollection<CachedUserRoles> CachedUserRoles { get; set; } = new List<CachedUserRoles>();
    }
}
