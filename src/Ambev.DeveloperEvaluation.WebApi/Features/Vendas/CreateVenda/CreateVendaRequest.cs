namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CreateVenda
{
    public class CreateVendaRequest
    {
        /// <summary>
        /// Número único da venda.
        /// </summary>
        public string NumeroVenda { get; set; } = string.Empty;

        /// <summary>
        /// Cliente relacionado à venda.
        /// </summary>
        public string Cliente { get; set; } = string.Empty;

        /// <summary>
        /// Agência onde a venda foi realizada.
        /// </summary>
        public string Agencia { get; set; } = string.Empty;

        /// <summary>
        /// Data da venda.
        /// </summary>
        public DateTime DataVenda { get; set; }

        /// <summary>
        /// Lista de itens na venda.
        /// </summary>
        public List<ItemVendaRequest> Itens { get; set; } = new();
    }

    public class ItemVendaRequest 
    {
        public string Produto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Discount applied to the product.
        /// </summary>
        public decimal Desconto { get; set; }

        /// <summary>
        /// Total value of the item (with discount).
        /// </summary>
        public decimal ValorTotal => (PrecoUnitario * Quantidade) - Desconto;
    }
}
