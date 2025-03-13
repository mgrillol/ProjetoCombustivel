using PrecoCombustivel.Domain.Enums;

namespace PrecoCombustivel.Domain.Entities
{
    public class Combustivel
    {
        public Guid Id { get; private set; }
        public string Tipo { get; private set; }
        public string Localizacao { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime CriadoEm { get; private set; }

        public Combustivel(string tipo, string localizacao, decimal preco)
        {
            Id = Guid.NewGuid();
            Tipo = tipo;
            Localizacao = localizacao;
            Preco = preco;
            CriadoEm = DateTime.UtcNow;
        }
    }
}
