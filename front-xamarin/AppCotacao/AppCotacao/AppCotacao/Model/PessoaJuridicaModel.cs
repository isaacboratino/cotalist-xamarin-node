using System;

namespace AppCotacao.Model
{
    public class PessoaJuridicaModel
    {
        public Guid Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }        
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }

        public PessoaJuridicaModel()
        {
            this.Id = Guid.NewGuid();
        }

        public PessoaJuridicaModel(Guid Id)
        {
            this.Id = Id;
        }   
    }
}
