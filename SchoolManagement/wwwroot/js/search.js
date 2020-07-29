function searchUsers() {
    var input = document.getElementById("searchInput").value.toLowerCase();

    var userRows = document.getElementsByClassName("userRow");
    
    for (var i = 0; i < userRows.length; i++) {

        var td = userRows[i].getElementsByTagName("td")[0];
        var textValue = td.innerText.toLowerCase();
        if (textValue.indexOf(input) >-1) {

            userRows[i].style.display = "";
        } else {
            userRows[i].style.display = "none";
        }
    }
}