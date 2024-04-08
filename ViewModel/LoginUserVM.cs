using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.ViewModel
{
    public class LoginUserVM
    {
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Remember_Me { get; set; }
    }
}
