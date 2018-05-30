using System;

namespace AppCotacao.Model
{
    public class ContatoModel
    {
        public Guid Id { get; set; }
        public string TipoContato { get; set; }
        public string Conteudo { get; set; }

        public ContatoModel()
        {
            this.Id = Guid.NewGuid();
        }

        public ContatoModel(Guid Id)
        {
            this.Id = Id;
        }
    }
}
