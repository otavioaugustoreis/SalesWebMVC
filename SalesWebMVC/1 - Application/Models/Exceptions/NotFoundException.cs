namespace SalesWebMVC.Models.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        private const string MENSAGEM_PADRAO = "Not Found ";
        public NotFoundException(string? message = MENSAGEM_PADRAO) : base(message)
        {
        }
    }
}
