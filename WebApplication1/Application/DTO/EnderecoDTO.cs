namespace ClienteAPI.Application.DTO
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public List<ClienteDTO> Clientes { get; set; }
    }
}
