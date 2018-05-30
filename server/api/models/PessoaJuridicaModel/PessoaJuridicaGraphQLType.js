const {
    GraphQLObjectType,
    GraphQLInt,
    GraphQLString,
    GraphQLList,
  } = require('graphql');
  
  const PessoaJuridicaGraphQLType = new GraphQLObjectType({
    name: 'PessoaJuridica',
    description: 'Definicao graphql para pessoaJuridica',
    fields: () => ({
      id: {
        type: GraphQLString,
        resolve: (pessoaJuridica) => pessoaJuridica.id,
      },    
      CNPJ: {
        type: GraphQLString,
        resolve: (pessoaJuridica) => pessoaJuridica.CNPJ,
      },
      RazaoSocial: {
        type: GraphQLString,
        resolve: (pessoaJuridica) => pessoaJuridica.RazaoSocial,
      },
      NomeFantasia: {
        type: GraphQLString,
        resolve: (pessoaJuridica) => pessoaJuridica.NomeFantasia,
      }, 
      InscricaoEstadual: {
        type: GraphQLString,
        resolve: (pessoaJuridica) => pessoaJuridica.InscricaoEstadual,
      },
      InscricaoMunicipal: {
        type: GraphQLString,
        resolve: (pessoaJuridica) => pessoaJuridica.InscricaoMunicipal,
      },    
      createdAt: {
        type: GraphQLString,
        resolve: (pessoaJuridica) => pessoaJuridica.createdAt,
      },
      updatedAt: {
        type: GraphQLString,
        resolve: (pessoaJuridica) => pessoaJuridica.updatedAt,
      },
      PessoaJuridica: {
        type: GraphQLString,
        resolve: (pessoaJuridica) => pessoaJuridica.idPessoaJuridica,
      },
    }),
  });
  
  module.exports = PessoaJuridicaGraphQLType;
  