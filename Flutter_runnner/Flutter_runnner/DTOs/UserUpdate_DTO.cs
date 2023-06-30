namespace Flutter_runnner.DTOs
{
    public class UserUpdate_DTO
    {

        public Guid id { get; set; }
        public string name { get; set; }

        public string surname { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    
        public UserUpdate_DTO() { } 

        public UserUpdate_DTO(User user)
        {
            id = user.id;
            name = user.Name;
            surname = user.Surname; 
            email = user.Email;
            password = user.Password;
        }
    }
}
