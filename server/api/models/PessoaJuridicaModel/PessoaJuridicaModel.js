const Sequelize = require('sequelize');
const sequelize = require('../../../config/database');

const instanceMethods = {
  toJSON() {
    const values = Object.assign({}, this.get());
    delete values.password;
    return values;
  },
};

const tableName = 'pessoas_juridicas';

const PessoaJuridicaModel = sequelize.define('PessoaJuridicaModel', {
  id: {
    type: Sequelize.INTEGER,
    autoIncrement: true,
    //type: Sequelize.UUID,
    //defaultValue: Sequelize.UUIDV4,
    primaryKey: true,
    allowNull: false,
    unique: true
  },
  CNPJ: {
    type: Sequelize.STRING(14),
    allowNull: false,
    unique: true,
    validate: { len: [0,14] }
  },
  RazaoSocial: {
    type: Sequelize.STRING(120),
    allowNull: false,
    unique: false,
    validate: { len: [0,120] }
  },
  NomeFantasia: {
    type: Sequelize.STRING(120),
    allowNull: true,
    unique: false,
    validate: { len: [0,120] }
  },
  InscricaoEstadual: {
    type: Sequelize.STRING(50),
    allowNull: true,
    unique: true,
    validate: { len: [0,50] }
  },
  InscricaoMunicipal: {
    type: Sequelize.STRING(50),
    allowNull: true,
    unique: true,
    validate: { len: [0,50] }
  },
  created_at: {
    type: Sequelize.DATE,
    allowNull: false
  },
  updated_at:  Sequelize.DATE,
  deleted_at: Sequelize.DATE,
}, { instanceMethods, tableName, paranoid: true, underscored: true });

module.exports = PessoaJuridicaModel;
