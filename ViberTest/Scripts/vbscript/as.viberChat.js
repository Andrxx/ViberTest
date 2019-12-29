var as = as || {};

as.viberChat = {

    init: function (options) {
        if (as.viberChat.runInit) return;
        else as.viberChat.runInit = true;
        as.viberChat.initCallbacks();
    },

    initCallbacks: function () {

    },

    initViberChat: function (cont, options) {
        var vbOptions = as.viberChat(cont, options);
    },

    _getChatOptions: function (cont, options) {
        //console.log('');
        //console.log();
        var g = cont.attr("id");
        //console.log(g);
        if (!g) {
            g = as.viberChat.guidGenerator();
            cont.attr('id', g);
        }
        var res = as.viberChat[g] || {

        };
        console.log(res);
        res.g = g;
        return res;
    },

    guidGenerator: function () {
        var res = "";
        if (as.tools) {
            res = as.tools.guidGenerator();
        } else {
            var S4 = function () {
                return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
            };
            res = (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
        }
        return res;
    },

    setWebhook: function (cont) {
        console.log(cont);
        var data = {
            viberToken: cont.viberToken,
            botUri: cont.botUri
        };
        $.ajax({
            url: "/Home/GetWebhookAsync",
            type: 'POST',
            data: data,
            success: function (d) {
                //alert('success');
                if (d.status === "OK") {
                    console.log(d);
                }
            }
        });
    },

    removeWebhook: function (cont) {
        console.log(cont);
        var data = {
            viberToken: cont.viberToken
        };
        $.ajax({
            url: "/Home/DeleteWebhookAsync",
            type: 'POST',
            data: data,
            success: function (d) {
                //alert('success');
                if (d.status === "OK") {
                    console.log(d);
                }
            }
        });
    },

    sendMessage: function (cont) {
        console.log(cont);
        var data = {
            viberToken: cont.viberToken,
            userID: cont.userID,
            sender: cont.sender,
            msg: cont.msg
        };
        $.ajax({
            url: "/Home/SendMsgAsync",
            type: 'POST',
            data: data,
            success: function (d) {
                //alert('success');
                if (d.status === "OK") {
                    console.log(d);
                }
            }
        });
    },

    sendBroadcastMessage: function (cont) {
        console.log('broad cont');
        console.log(cont);
        var users = JSON.stringify(cont.usersID);
        var data = {
            viberToken: cont.viberToken,
            usersID: users,
            sender: cont.sender,
            msg: cont.msg
        };
        $.ajax({
            url: "/Home/SendBroadcastMsgAsync",
            type: 'POST',
            data: data,
            traditional: true,
            success: function (d) {
                //alert('success');
                if (d.status === "OK") {
                    console.log(d);
                }
            }
        });
    },
};


