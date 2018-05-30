using System;

namespace AppCotacao.Model
{
    public class FornecedorProdutosModel
    {
        public Guid Id { get; set; }
        public Guid IdPessoaJuridica { get; set; }
        public Guid IdProduto { get; set; }
        public Decimal PrecoProduto { get; set; }

        public FornecedorProdutosModel()
        {
            this.Id = Guid.NewGuid();
        }

        public FornecedorProdutosModel(Guid Id)
        {
            this.Id = Id;
        }
    }
}
