using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.netCore_Palma_RealState.Models
{
    public class T_estate
    {
        [Key]
        public int ID_estate { get; set; }

        [Display(Name = "عنوان ")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "نباید بیشتر از {1}کاراکتر باشد ")]
        public string? tittle { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000)]
        public string? description { get; set; }

        [Display(Name = "متراژ")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public int? metrage { get; set; }

        public string? image { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public double? price { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(500)]
        public string? address { get; set; }


        //===============================//
        public int? id_category { get; set; }
        //===============================//

        #region Relation
        [ForeignKey(nameof(id_category))]
        public T_category? t_category { get; set; }

        #endregion

    }
}
