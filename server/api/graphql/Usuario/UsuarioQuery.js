const {
  GraphQLInt,
  GraphQLString,
  GraphQLList,
} = require('graphql');

const UsuarioGraphQLType = require('../../models/UsuarioModel/UsuarioGraphQLType');
const UsuarioModel = require('../../models/UsuarioModel/UsuarioModel');

const usuarioQuery = {
  type: new GraphQLList(UsuarioGraphQLType),
  args: {
    id: {
      name: 'id',
      type: GraphQLInt,
    },
    usuario: {
      name: 'usuario',
      type: GraphQLString,
    },    
    createdAt: {
      name: 'createdAt',
      type: GraphQLString,
    },
    updatedAt: {
      name: 'updatedAt',
      type: GraphQLString,
    },
  },
  resolve: (usuario, args) => UsuarioModel.findAll({ where: args }),
};

module.exports = usuarioQuery;
