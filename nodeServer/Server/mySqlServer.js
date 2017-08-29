var mysql=require('mysql');
var connect=mysql.createConnection(
    {
        host     : 'localhost',
        user     : 'root',
        password : '123456',
        database : 'Game'
    }
);
connect.connect(function (err) {
    if(err)
    {
        console.log('mysql connect fail');
    }
});
module.exports=connect;