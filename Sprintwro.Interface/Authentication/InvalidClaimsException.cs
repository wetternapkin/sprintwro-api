namespace Sprintwro.Interface.Authentication
{
    public class InvalidClaimsException : InterfaceException
    {
        public InvalidClaimsException(string missingClaimName) : base("INVALID_CLAIMS", $"The JWT has not the required information. The claim <{missingClaimName}> is missing")
        {
        }
    }
}
