var socketio = require('socket.io')({
    transport:['websocket'],
});

socketio.attach(4567);

var sqlOperate = require('./sqlOperate.js');

var users = {};

socketio.on('connect', function (socket) {
    socket.on('222', function (data) {
        users[data] = socket;
        console.log(users);
        var msg={
            res:socket.id
        };
        console.log(data);
        var userinfos = JSON.parse(JSON.stringify(data));
        sqlOperate.login(userinfos.id,
            socket.emit('111',msg));
    });

    socket.on('privatemsg', function (from, to, msg) {
        console.log('I received a private message by ', from, ' say to ', to, msg);
        if (to in users) {
            users[to].emit('to' + to, {msg: msg, user: from});
        }
    });
    socket.on('disconnect', function () {
        console.log('connection is disconnect! ');
        console.log(users);
    });
})