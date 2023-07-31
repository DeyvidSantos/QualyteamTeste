using System.ComponentModel.DataAnnotations;

namespace QualyteamTeste.Models
{
    public class Process
    {
        public int Id { get; set; }
        [Required]
        public string process { get; set; }
    }
}
