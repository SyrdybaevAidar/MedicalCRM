"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (sender, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.className = "clearfix";
    var messageData = document.createElement("div");
    var messageDiv = document.createElement("div");
    messageDiv.innerText = message;
    messageDiv.className = "message other-message float-left";

    messageData.className = "message-data";
    li.appendChild(messageDiv);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var sender = document.getElementById("senderInput").value;
    var receiver = document.getElementById("receiverInput").value;
    var message = document.getElementById("messageInput").value;

    if (receiver != "") {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var li = document.createElement("li");
        document.getElementById("messagesList").appendChild(li);
        li.className = "clearfix";
        var messageDiv = document.createElement("div");
        messageDiv.innerText = msg;
        messageDiv.className = "message my-message float-right";
        li.appendChild(messageDiv);
        document.getElementById("messagesList").appendChild(li);
        document.getElementById("messageInput").value = "";
        connection.invoke("SendMessageToGroup", sender, receiver, message).catch(function (err) {
            return console.error(err.toString());
        });
    }
    else {
        connection.invoke("SendMessage", sender, message).catch(function (err) {
            return console.error(err.toString());
        });
    }


    event.preventDefault();
});