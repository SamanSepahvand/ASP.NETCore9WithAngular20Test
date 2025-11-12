using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAngular1.Models
{
    [Table("CachedUsers")]
    public class CachedUsers
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(50)]
        public string Password { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string? Job { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(50)]
        public string? Tell { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Ip { get; set; }

        public int? ParentId { get; set; }

        public int? CostCenterId { get; set; }

        [Required]
        public int UserTypeId { get; set; }

        [Required]
        public bool IsEnable { get; set; }

        public DateTime? ChangePasswordDate { get; set; }

        public Guid? Picture { get; set; }

        [Required]
        public int CreatorUserId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public bool? Gender { get; set; }

        public int? PersonnelId { get; set; }
 
    }
}