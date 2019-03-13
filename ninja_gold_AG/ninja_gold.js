var express = require("express");
console.log("Let's find out what express is", express);
var app = express();
const mongoose = require("mongoose");
var session = require('express-session');
var bodyParser = require('body-parser');
console.log("Let's find out what app is", app);
mongoose.connect('mongodb://localhost/basic_mongoose');
app.use(session({
  secret: 'warlocks',
  resave: false,
  saveUninitialized: true,
  cookie: { maxAge: 60000 }
}))
app.use(bodyParser.urlencoded({extended: true}));
app.use(express.static(__dirname + '/static'));
app.set('views', __dirname + '/views');
app.set('view engine', 'ejs');

const ScoreSchema = new mongoose.Schema
({
    
    name: {type: String, required: true, minlength: 5}, 
    Score: Number
},{timestamps: true})
mongoose.model('Score', ScoreSchema);
var Score = mongoose.model('Score')
app.get('/', function(request, response) 
{  
  response.render('index');
})
app.get('/ninja', function(request, response) 
{
    var data = 
    {
        name: request.session.name,
        change: request.session.change,
        gold: request.session.gold,
        type: request.session.type
    }
    response.render("index", data);
})
app.post("/ninja", function (request, response)
{
    request.session.name = request.body.name;
    if(request.session.change == undefined)
    {
    request.session.change = 0;
    request.session.gold = 0;

    }
    response.redirect('ninja');
})
app.post("/submit", function (request, response)
{
    
    if(request.body.type == "farm")
    {
        var change = Math.floor(Math.random() * 20) + 10;
        request.session.gold += change;
        request.session.change = change;
        request.session.type = request.body.type
    }
    if(request.body.type == "cave")
    {   
        var change = Math.floor(Math.random() * 10) + 5;
        request.session.gold += change;
        request.session.change = change;
        request.session.type = request.body.type
    }
    if(request.body.type == "house")
    {
        var change = Math.floor(Math.random() * 5) + 2;
        request.session.gold += change;
        request.session.change = change;
        request.session.type = request.body.type
    }
    if(request.body.type == "casino")
    {
        var change = Math.floor(Math.random() * 50) + (-10);
        request.session.gold += change;
        request.session.change = change;
        request.session.type = request.body.type
    }
    console.log(request.session.gold);
    console.log(request.session.type);
    response.redirect('/ninja');
})
app.post("/score", function (request, response)
{
    Score.create(request.body, function(err, data)
    {
        Score.find((err, scores) => {
            if (!err) {
                response.render('scores', {scores: scores})
            }
        })
    });
}); 
app.get('/scores', function(request, response) 
{
    Score.find({}).sort({score: 'descending'}).limit(5).exec(function(err, data)
{
   
        console.log(data)
        response.render('scores', {scores: data});

})
})
app.get('/clear', function(request, response) 
{
    request.session.destroy()
    response.redirect('/')
})
app.listen(8000, function() 
{
  console.log("listening on port 8000");
})