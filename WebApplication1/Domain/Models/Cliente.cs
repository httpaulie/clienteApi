namespace ClienteAPI.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        
    }
}
