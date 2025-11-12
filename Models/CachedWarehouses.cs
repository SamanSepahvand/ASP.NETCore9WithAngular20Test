using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourApp.Models
{
    [Table("CachedWarehouses")]
    public class CachedWarehouses
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(4)]
        public string Code { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string? PostalCode { get; set; }

        [MaxLength(50)]
        public string? MeliCode { get; set; }

        [MaxLength(50)]
        public string? EconomicCode { get; set; }

        public int? ParentId { get; set; }

        [Required]
        public int WarehouseTypeId { get; set; }

        public int? CenterTypeId { get; set; }

        [Required, MaxLength(250)]
        public string Address { get; set; }

        [Required, MaxLength(50)]
        public string Tel { get; set; }

        [MaxLength(50)]
        public string? Fax { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        public int? PersonnelId { get; set; }

        [Required, MaxLength(100)]
        public string ManagerName { get; set; }

        [Required]
        public bool IsEnable { get; set; }

        public int? Sort { get; set; }

        public int? Periority { get; set; }

        [Required]
        public int CreatorUserId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public bool ScanRequired { get; set; }

        public string? GLN { get; set; }  // nvarchar(max)

        [MaxLength(100)]
        public string? Latitude { get; set; }

        [MaxLength(100)]
        public string? Longitude { get; set; }

        public int? AreaId { get; set; }

        public int? CenterOrWarehouseTypeId { get; set; }

        [Required]
        public bool IsControlSeparate { get; set; }

        public bool? IsSaleCenter { get; set; }

        [MaxLength(10)]
        public string? TafsilNo { get; set; }
    }
}
