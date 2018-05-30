using System;

namespace AppCotacao.Model
{
    class EnderecoModel
    {
        public Guid Id { get; set; }
        public int IdPessoa { get; set; }
        public string NomeEndereco { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }

        public EnderecoModel()
        {
            this.Id = Guid.NewGuid();
        }

        public EnderecoModel(Guid Id)
        {
            this.Id = Id;
        }
    }
}
