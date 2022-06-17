namespace Sprintwro.Interface.Authentication
{
    public class InvalidAuthConfigException : InterfaceException
    {
        public InvalidAuthConfigException(string missing) : base("INVALID_AUTH_CONFIG", $"The authenfication configuration is incomplete, it misses {missing}")
        {
        }
    }
}
