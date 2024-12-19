namespace SalesWebMVC.Models.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        private const string MENSAGEM_PADRAO = "";
        public DbConcurrencyException(string? message = MENSAGEM_PADRAO) : base(message)
        {
        }
    }
}
