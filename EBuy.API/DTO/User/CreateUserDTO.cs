namespace EBuy.API.DTO.User
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int BusinessId { get; set; }
        public string Password { get; set; }

    }
}
