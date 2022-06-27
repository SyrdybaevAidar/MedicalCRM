"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendToUser").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.className = "clearfix";
    var messageData = document.createElement("div");
    var messageDataTime = document.createElement("time");
    var messageDiv = document.createElement("div");
    var current = new Date();
    var dateString = current.toISOString();
    messageDiv.innerText = message;
    messageDiv.className = "message my-message";
    messageDataTime.innerText = dateString;
    
    messageData.className = "message-data";
    messageData.appendChild(messageDataTime);
    li.appendChild(messageData);
    li.appendChild(messageDiv);
});

connection.start().then(function () {
    document.getElementById("sendToUser").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendToUser").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var receiverConnectionId = document.getElementById("ChatId").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendToUser", user, receiverConnectionId, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
})