const authService = require('../../services/auth.service');
const bcryptService = require('../../services/bcrypt.service');
const UsuarioModel = require('../../models/UsuarioModel/UsuarioModel');
const PessoaJuridicaModel = require('../../models/PessoaJuridicaModel/PessoaJuridicaModel');

const AuthController = () => {

  const register = (req, res) => {

    console.log('AuthController.register');

    const body = req.body;

    console.log('body '+JSON.stringify(body));

    if (body.senha === body.confirmacaoSenha) {

      let cnpj = ""+body.cnpj;   
      cnpj = ""+cnpj.replace(/[-.\/]/g, '');

      return UsuarioModel.create({
        tipoApp: body.tipoApp,
        email: body.email,
        senha: body.senha,
        PessoaJuridicaModel : {
          CNPJ: cnpj,
          RazaoSocial: body.razaoSocial
        }
      }, 
      {
        include: [PessoaJuridicaModel]
      })
      .then((usuario) => {
          const token = authService.issue({ id: usuario.id });
          return res.status(200).json({ token, usuario });
      })
      .catch((err) => {
        console.log(err);
        return res.status(500).json({ msg: err.message, errorMessage: err.message, errors: err.errors });
      });
    }

    return res.status(400).json({ msg: 'Senhas não são iguais' });
  };

  const login = (req, res) => {
    const tipoApp = req.body.tipoApp;
    const email = req.body.email;
    const senha = req.body.senha;

    if (email && senha) {
      UsuarioModel.findOne({
        where: {
          tipoApp,
          email
        },
      })
      .then((usuario) => {

        if (!usuario) {
          return res.status(400).json({ msg: 'Usuário não encontrado' });
        }

        if (bcryptService.comparePassword(senha, usuario.senha)) {
          const token = authService.issue({ id: usuario.id });
          return res.status(200).json({ token, usuario });
        }
        return res.status(401).json({ msg: 'Não autorizado' });

      })
      .catch((err) => {
        console.log(err);
        return res.status(500).json({ msg: err.message, errorMessage: err.message, errors: err.errors });
      });
    }
  };

  const destroy = (req, res) => {

    const id = req.body.idPessoaJuridica;

    if (id) {

      PessoaJuridicaModel.destroy({
        force: true,
        where: {
          id
        },
      })
      .then(function (deletedRecord) {
          if(deletedRecord === 1) {              
            return res.status(200).json({msg:"Registro deletado com sucesso"});          
          }
          else
          {
            return res.status(404).json({msg:"Registro não encontrado"})
          }
      })
      .catch(function (err){
           return res.status(500).json({ msg: err.message, errorMessage: err.message, errors: err.errors });
      });
    }
  };

  const validate = (req, res) => {
    const tokenToVerify = req.body.token;

    authService.verify(tokenToVerify, (err) => {
      if (err) {
        return res.status(401).json({ isvalid: false, err: 'Token Inválido!' });
      }

      return res.status(200).json({ isvalid: true });
    });
  };

  return {
    register,
    login,
    validate,
    destroy
  };
};

module.exports = AuthController;
