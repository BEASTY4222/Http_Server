namespace Utilities
{
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