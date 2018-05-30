const bcrypt = require('bcrypt-nodejs');

module.exports = {
  passwordHash: (password) => {
    const salt = bcrypt.genSaltSync();
    const hash = bcrypt.hashSync(password, salt);

    return hash;
  },
  comparePassword: (password, hash) => (
    bcrypt.compareSync(password, hash)
  ),
};
