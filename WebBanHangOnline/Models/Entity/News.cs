using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHangOnline.Models.Entity
{
    [Table("Tb_New")]
    public class News : CommonAbtrac
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Bạn không để trống tiêu đề tin.")]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public string Image { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescripton { get; set; }
        public string SeoKeywords { get; set; }
        public bool IsActived { get; set; }

        public virtual Categorys Categorys { get; set; }

    }
}