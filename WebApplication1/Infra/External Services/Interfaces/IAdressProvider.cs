namespace ClienteAPI.Infra.External_Services.Interfaces
{
    public interface IAdressProvider
    {
        Task<object> GetAdress(string cep);
    }
}
