using System;

namespace AppCotacao.Model
{
    public class CotacaoModel
    {
        public Guid Id { get; set; }

        // Fornecedor que foi selecionado pelo cliente quando recebeu a cotação do fornecedor
        public Guid IdFornecedorSelecionado { get; set; }

        // data em que foi criada a lista de cotação para ser enviada para os fornecedores
        public DateTime DataCriacao { get; set; }        

        // data em que foi aceita a cotação do fornecedor
        public DateTime DataAceitacao { get; set; }

        // valor total enviado pelo fornecedor aceito
        public Decimal ValorTotal { get; set; }

        public CotacaoModel()
        {
            this.Id = Guid.NewGuid();
        }

        public CotacaoModel(Guid Id)
        {
            this.Id = Id;
        }

    }
}
