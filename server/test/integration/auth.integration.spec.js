'use strict';

const request = require('request-promise');
const integrationServer = require("./utils/integrationServer");
const chai = require('chai');

const expect = chai.expect;

describe('Teste de Intgração de Registro de Usuário e Autenticação', () => {
  
  let app;

  before((done) => {
    app = integrationServer.start(done);
  });

  after((done) => {
    integrationServer.stop(app, done);
  });

  it('Teste de registro de usuário válido', () => {
    const payload = {
      tipoApp:1,
      email: 'email@email.com',
      senha: 'senha1345',
      confirmacaoSenha: 'senha1345',
      cnpj: '12345123412345',
      razaoSocial: 'Razao empresocial'
    };

    console.log(JSON.stringify(payload));

    const expected = {
      "usuario": []
    };

    return integrationServer
      .restFull(app, '/auth/register', payload)
      .then((response) => {
        console.log(JSON.stringify(response));
        expect(response.statusCode).to.equal(200);
        //expect(response.body).to.have.deep.equals(expected);
      });
  });  

});