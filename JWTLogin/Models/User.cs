using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTLogin.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Display(Name = "id")]
        [Column("iduser")]
        public int Id { get; set; }
        [Display(Name = "nome")]
        [Column("username")]
        public string UserName { get; set; }
        [Display(Name = "password")]
        [Column("password")]
        public string Password { get; set; }
    }

}

