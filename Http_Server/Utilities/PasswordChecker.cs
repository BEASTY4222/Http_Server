
namespace Utilities
{
    public static class PasswordChecker
    {
        public static void IsValidPassword(string password)
        {
            // Check if the password is null or empty
            if (password == null && password == "")
                throw new ArgumentException("Password cannot be empty");
    
            // Check if the password is at least 6 characters long
            if (password.Length < 6)
                throw new ArgumentException("Password must be at least 6 characters long.");

            // Check if the password contains at least one uppercase letter
            if (!password.Any(char.IsUpper))
                throw new ArgumentException("Password must contain at least one uppercase letter.");

            // Check if the password contains at least one lowercase letter
            if (!password.Any(char.IsLower))
                throw new ArgumentException("Password must contain at least one lowercase letter.");

            // Check if the password contains at least one digit
            if (!password.Any(char.IsDigit))
                throw new ArgumentException("Password must contain at least one digit.");

            // Check if the password contains at least one special character
            if (!password.Any(char.IsSymbol) && !password.Any(char.IsPunctuation))
                throw new ArgumentException("Password must contain at least one special character.");
            
            // If all checks passed, the password is valid
            return;
        }
    }
}