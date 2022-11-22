namespace PasswordGenerator.Models
{
    public class PasswordViewModel
    {
        public int PasswordLength { get; set; }

        public string PasswordResult { get; set; }

        public bool UseSpecialCharacters { get; set; }

        public bool UseCapitalLetter { get; set; }
    }
}
