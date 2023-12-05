using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.Entity
{
    [Table("tb_Post")]
    public class Posts : CommonAbtrac
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescripton { get; set; }
        public string SeoKeywords { get; set; }

        public virtual Categorys Categorys { get; set; }
    }
}