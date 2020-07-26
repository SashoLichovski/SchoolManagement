﻿var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

var _connectionId = "";
connection.on("ReceiveMessage", function (data) {
    var chat = document.getElementById("chat");

    var message = document.createElement("div");
    message.classList.add("message");
    chat.appendChild(message);

    var header = document.createElement("header");
    header.innerHTML = data.createdBy + ":";
    message.appendChild(header);

    var textMsg = document.createElement("p");
    textMsg.innerHTML = data.text;
    message.appendChild(textMsg);

    var footer = document.createElement("footer");
    footer.innerHTML = data.datePosted;
    message.appendChild(footer);

    updateScroll();
})

var roomId = document.getElementById("chatroomId").value;
var joinRoom = function () {
    axios.post(`/ChatConnection/JoinRoom/${_connectionId}/${roomId}`)
        .then(res => {
            console.log("It works");
        })
        .catch(err => {
            console.log("Failed !", err);
        })
}

connection.start()
    .then(function () {
        connection.invoke("getConnectionId")
            .then(function (connectionId) {
                _connectionId = connectionId
                joinRoom();
            })
    })
    .catch(function (err) {
        console.log(err);
    });

var sendMessage = function (event) {
    event.preventDefault();
    var data = new FormData(event.target);

    axios.post("/ChatConnection/SendMessage", data)
        .then(res => {
            console.log("Message sent");
            updateScroll();
            document.getElementById("inputText").value = "";
        })
        .catch(err => {
            console.log("Failed");
        })
}