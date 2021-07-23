const mongoose = require('mongoose');
const fileSchema = new mongoose.Schema(
    {
        Label:String,
        QuestionTxt :String,
        OptionsList: Array,
        Creator: String,
        Visibility:String,
        
      
},
 {
    collection: 'Question'
 });

module.exports = mongoose.model('Question', fileSchema);