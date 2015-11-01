/// <reference path="jquery-1.11.3.min.js" />
function object() {
    if(window.XMLHttpRequest)
    {
        xmlhttp = new XMLHttpRequest();
    }
    else {
        xmlhttp = new ActiveXObject();
    }
    return xmlhttp;
}

var http = new object();

function RemoveComment(DivHide, pId, pPostId) {
    document.getElementById(DivAn).style.display = "none";
    http.open("GET", "Home/Remove/" + pId + "/" + pPostId, false);
}