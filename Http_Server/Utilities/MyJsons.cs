using System.Text.Json.Serialization;

namespace Utilities
{
    public class MyJsonUser
    {
        public MyJsonUser(string name ,string email = "example@email.com", string password = "examplepassword", int age = 0)
            {
                Name = name;
                Email = email;
                Password = password;    
                Age = age;
            }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }

    public class MyJsonUserLogIn
    {
        public MyJsonUserLogIn(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }

    public class MyJsonUserCurrent
    {
        public MyJsonUserCurrent(string name = null, string email = null, int id = -1)
        {
            Name = name;
            Email = email;
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    
}