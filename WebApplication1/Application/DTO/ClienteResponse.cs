namespace ClienteAPI.Application.DTO
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Nascimento { get; set; }
        public EnderecoResponse Endereco { get; set; }
    }
}
