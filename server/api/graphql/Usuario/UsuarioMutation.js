const {
  GraphQLString,
  GraphQLInt,
  GraphQLNonNull,
} = require('graphql');

const UsuarioGraphQLType = require('../../models/UsuarioModel/UsuarioGraphQLType');
const UsuarioModel = require('../../models/UsuarioModel/UsuarioModel');

const updateUsuario = {
  type: UsuarioGraphQLType,
  description: 'Essa mutation permite a alteração do usuario atraves do Id',
  args: {
    id: {
      name: 'id',
      type: new GraphQLNonNull(GraphQLInt),
    },
    usuario: {
      name: 'usuario',
      type: GraphQLString,
    },
  },
  resolve: (UsuarioModel, { id, usuario }) => (
    UsuarioModel
      .findById(id)
      .then((foundUsuario) => {
        if (!foundUsuario) {
          return 'Usuario not found';
        }

        const thisUsuario = usuario !== undefined ? usuario : foundUsuario.usuario;
        const thisEmail = email !== undefined ? email : foundUsuario.email;

        return foundUsuario
          .update({
            usuario: thisUsuario,
            email: thisEmail,
          });
      })
  ),
};

const deleteUsuario = {
  type: UsuarioGraphQLType,
  description: 'The mutation that allows you to delete a existing Usuario by Id',
  args: {
    id: {
      name: 'id',
      type: new GraphQLNonNull(GraphQLInt),
    },
  },
  resolve: (UsuarioModel, { id }) => (
    UsuarioModel
      .delete()
      .where({
        id,
      })
  ),
};

module.exports = {
  updateUsuario,
  deleteUsuario,
};
