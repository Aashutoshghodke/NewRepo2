using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TajHotel.web.Models
{
    [Table(name: "FoodCategories")]

    public class FoodCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FCId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string FoodCategoryName { get; set; }

        #region Navigation Property
        public ICollection<Food> Foods { get; set; }

        #endregion

        
    }
}