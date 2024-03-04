using System.ComponentModel.DataAnnotations;

namespace AV.ForeignExchangeRates.Front.Models
{
    public class Account
    {
        [Required]
        [Display(Prompt = "CLIENT ID", Name = "Client Id")]
        public string? ClientId { get; set; }
        [Required]
        [Display(Prompt = "USER ID", Name = "User Id")]
        public string? UserId { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
