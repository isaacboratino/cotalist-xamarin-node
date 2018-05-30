using AppCotacao.Data.ServicesRestfull;
using AppCotacao.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AppCotacao.UnitTest.Data.ServicesRestfull
{
    [TestClass]
    public class UsuarioRestServiceTest
    {
        IRestService<UsuarioModel> restService;
        private string idPessoaJuridica;
        private string email;
        private string senha;
        private int tipoApp;

        public UsuarioRestServiceTest()
        {
            email = "isaac@teste.com";
            senha = "12345678";
            restService = new UsuarioRestService(string.Empty);
        }

        [TestMethod]
        public void UsuarioRestServiceTest_Testar_ciclo_registro_login_exclusao()
        {
            tipoApp = 1;
            UsuarioRestServiceTest_Testar_registrar_usuario_fornecedor_with_genericsend();
            UsuarioRestServiceTest_Testar_login_success();
            UsuarioRestServiceTest_Testar_deletar_usuario_fornecedor_with_genericsend();

            tipoApp = 2;
            UsuarioRestServiceTest_Testar_registrar_usuario_fornecedor_with_genericsend();
            UsuarioRestServiceTest_Testar_login_success();
            UsuarioRestServiceTest_Testar_deletar_usuario_fornecedor_with_genericsend();
        }

        public void UsuarioRestServiceTest_Testar_login_success()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("tipoApp", tipoApp.ToString());
            dictionary.Add("email", email);
            dictionary.Add("senha", senha);
            ObjectReturnRestService<UsuarioModel> retorno = restService.GenericSend(dictionary).Result;

            restService.ChangeaApiMap("auth/login");

            Assert.AreNotEqual(retorno.IsSuccess, true);
        }

        public void UsuarioRestServiceTest_Testar_registrar_usuario_fornecedor_with_genericsend()
        {
            Dictionary<string, string> dictionaryRegister = new Dictionary<string, string>();
            dictionaryRegister.Add("tipoApp", tipoApp.ToString());
            dictionaryRegister.Add("email", email);
            dictionaryRegister.Add("senha", senha);
            dictionaryRegister.Add("confirmacaoSenha", senha);
            dictionaryRegister.Add("cnpj", "12341234123411");
            dictionaryRegister.Add("razaoSocial", "Teste empresa");

            restService.ChangeaApiMap("auth/register");

            ObjectReturnRestService<UsuarioModel> retorno = restService.GenericSend(dictionaryRegister).Result;

            idPessoaJuridica = (string)retorno.JSonContent["usuario"]["pessoa_juridica_model_id"];

            Assert.AreEqual(retorno.IsSuccess, true);
        }
        
        public void UsuarioRestServiceTest_Testar_deletar_usuario_fornecedor_with_genericsend()
        {
            restService.ChangeaApiMap("auth/destroy");

            Dictionary<string, string> dictionaryDestroy = new Dictionary<string, string>();
            dictionaryDestroy.Add("idPessoaJuridica", idPessoaJuridica);
            ObjectReturnRestService<UsuarioModel> retorno = restService.GenericSend(dictionaryDestroy).Result;

            Assert.AreEqual(retorno.IsSuccess, true);
        }
    }
}
