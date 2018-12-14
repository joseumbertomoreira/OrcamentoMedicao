const express = require('express');
const app = express();
const bodyParser = require('body-parser')
const request = require('request');
const MongoClient = require('mongodb').MongoClient;
const assert = require('assert');
const port = 3000

app.use(express.static(__dirname + "./../client"));
app.use(bodyParser.json({limit: '50mb'}))
app.use(bodyParser.urlencoded({limit: '50mb', extended: true }))




/*()
const url = 'mongodb://address:i123456@ds163020.mlab.com:63020/address-search';

const client = new MongoClient(url);

const dbName = 'address-search';
MongoClient.connect(url, function(err, client) {
	let db = client.db('address')
	let songs = db.collection('songs');

	songs.insertOne(seedData, function(err, result) {

	});

})
*/



let distrctSearch = function(district, districtsJson){
	for(let i = 0; i < districtsJson.length; i++){
		if(district === districtsJson[i].bairro) return districtsJson[i]
	}
	return -1;
}



app.post('/form', (req, resp) =>{

	let streetSplit = req.body.street.split(" ");

	request(`https://viacep.com.br/ws/GO/Goiania/${streetSplit[0]}+${streetSplit[1]}/json/`,
	 { json: true }, (err, res, districtsJson) => {
	  	if (err) { return console.log(err); }
	  	if(districtsJson  !== [] && distrctSearch(req.body.district, districtsJson) !== -1){
	  		resp.send(distrctSearch(req.body.district, districtsJson));
	  	}else{
	  		resp.send();
	  	}
	  	
	});

})

app.listen(port, ()=>{
	console.log(`Server is running on port ${port}`)
})


//Setor Central
//Setor Centro Oeste
//Setor Campinas