const {
  GraphQLObjectType,
  GraphQLInt,
  GraphQLString,
  GraphQLList,
} = require('graphql');

const PessoaJuridicaGraphQLType = require('../PessoaJuridicaModel/PessoaJuridicaGraphQLType');

const UsuarioGraphQLType = new GraphQLObjectType({
  name: 'Usuario',
  description: 'Definicao graphql para usuário',
  fields: () => ({
    id: {
      type: GraphQLString,
      resolve: (usuario) => usuario.id,
    },    
    tipoApp: {
      type: GraphQLInt,
      resolve: (usuario) => usuario.tipoApp,
    },
    email: {
      type: GraphQLString,
      resolve: (usuario) => usuario.email,
    },
    senha: {
      type: GraphQLString,
      resolve: (usuario) => usuario.senha,
    },    
    createdAt: {
      type: GraphQLString,
      resolve: (usuario) => usuario.createdAt,
    },
    updatedAt: {
      type: GraphQLString,
      resolve: (usuario) => usuario.updatedAt,
    },
    PessoaJuridica: {
      type: PessoaJuridicaGraphQLType,     
    },
  }),
});

module.exports = UsuarioGraphQLType;
