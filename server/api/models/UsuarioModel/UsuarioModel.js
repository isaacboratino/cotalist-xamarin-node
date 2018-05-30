const Sequelize = require('sequelize');
const bcryptSevice = require('../../services/bcrypt.service');

const sequelize = require('../../../config/database');
const PessoaJuridicaModel = require('../PessoaJuridicaModel/PessoaJuridicaModel');

const hooks = {
  beforeCreate(usuarioModel) {
    usuarioModel.senha = bcryptSevice.passwordHash(usuarioModel.senha); // eslint-disable-line no-param-reassign
    console.log(usuarioModel.senha);
  },
};

const instanceMethods = {
  toJSON() {
    const values = Object.assign({}, this.get());
    delete values.senha;
    return values;
  },
};

const tableName = 'usuarios';

const UsuarioModel = sequelize.define('UsuarioModel', {
  id: {
    type: Sequelize.INTEGER,
    autoIncrement: true,
    //type: Sequelize.UUID,
    //defaultValue: Sequelize.UUIDV4,
    primaryKey: true,
    allowNull: false,
    unique: true
  },
  /*idPessoaJuridica: {
    type: Sequelize.UUID,
    allowNull: false
  },*/
  tipoApp: {
    type:   Sequelize.INTEGER,    
    allowNull: false,
    validate: { isIn: [[1, 2]] }, // 1 - CLIENTE, 2 - FORNECEDOR
  },
  email: {
    type: Sequelize.STRING(120),
    unique: true,
    allowNull: false,
    validate: { len: [0,120] }
  },
  senha: {
    type: Sequelize.STRING(120),
    allowNull: false,
    validate: { len: [8,120] }
  },
  created_at: {
    type: Sequelize.DATE,
    allowNull: false
  },
  updated_at:  Sequelize.DATE,
  deleted_at: Sequelize.DATE,
}, { hooks, instanceMethods, tableName, paranoid: true, underscored: true });

UsuarioModel.belongsTo(PessoaJuridicaModel,{onDelete: 'CASCADE'});

module.exports = UsuarioModel;
