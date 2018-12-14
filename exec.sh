#!/bin/bash

git clone https://github.com/joseumbertomoreira/AddressSearch.git
cd AddressSearch && cd server
npm install
nodemon app.js