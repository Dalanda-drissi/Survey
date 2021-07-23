const express = require('express');

const UserRoute = express.Router();


let User = require('../Models/User');


UserRoute.route('/create').post((req, res, next) => {
  User.create(req.body, (error, data) => {
    if (error) {
      return next(error)
    } else {
      res.json(data);
      
    }
  })
});


UserRoute.route('/').get((req, res,next) => {

  User.count( {}, function(err, result){

    if(err){
        res.send(err)
    }
    else{
        res.json(result)
    }

})

})


UserRoute.route('/read/:Email').get((req, res,next) => {
  console.log(req.params.Email)
  User.findOne( {Email : req.params.Email}, (error, data) => {
    if (error) {
      return next(error)
    } else {
      res.send(data)
    }
  })
})




// Update UserRoute
UserRoute.route('/update/:id').put((req, res, next) => {
  console.log(req.body)
  User.findByIdAndUpdate(req.params.id, {
    $set: req.body
  }, (error, data) => {
    if (error) {
      return next(error);
      console.log(error)
    } else {
      res.json(data)
      console.log('Data updated successfully')
    }
  })
})

// Delete UserRoute
UserRoute.route('/delete/:id').delete((req, res, next) => {
  console.log(req.params.id)
  User.findByIdAndRemove(req.params.id, (error, data) => {
    if (error) {
      return next(error);
    } else {
      res.status(200).json({
        msg: data
      })
    }
  })
})




module.exports = UserRoute;