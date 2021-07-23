const mongoose = require('mongoose');
const Schema = mongoose.Schema;
// Define collection and schema
let User = new Schema({
  
   Email: {
      type: String
   },
   Password: {
      type: String
   }

   
   
}, {
   collection: 'User'
})
module.exports = mongoose.model('User', User)