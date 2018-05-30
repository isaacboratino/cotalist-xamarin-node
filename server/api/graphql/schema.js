const {
    GraphQLSchema,
    GraphQLObjectType,
  } = require('graphql');
  
  const usuarioQuery = require('./Usuario/UsuarioQuery');
  
  const {
    updateUsuario,
    deleteUsuario,
  } = require('./Usuario/UsuarioMutation');
  
  const RootQuery = new GraphQLObjectType({
    name: 'rootQuery',
    description: 'This is the root query which holds all possible READ entrypoints for the GraphQL API',
    fields: () => ({
      usuario: usuarioQuery,
    }),
  });
  
  const RootMutation = new GraphQLObjectType({
    name: 'rootMutation',
    description: 'This is the root mutation which holds all possible WRITE entrypoints for the GraphQL API',
    fields: () => ({
      updateUsuario,
      deleteUsuario,
    }),
  });
  
  const Schema = new GraphQLSchema({
    query: RootQuery,
    mutation: RootMutation,
  });
  
  module.exports = Schema;
  