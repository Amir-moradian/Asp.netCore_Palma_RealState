using System.ComponentModel.DataAnnotations;

namespace Asp.netCore_Palma_RealState.Models
{
    public class T_category
    {
        [Key]
        public int ID_category { get; set; }

        [Display(Name = "عنوان ")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50)]
        public string tittle { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000)]
        public string? description { get; set; }

        //===============================//

        //===============================//

        #region Relation

        public ICollection<T_estate>? t_estate { get; set; }

        #endregion

    }
}
