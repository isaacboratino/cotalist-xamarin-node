using AppCotacao.Data.Mocks;
using AppCotacao.Data.Repositories;
using AppCotacao.Services.DependencyServices;
using AppCotacao.Services.Exceptions;
using AppCotacao.ViewModels.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppCotacao.UnitTest
{
    [TestClass]
    public class LoginViewModelUnitTest
    {
        IDependencyService _dependencyService;
        LoginViewModel viewModel;

        public LoginViewModelUnitTest()
        {
            _dependencyService = new DependencyServiceStub();
            _dependencyService.Register<IUsuarioRepository>(new UsuarioMock());

            viewModel = new LoginViewModel(_dependencyService);
        }        

        [TestMethod]
        public void LoginViewModel_Testar_validacao_email_required()
        {
            viewModel.UsuarioModel.Email = "";
            viewModel.UsuarioModel.Senha = "12345678";

            InvalidViewModelException ex = Assert.ThrowsException<InvalidViewModelException>(() => viewModel.IsViewModelValid());
            Assert.AreEqual("Email é obrigatório", ex.Message);            
        }

        [TestMethod]
        public void LoginViewModel_Testar_validacao_email_com_formato_invalido()
        {
            viewModel.UsuarioModel.Email = "isaac_email.com";
            viewModel.UsuarioModel.Senha = "12345678";

            InvalidViewModelException ex = Assert.ThrowsException<InvalidViewModelException>(() => viewModel.IsViewModelValid());
            Assert.AreEqual("Email não está em um formato correto", ex.Message);
        }

        [TestMethod]
        public void LoginViewModel_Testar_validacao_senha_required()
        {
            viewModel.UsuarioModel.Email = "isaac@gmail.com";
            viewModel.UsuarioModel.Senha = "";

            InvalidViewModelException ex = Assert.ThrowsException<InvalidViewModelException>(() => viewModel.IsViewModelValid());
            Assert.AreEqual("Senha é obrigatória", ex.Message);
        }

        [TestMethod]
        public void LoginViewModel_Testar_login_valido()
        {
            viewModel.UsuarioModel.Email = "isaac@gmail.com";
            viewModel.UsuarioModel.Senha = "12345678";
            viewModel.LoginCommand.Execute(null);

            Assert.AreEqual(viewModel.IsUsuarioLogado, true);
        }

        [TestMethod]
        public void LoginViewModel_Testar_login_com_email_invalido()
        {
            viewModel.UsuarioModel.Email = "isaacd@gmail.com";
            viewModel.UsuarioModel.Senha = "12345678";
            viewModel.LoginCommand.Execute(null);

            Assert.AreEqual(viewModel.IsUsuarioLogado, false);
        }

        [TestMethod]
        public void LoginViewModel_Testar_login_com_email_valido_e_senha_invalida()
        {
            viewModel.UsuarioModel.Email = "isaac@gmail.com";
            viewModel.UsuarioModel.Senha = "123456789";
            viewModel.LoginCommand.Execute(null);

            Assert.AreEqual(viewModel.IsUsuarioLogado, false);
        }
    }
}
