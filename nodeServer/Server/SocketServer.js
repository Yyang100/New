var socketio = require('socket.io')({
    transport:['websocket'],
});

socketio.attach(8080);


var messageids=require('./MessageID.js');
var loginServer=require('./login/loginServer.js');

var users = new Array();
socketio.on('connect', function (socket) {
    users[socket.id]=socket;
    //--------------------------登录-------------------------------
    loginServer.Init(socket);
    messageids.BindSigal(socket,messageids.login,loginServer.login);


    socket.on('disconnect', function () {
        console.log('connection is disconnect! '+users[socket.id].id);
        delete users[socket.id];
    });
})
