using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.Entity
{
    [Table("tb_Adv")]
    public class Advs : CommonAbtrac
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        [StringLength(150)]
        public string image { get; set; }
        [StringLength(150)]
        public string Link { get; set; }
        public int Type { get; set; }

    }
}