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
        var mapOptions = as.viberChat(cont, options);
    },


};