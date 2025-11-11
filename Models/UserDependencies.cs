
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace YourApp.Models
    {
        [Table("UserDependencies")]
        public class UserDependencies
    {
            [Key] // اگر UserId کلید اصلیه
            public int UserId { get; set; }

            public int? WarehouseId { get; set; }

            public int? SupplierId { get; set; }

            public int? CustomerId { get; set; }

            public int? SaleManId { get; set; }

            public int? AreaId { get; set; }

            public int? DistributorId { get; set; }
        }
    }

