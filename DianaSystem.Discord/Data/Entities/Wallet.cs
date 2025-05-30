using System.ComponentModel.DataAnnotations.Schema;

namespace DianaSystem.Discord.Data.Entities
{
    [Table("wallets")]
    public class Wallet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("balance")]
        public long Balance { get; set; } = 0;
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
    } 
}
