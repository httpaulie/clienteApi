namespace ClienteAPI.Application.DTO
{
    public class ClienteRequest
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public int EnderecoId { get; set; }
    }
}
