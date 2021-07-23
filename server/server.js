

const express = require("express");
var bodyParser  = require("body-parser");
cors = require('cors');
const app = express();
var mongoose = require("mongoose");
const mongoURI = "mongodb://localhost:27017/Survey";
mongoose.connect(mongoURI, { useNewUrlParser: true, useUnifiedTopology: true }).then(() => {
	if(process.env.NODE_ENV !== "test") {
		console.log("Connected to %s", mongoURI);
		console.log("App is running ... \n");
		console.log("Press CTRL + C to stop the process. \n");
	}
})
	.catch(err => {
		console.error("App starting error:", err.message);
		process.exit(1);
	});

app.use(express.json()); 
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
  extended: true
}));


app.use(function (req, res, next) {

	// Website you wish to allow to connect
	res.setHeader('Access-Control-Allow-Origin', '*');

	// Request methods you wish to allow
	res.setHeader('Access-Control-Allow-Methods', 'GET, POST, OPTIONS, PUT, PATCH, DELETE');

	// Request headers you wish to allow
	res.setHeader('Access-Control-Allow-Headers', 'X-Requested-With,content-type');

	// Set to true if you need the website to include cookies in the requests sent
	// to the API (e.g. in case you use sessions)
	res.setHeader('Access-Control-Allow-Credentials', true);

	// Pass to next layer of middleware
	next();
}); 

app.use(cors()); 
const port = process.env.PORT || 4000;
const server = app.listen(port, () => {
  console.log('Connected to port ' + port)
})
app.set("view engine", "ejs");

const UserRoute = require('./Routers/User.route');
const QuestionRoute= require('./Routers/Question.route');

app.use('/User', UserRoute);
app.use('/Question',QuestionRoute);

 