namespace SalesWebMVC.Models.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        private  const string MENSAGEM_PADRAO = "Erro de integração";

        public IntegrityException(string? message = MENSAGEM_PADRAO) : base(message)
        {
        }
    }
}
