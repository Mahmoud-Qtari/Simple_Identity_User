using System.ComponentModel.DataAnnotations;

namespace Identity_pro.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(40)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(40)]
        public string Password { get; set; }

        [Required]
        [MaxLength(40)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(40)]
        public string Phone { get; set; }
    }
}
