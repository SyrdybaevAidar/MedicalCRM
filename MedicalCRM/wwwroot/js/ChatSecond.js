"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (sender, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.className = "clearfix";
    
    var messageDiv = document.createElement("div");
    messageDiv.className = "message other-message float-left row";

    var d = new Date();
    var messageData = document.createElement("div");
    messageData.className = "pb-2";
    messageData.innerText = d.getHours() + ":" + d.getMinutes();

    var messageText = document.createElement("div");
    messageText.innerText = message;
    messageDiv.appendChild(messageData);
    messageDiv.appendChild(messageText);

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
        var li = document.createElement("li");
        document.getElementById("messagesList").appendChild(li);
        li.className = "clearfix";

        var messageDiv = document.createElement("div");
        messageDiv.className = "message other-message float-right row";

        var d = new Date();
        var datetext = d.toTimeString();
        var messageData = document.createElement("div");
        messageData.className = "pb-2";
        messageData.innerText = d.getHours() + ":" + d.getMinutes();

        var messageText = document.createElement("div");
        messageText.innerText = message;
        messageDiv.appendChild(messageData);
        messageDiv.appendChild(messageText);

        li.appendChild(messageDiv);
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