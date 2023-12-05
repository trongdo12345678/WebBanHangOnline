using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace WebBanHangOnline.Models.Entity
{
    [Table("tb_Category")]
    public class Categorys : CommonAbtrac
    {
        //liên kết các bản với nhau
        public Categorys()
        {
            this.News = new HashSet<News>();
        }
        //khóa chính tự tăng dần
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //bắt lỗi ngay trên private
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        [StringLength(150)]
        public string SeoTitle { get; set; }
        [StringLength(250)]
        public string SeoDescripton { get; set; }
        [StringLength(150)]
        public string SeoKeywords { get; set; }
        public int Position { get; set; }

        public ICollection<News> News { get; set; }

        public ICollection<Posts> Posts { get; set; }

    }
}