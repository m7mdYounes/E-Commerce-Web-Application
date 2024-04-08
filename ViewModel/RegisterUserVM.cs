namespace E_Commerce.ViewModel
{
    public class RegisterUserVM
    {
        [Required]
        [MinLength(5)]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [StringLength(11)]
        [Required]
        [RegularExpression(@"^\d{11}$")]
        public string phonenumber { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="password not matched")]
        [Required]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }

    }
}
