using System.Text.Json.Serialization;

namespace Utilities
{
       public class MyJsonUser
        {
            public MyJsonUser( string name ,string email = "example@email.com", string password = "examplepassword", int age = 0)
            {
                Name = name;
                Email = email;
                Password = password;    
                Age = age;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

            [JsonIgnore]
            public string Password { get; set; }
            [JsonIgnore]
            public int Age { get; set; }
        }
     
    
}