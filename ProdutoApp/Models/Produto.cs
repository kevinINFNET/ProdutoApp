// Models/Produto.cs
namespace ProdutoApp.Models
{
    public class Produto
    {
        public int Id { get; set; }
#pragma warning disable CS8618 
        public string Nome { get; set; }
#pragma warning restore CS8618 
        public decimal Preco { get; set; }
    }
}
