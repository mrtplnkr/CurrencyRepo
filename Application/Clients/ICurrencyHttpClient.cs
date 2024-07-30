namespace Application.Clients
{
    public interface ICurrencyHttpClient
    {
        Task<string> Get(string requestUri);
    }
}
