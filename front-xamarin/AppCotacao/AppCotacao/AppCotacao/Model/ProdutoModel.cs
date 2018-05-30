using System;

namespace AppCotacao.Model
{
    public class ProdutoModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string UnidadeMedida { get; set; }
        public Decimal ValorMedida { get; set; }

        public ProdutoModel()
        {
            this.Id = Guid.NewGuid();
        }

        public ProdutoModel(Guid Id)
        {
            this.Id = Id;
        }
    }
}
