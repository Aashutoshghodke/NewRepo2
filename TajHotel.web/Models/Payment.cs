using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TajHotel.web.Models;

namespace TajHotel.Models
{
    [Table(name: "Paymentss")]
    public class PaymentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Payment Id")]
        [Required]
        public int PaymentId { get; set; }


        #region

        public int OrderId { get; set; }

        [ForeignKey(nameof(PaymentDetail.OrderId))]
        public Order Order { get; set; }

        #endregion


        #region

        public int FoodId { get; set; }

        [ForeignKey(nameof(PaymentDetail.FoodId))]
        public Food foods { get; set; }

        #endregion
    }
}