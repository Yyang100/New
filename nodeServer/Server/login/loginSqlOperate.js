var operate = {};
var mySql = require('../mySqlServer.js');
operate.login = function (userAcc,rsp) {
    mySql.query('select * from Account where acc="' + userAcc.acc + '"',
        function (err, result) {
            if (err) {
                console.log(err);
            }
            else {
                var userinfos = JSON.parse(JSON.stringify(result));
                var msg = {
                    res: 0,
                    des: "",
                    user: ""
                };
                if (userinfos.length <= 0) {
                    msg.res = -1;
                    msg.des = "帐号不存在";
                    rsp(msg);
                    return;
                }
                var succ = false;
                var uin;
                for (var i = 0; i < userinfos.length; i++) {
                    if (userinfos[i].acc == userAcc.acc && userinfos[i].pw == userAcc.pw) {
                        succ = true;
                        uin=userinfos[i].uin;
                        break;
                    }
                }
                if (succ) {
                    mySql.query('select * from userInfo where uin="' + uin + '"',
                        function (err, result) {
                            if (err) {
                                console.log(err);
                            }
                            else {
                                userinfos = JSON.parse(JSON.stringify(result));
                                var msg = {
                                    res: 0,
                                    des: "",
                                    user: ""
                                };
                                if (userinfos.length <= 0) {
                                    //创建角色？
                                }
                                for (var i = 0; i < userinfos.length; i++) {
                                    if (userinfos[i].uin == uin) {
                                        msg.res = 0;
                                        msg.user = userinfos[i];
                                        msg.des = "ok";
                                        rsp(msg);
                                        break;
                                    }
                                }
                            }
                        });
                }
                else {
                    msg.res = 101;
                    msg.des = "password fail";
                    // rsp.send(msg);
                    rsp(msg);
                }
            }
        });
};

operate.registeruser = function (req, rsp) {
    mySql.query('select * from userinfo where uin="' + req.query.user + '"',
        function (err, result) {
            if (err) {
                console.log(err);
            }
            else {
                var userinfos = JSON.parse(JSON.stringify(result));
                var msg = {
                    resultid: 0,
                    des: ""
                };
                if (userinfos.length <= 0) {
                    msg.resultid = 0;
                    msg.des = '帐号可用';
                    rsp.send(msg);
                } else {
                    msg.resultid = -1;
                    msg.des = '帐号被注册';
                    rsp.send(msg);
                }
            }
        });
};
operate.register = function (req, rsp) {
    mySql.query('select * from userinfo where user="' + req.query.user + '"',
        function (err, result) {
            if (err) {
                console.log(err);
            }
            else {
                var userinfos = JSON.parse(JSON.stringify(result));
                var msg = {
                    resultid: 0,
                    des: ""
                };
                if (userinfos.length <= 0) {
                    var sql = 'insert into userinfo (user,password) values (?,?)';
                    var sqlparam = [req.query.user, req.query.pw];
                    console.log(req.query.pw);
                    mySql.query(sql, sqlparam, function (err, result) {
                        if (err) {
                            console.log(err);
                        } else {
                            msg.resultid = 0;
                            msg.des = '注册成功';
                            rsp.send(msg);
                        }
                    })
                }
                else {
                    msg.resultid = -1;
                    msg.des = '帐号被注册';
                    rsp.send(msg);
                }
            }
        })
};

operate.getfriendList = function (req, rsp) {
    mySql.query('select * from friendinfo where user="' + req.query.user + '"',
        function (err, result) {
            if (err) {
                console.log(err);
            } else {
                var friendlistinfo = JSON.parse(JSON.stringify(result));
                var msg = {
                    resultid: 0,
                    friendlist: [],
                    des: ""
                };
                console.log(friendlistinfo);
                if (friendlistinfo.length <= 0) {
                    msg.resultid = -1;
                    msg.des = "您还没有好友快去添加吧";
                    rsp.send(msg);
                } else {
                    msg.resultid = 0;
                    for (var i = 0; i < friendlistinfo.length; i++) {
                        msg.friendlist.push(friendlistinfo[i].friend);
                    }
                    rsp.send(msg);
                }
            }
        });
};

module.exports = operate;