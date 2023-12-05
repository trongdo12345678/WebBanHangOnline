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
        public Categorys()
        {
            this.News = new HashSet<News>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescripton { get; set; }
        public string SeoKeywords { get; set; }
        public int Position { get; set; }

        public ICollection<News> News { get; set; }

        public ICollection<Posts> Posts { get; set; }

    }
}