namespace Sprintwro.Interface
{
    public class UserNotFoundException : InterfaceException
    {
        public UserNotFoundException() : base("USER_NOT_FOUND", "User was not found in the HTTP request")
        {
        }
    }
}
