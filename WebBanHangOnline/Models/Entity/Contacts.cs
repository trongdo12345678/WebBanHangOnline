using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.Entity
{
    [Table("tb_Contact")]
    public class Contacts : CommonAbtrac
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "không được để trống")]
        [StringLength(150, ErrorMessage = "không được quá 150 ký tự")]
        public string Name { get; set; }
        [StringLength(150, ErrorMessage = "không được quá 150 ký tự")]
        public string website { get; set; }
        public string Email { get; set; }
        [StringLength(4000, ErrorMessage = "không được quá 150 ký tự")]
        public string Mess { get; set; }
        public bool IsRead { get; set; }


    }
}