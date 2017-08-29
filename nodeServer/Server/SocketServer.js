var socketio = require('socket.io')({
    transport:['websocket'],
});

socketio.attach(8080);

var sqlOperate = require('./sqlOperate.js');
var messageids=require('./MessageID.js');

var users = {};
var mSocket;
socketio.on('connect', function (socket) {
    mSocket=socket;
    BindSigal(messageids.login,login);

    //登录
    function login(data) {
        users[data] = socket;
        //console.log(users);
        console.log(data);
        var userAcc = JSON.parse(JSON.stringify(data));
         sqlOperate.login(userAcc,loginRsp);
    }
    function  loginRsp(msg) {
        console.log(msg);
        SendMsg(messageids.loginRsp,msg);
    }

    socket.on('privatemsg', function (from, to, msg) {
        console.log('I received a private message by ', from, ' say to ', to, msg);
        if (to in users) {
            users[to].emit('to' + to, {msg: msg, user: from});
        }
    });
    socket.on('disconnect', function () {
        console.log('connection is disconnect! ');
        //console.log(users);
    });
})

function BindSigal(key,call) {
    mSocket.on(key.toString(),call);
}
function  SendMsg(key,msg) {
    mSocket.emit(key.toString(),msg);
}