namespace Utilities
{
    public class MyJsonDev
    {
        public MyJsonDev(string name, string email, int age)
        {
            Name = name;
            Email = email;
            Age = age;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}