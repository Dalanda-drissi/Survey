const mongoose = require('mongoose');

const fileSchema = new mongoose.Schema(
    {
        AssetsBundleID : String,
        Rotation:String,
        Position:String,
        LocalScale:String,
        Label:String,
        Date :Date,
        Description : String,
        NBStand: String,
        sceneObjects: Array,
},
 {
    collection: 'Batiment'
 });

module.exports = mongoose.model('Batiment', fileSchema);