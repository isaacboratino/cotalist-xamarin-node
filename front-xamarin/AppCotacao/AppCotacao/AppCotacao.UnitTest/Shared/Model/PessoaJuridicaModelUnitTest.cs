using AppCotacao.Model;
using AppCotacao.Services.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppCotacao.UnitTest
{
    [TestClass]
    public class PessoaJuridicaModelUnitTest
    {
        private const string cnpjVar = "12123123123412";
        private const string cnpjWithMask = "12.123.123/1234-12";

        private const string cpfVar = "12312312312";
        private const string cpfWithMask = "123.123.123-12";

        private PessoaJuridicaModel objeto = new PessoaJuridicaModel();

        public PessoaJuridicaModelUnitTest()
        {
            objeto.CNPJ = cnpjVar;
        }

        [TestMethod]
        public void Testar_set_CNPJ_in_object()
        {
            Assert.AreEqual(objeto.CNPJ, cnpjVar);
        }

        [TestMethod]
        public void Testar_atribuicao_mascara_CNPJ()
        {
            Assert.AreEqual(MasksUtil.AddMaskCNPJ(objeto.CNPJ), cnpjWithMask);
            Assert.AreEqual(objeto.CNPJ, cnpjVar);
        }

        [TestMethod]
        public void Testar_remocao_marcarao_CNPJ()
        {
            objeto.CNPJ = cnpjWithMask;
            Assert.AreEqual(objeto.CNPJ, cnpjWithMask);
            Assert.AreEqual(MasksUtil.RemoveMaskCNPJ(objeto.CNPJ), cnpjVar);
        }

        [TestMethod]
        public void Testar_atribuicao_mascara_CPF()
        {
            Assert.AreEqual(MasksUtil.AddMaskCPF(cpfVar), cpfWithMask);
        }

        [TestMethod]
        public void Testar_remocao_marcarao_CPF()
        {
            Assert.AreEqual(MasksUtil.RemoveMaskCPF(cpfWithMask), cpfVar);
        }
    }
}
