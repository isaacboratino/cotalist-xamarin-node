
using System;

namespace AppCotacao.Model
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public Guid IdPessoaJuridica { get; set; }
        public int TipoApp { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual PessoaJuridicaModel PessoaJuridicaModel { get; set; }

        public UsuarioModel(int TipoApp)
        {
            this.Id = Guid.NewGuid();
            this.TipoApp = TipoApp;
        }

        public UsuarioModel(int TipoApp, Guid id)
        {
            this.Id = Id;
            this.TipoApp = TipoApp;
        }
    }
}
