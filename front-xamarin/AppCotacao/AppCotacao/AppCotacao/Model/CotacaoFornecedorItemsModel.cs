using System;

namespace AppCotacao.Model
{
    public class CotacaoFornecedorItemsModel
    {
        public static int FORNECEDOR_POSSUI_ITEM_QUANTIDADE_PEDIDA = 0;
        public static int FORNECEDOR_POSSUI_ITEM_QUANTIDADE_INSUFICIENTE = 1;
        public static int FORNECEDOR_NAO_POSSUI_ITEM = 2;

        public Guid Id { get; set; }
        public Guid IdCotacaoItem { get; set; }
        public Guid IdFornecedor { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal ValorItem { get; set; }
        public int StatusItem { get; set; }

        public CotacaoFornecedorItemsModel()
        {
            this.Id = Guid.NewGuid();
            this.StatusItem = CotacaoFornecedorItemsModel.FORNECEDOR_POSSUI_ITEM_QUANTIDADE_PEDIDA;
        }

        public CotacaoFornecedorItemsModel(Guid Id)
        {
            this.Id = Id;
            this.StatusItem = CotacaoFornecedorItemsModel.FORNECEDOR_POSSUI_ITEM_QUANTIDADE_PEDIDA;
        }
    }
}
