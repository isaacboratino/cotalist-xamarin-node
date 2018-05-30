using System;

namespace AppCotacao.Model
{
    public class CotacaoItemsModel
    {
        public Guid Id { get; set; }
        public Guid IdCotacao { get; set; }
        public Guid IdProduto { get; set; }
        public Decimal Quantidade { get; set; }

        public CotacaoItemsModel()
        {
            this.Id = Guid.NewGuid();
        }

        public CotacaoItemsModel(Guid Id)
        {
            this.Id = Id;
        }
    }
}
