const express = require('express');
const QuestionRoute = express.Router();
let Question = require('../Models/Question');

QuestionRoute.route('/create').post((req, res, next) => {
  
    Question.create(req.body, (error, data) => {
        
      if (error) {
        return next(error)
       
      } else {
        console.log(data._id)
      res.send(data._id)  ;
        
      }
    })
  });
  QuestionRoute.route('/read').get((req, res,next) => {
    
    Question.find( {Visibility: "true"}, (error, data) => {
      if (error) {
        return next(error)
      } else {
        res.send(data)
      }
    })
  })
  QuestionRoute.route('/readByIdUser/:id').get((req, res,next) => {
    console.log(req.params.id)
    Question.find( {Creator: req.params.id}, (error, data) => {
      if (error) {
        return next(error)
      } else {
        res.send(data)
      }
    })
  })
  QuestionRoute.route('/readByName/:Label').get((req, res,next) => {
    console.log(req.params.Label)
    Question.findOne( {Label: req.params.Label}, (error, data) => {
      if (error) {
        return next(error)
      } else {
        res.send(data)
      }
    })
  })

  QuestionRoute.route('/update/:id').put((req, res, next) => {
    console.log(req.body)
    Question.findByIdAndUpdate(req.params.id, {
      OptionsList :req.body.OptionsList
    }, (error, data) => {
      if (error) {
        return next(error);
        console.log(error)
      } else {
        res.json(data)
        console.log('Question updated successfully')
      }
    })
  })
  QuestionRoute.route('/update/Visibility/:id').put((req, res, next) => {
    console.log(req.body)
    Question.findByIdAndUpdate(req.params.id, {
      Visibility :req.body.Visibility
    }, (error, data) => {
      if (error) {
        return next(error);
        console.log(error)
      } else {
        res.json(data)
        console.log('Visibility updated successfully')
      }
    })
  })
module.exports = QuestionRoute;