using System;

namespace AppCotacao.Model
{
    public class CotacaoFornecedorChatModel
    {
        public Guid Id { get; set; }
        public Guid IdCotacao { get; set; }
        public Guid IdFornecedor { get; set; }
        public string TipoApp { get; set; }
        public string Mensagem { get; set; }

        public CotacaoFornecedorChatModel()
        {
            this.Id = Guid.NewGuid();
        }

        public CotacaoFornecedorChatModel(Guid Id)
        {
            this.Id = Id;
        }
    }
}
