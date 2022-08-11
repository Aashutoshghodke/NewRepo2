using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TajHotel.web.Models;

namespace TajHotel.web.Models
{
    [Table(name: "Orders")]
    public class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OrderId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [StringLength(100)]
        public string OrderName { get; set; }


        [Required]
        [DefaultValue(1)]
        public int Quantity { get; set; }

        [Required]
        public DateTime Deliverydate { get; set; }

        


    }
}
