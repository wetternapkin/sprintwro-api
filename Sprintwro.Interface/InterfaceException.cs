namespace Sprintwro.Interface
{
    public abstract class InterfaceException : Service.ServiceException
    {
        protected InterfaceException(string code, string message) : base(code, message)
        {
        }

        protected InterfaceException(string code, Exception innerException) : base(code, innerException)
        {
        }
    }
}
