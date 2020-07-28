var connection = new signalR.HubConnectionBuilder()
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

var joinRoom = function () {
    var chatroomName = document.getElementById("chatroomName").value;
    axios.post(`/ChatConnection/JoinRoom/${_connectionId}/${chatroomName}`)
        .then(res => {
        })
        .catch(err => {
            console.log(err);
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
            updateScroll();
            document.getElementById("inputText").value = "";
        })
        .catch(err => {
            console.log(err);
        })
}