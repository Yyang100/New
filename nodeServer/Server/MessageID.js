var messageids={};
messageids.BindSigal=function(socket,key,call) {
    try {
        socket.on(key.toString(), call);
    }
    catch (err) {
        console.log(err);
    }
}
messageids.SendMsg=function(socket, key,msg) {
    try {
        socket.emit(key.toString(), msg);
    }
    catch(err){
        console.log(err);
    }
}

// -------------------------ids--------------------------
messageids.login         = 100001;
messageids.loginRsp      = 200001;




module.exports=messageids;