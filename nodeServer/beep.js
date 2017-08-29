var io = require('socket.io')({
	transports: ['websocket'],
});

io.attach(4567);

io.on('connection', function(socket){
	socket.on('222', function(){
		var msg={
			res:1232
		};
		socket.emit('111',msg);
	});
})
