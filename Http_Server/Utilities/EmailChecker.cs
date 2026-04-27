using Data;
using Microsoft.EntityFrameworkCore;


namespace Utilities
{
    public static class EmailChecker
    {
        public static async Task IsValidEmail(string email, AppDbContext db)
        {
            // We check if the email is already in the database
            // if it is then we throw an exception since the email is already taken
            if (await db.Users.FirstOrDefaultAsync(u => u.Email == email) == null)
            {
                throw new ArgumentException("There already exists a user with this email.");
            }

            // Check if the email is null or empty
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be empty or have spaces.");
            }

            // Check if the email starts or ends with a dot
            if (email[0] == '.' || email[email.Length - 1] == '.')
            {
                throw new ArgumentException("Email cannot start or end with a dot.");
            }
            
            // Check if the email contains '@' and '.' characters            // Check if the email contains consecutive dots
            if (!email.Contains('@') || !email.Contains('.'))
            {
                throw new ArgumentException("Email must contain '@' and '.' characters.");
            }

            // Check if the email contains consecutive dots
            if (email.Contains(".."))
            {
                throw new ArgumentException("Email cannot contain consecutive dots.");
            }

            // Check if the email has a valid domain
            if (!email.Contains(".com") || !email.Contains(".net") || !email.Contains(".org"))
            {
                throw new ArgumentException("Email must have a valid domain.");
            }
        }
    }
}