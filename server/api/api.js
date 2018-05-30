/**
 * third party libraries
 */
const bodyParser = require('body-parser');
const express = require('express');
const helmet = require('helmet');
const http = require('http');
const mapRoutes = require('express-routes-mapper');
const GraphHTTP = require('express-graphql');
const cors = require('cors');

/**
 * server configuration
 */
const config = require('../config/');
const auth = require('./policies/auth.policy');
const dbService = require('./services/db.service');
const Schema = require('./graphql/schema');

// environment: development, testing, production
const environment = process.env.NODE_ENV;

/**
 * express application
 */
const api = express();
const server = http.Server(api);
const mappedRoutes = mapRoutes(config.publicRoutes, 'api/controllers/Auth/');
const DB = dbService(environment, config.migrate).start();

// allow cross origin requests
// configure to allow only requests from certain origins
api.use(cors());

// secure express app
api.use(helmet({
  dnsPrefetchControl: false,
  frameguard: false,
  ieNoOpen: false,
}));

// parsing the request bodys
api.use(bodyParser.urlencoded({ extended: false }));
api.use(bodyParser.json());

// public REST API
// descomentar para funcionar a autetcacao api.use('/rest', mappedRoutes);
api.use('/auth', mappedRoutes);

// comentar bloco abaixo para nao permitir nao autorizados a utilizar o graphql console
/*api.use('/graphql', GraphHTTP({
  schema: Schema,
  rootValue: root,
  graphiql: true,
}));*/

// private GraphQL API
api.all('/graphql', (req, res, next) => auth(req, res, next));
api.get('/graphql', GraphHTTP({
  schema: Schema,
  pretty: true,
  graphiql: false,
}));

api.post('/graphql', GraphHTTP({
  schema: Schema,
  pretty: true,
  graphiql: false,
}));

server.listen(config.port, () => {
  if (environment.trim() !== 'production' &&
      environment.trim() !== 'development' &&
      environment.trim() !== 'testing'
  ) {
    console.error(`NODE_ENV is set to ${environment.trim()}, but only production and development are valid.`);
    process.exit(1);
  }
  return DB;
});
