var sqlOperate = require('./loginSqlOperate.js');
var messageids=require('.././MessageID.js');

var loginServer={};

var Socket;
loginServer.Init=function (socket) {
    Socket=socket;
}
loginServer.login= function(data) {
    console.log(data);
    var userAcc = JSON.parse(JSON.stringify(data));
    sqlOperate.login(userAcc,loginRsp);
}
function  loginRsp(msg) {
    console.log(msg);
    messageids.SendMsg(Socket,messageids.loginRsp,msg);
}

module.exports=loginServer;