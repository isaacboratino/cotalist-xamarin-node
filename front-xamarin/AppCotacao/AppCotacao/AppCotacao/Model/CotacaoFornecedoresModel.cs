using System;

namespace AppCotacao.Model
{
    public class CotacaoFornecedoresModel
    {
        // Status dos items da cotação
        public static int POSSUI_TODOS_ITEMS = 0;
        public static int POSSUI_TODOS_ITEMS_QUANTIDADE_INSUFICIENTE = 1;
        public static int NAO_POSSUI_TODOS_ITEMS = 2;

        // Status do cliente
        public static int AGUARDANDO_ANALISE_FORNECEDOR = 0;
        public static int RETORNADO_PELO_FORNECEDOR = 1;

        // Status do fornecdor
        public static int ENVIADO_PELO_CLIENTE = 0;
        public static int AGUARDANDO_RESPOSTA_CLIENTE = 1;
        public static int ACEITO_PELO_CLIENTE = 2;
        public static int REJEITADO_PELO_CLIENTE = 3;

        public Guid Id { get; set; }
        public Guid IdCotacao { get; set; }
        public Guid IdFornecedor { get; set; }
        public int StatusItemsCotacao { get; set; }
        public int StatusCliente { get; set; }
        public int StatusFornecedor { get; set; }

        // data em que a lista de cotação foi enviada
        public DateTime DataEnvioCliente { get; set; }

        // data em que a fornecedor enviou uma resposta de volta
        public DateTime DataRetornoFornecedor { get; set; }

        public Decimal ValorTotalCotacao { get; set; }

        public CotacaoFornecedoresModel()
        {
            this.Id = Guid.NewGuid();
            this.StatusItemsCotacao = CotacaoFornecedoresModel.POSSUI_TODOS_ITEMS;
            this.StatusCliente = CotacaoFornecedoresModel.AGUARDANDO_ANALISE_FORNECEDOR;
            this.StatusFornecedor = CotacaoFornecedoresModel.ENVIADO_PELO_CLIENTE;
        }

        public CotacaoFornecedoresModel(Guid Id)
        {
            this.Id = Id;
            this.StatusItemsCotacao = CotacaoFornecedoresModel.POSSUI_TODOS_ITEMS;
            this.StatusCliente = CotacaoFornecedoresModel.AGUARDANDO_ANALISE_FORNECEDOR;
            this.StatusFornecedor = CotacaoFornecedoresModel.ENVIADO_PELO_CLIENTE;
        }
    }
}
