using AppCotacao.Model;
using AppCotacao.Data.Repositories;
using System.Collections.Generic;

namespace AppCotacao.Data.Mocks
{
    public class UsuarioMock : BaseGenericDataStore<UsuarioModel>, IUsuarioRepository
    {
        public UsuarioMock()
        {
            PessoaJuridicaModel pessoaJuridica = new PessoaJuridicaModel()
            {
                CNPJ = "1055855581188",
                NomeFantasia = "Empresa de Teste"
            };

            items = new List<UsuarioModel>();
            var mockItems = new List<UsuarioModel>
            {
                new UsuarioModel(App.CurrentTipoApp)
                {
                    Email = "isaac@gmail.com",
                    Senha = "12345678"
                },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }
    }
}
