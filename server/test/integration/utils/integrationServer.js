'use strict';

const express = require('express');
const graphql = require('graphql').graphql;
const request = require('request-promise');
const bodyParser = require('body-parser');
const mapRoutes = require('express-routes-mapper');
const cors = require('cors');

const config = require('../../../config/');
const mappedRoutes = mapRoutes(config.publicRoutes, 'api/controllers/Auth/');
const rootSchema = require('../../../api/graphql/schema');

function start(done, appPort) {
  const app = express();
  const PORT = appPort || 9000;

  // parsing the request bodys
  app.use(bodyParser.urlencoded({ extended: false }));
  app.use(bodyParser.json());

  // public REST API
  // descomentar para funcionar a autetcacao api.use('/rest', mappedRoutes);
  app.use('/auth', mappedRoutes);

  app.get('/graphql', (req, res) => {
    const graphqlQuery = req.query.graphqlQuery;
    if (!graphqlQuery) {
      return res.status(500).send('Você deve fornecer uma consulta');
    }

    return graphql(rootSchema, graphqlQuery)
      .then(response => response.data)
      .then((data) => res.json(data))
      .catch((err) => console.error(err));
  });

  return app.listen(PORT, () => {
    console.log('Server started at port [%s]', PORT);
    done();
  });
};

function stop(app, done) {
  app.close();
  done();
};

function restFull(app, uri, payload) {

  let requestConfig = {
    method: 'POST',
    baseUrl : `http://localhost:${app.address().port}`,
    uri : uri,
    body : payload,
    resolveWithFullResponse: true,
    json: true
  };

  console.log(JSON.stringify(requestConfig));

  return request(requestConfig);
};

function graphqlQuery(app, query) {
  return request({
    baseUrl : `http://localhost:${app.address().port}`,
    uri : '/graphql',
    qs : {
      graphqlQuery : query
    },
    resolveWithFullResponse: true,
    json: true
  })
};

module.exports = {
  start,
  stop,
  restFull,
  graphqlQuery
};