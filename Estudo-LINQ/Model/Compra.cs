namespace API_REST.Model
{
    public class Compra
    {
        public int CompraId { get; set; } 
        public int ProdutoId { get; set; } 
        public int ClientId { get; set; }
        public int Total { get; set; }
    }
}
