using System.ComponentModel.DataAnnotations.Schema;

namespace DianaSystem.Discord.Data.Entities
{
    [Table("users")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("discord_id")]
        public string DiscordId { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}
