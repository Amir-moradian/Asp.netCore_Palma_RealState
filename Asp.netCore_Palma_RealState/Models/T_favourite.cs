using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.netCore_Palma_RealState.Models
{
    public class T_favourite
    {
       [Key]
        public int ID_favourite { get; set; }
        public int? id_estate { get; set; }
        public string? id_user { get; set; }

        #region relation

        [ForeignKey(nameof(id_estate))]
        public T_estate? t_estate { get; set; }
        [ForeignKey(nameof(id_user))]
        public User_Model? t_usermodel {get; set; }

        #endregion
    }
}
