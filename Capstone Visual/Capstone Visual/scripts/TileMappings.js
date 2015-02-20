function getSource(owner, letter) {
    var newSrc;
    if (owner == "EMPTY") {
        
    }
    else if (owner == "PLAYER1") {
        switch (letter) {
            case "A": newSrc = "http://i.imgur.com/plho0h6.png"; break;
            case "B": newSrc = "http://i.imgur.com/3giverr.png"; break;
            case "C": newSrc = "http://i.imgur.com/378Dm0f.png"; break;
            case "D": newSrc = "http://i.imgur.com/YhKhBB3.png"; break;
            case "E": newSrc = "http://i.imgur.com/EH5JSS2.png"; break;
            case "F": newSrc = "http://i.imgur.com/VVhcVd5.png"; break;
            case "G": newSrc = "http://i.imgur.com/wvYLMj4.png"; break;
            case "H": newSrc = "http://i.imgur.com/ffJublH.png"; break;
            case "I": newSrc = "http://i.imgur.com/tyO8GZk.png"; break;
            case "J": newSrc = "http://i.imgur.com/GqlvdmA.png"; break;
            case "K": newSrc = "http://i.imgur.com/t1Fyk5b.png"; break;
            case "L": newSrc = "http://i.imgur.com/laBUzXn.png"; break;
            case "M": newSrc = "http://i.imgur.com/HqtK6Ku.png"; break;
            case "N": newSrc = "http://i.imgur.com/Id9urTa.png"; break;
            case "O": newSrc = "http://i.imgur.com/WCbneHK.png"; break;
            case "P": newSrc = "http://i.imgur.com/xWRrBxa.png"; break;
            case "Q": newSrc = "http://i.imgur.com/rAvfnd4.png"; break;
            case "R": newSrc = "http://i.imgur.com/XDDM8N4.png"; break;
            case "S": newSrc = "http://i.imgur.com/1WpuIid.png"; break;
            case "T": newSrc = "http://i.imgur.com/W9wQX7s.png"; break;
            case "U": newSrc = "http://i.imgur.com/MxoWbqx.png"; break;
            case "V": newSrc = "http://i.imgur.com/aufnfi2.png"; break;
            case "W": newSrc = "http://i.imgur.com/qjAWDMi.png"; break;
            case "X": newSrc = "http://i.imgur.com/S2NZOhH.png"; break;
            case "Y": newSrc = "http://i.imgur.com/xp1MjeP.png"; break;
            case "Z": newSrc = "http://i.imgur.com/yifFTrL.png"; break;
            default: newSrc = "http://i.imgur.com/bbaSk8D.png"; break;
        }
    }

    return newSrc;
}

function clicked(id) {
    tile = document.getElementById(id);
    if (tile.getAttribute("data-owner") == "EMPTY") {   //If empty
        tile.src = getSource("PLAYER1", tile.getAttribute("data-letter"));
        tile.setAttribute("data-owner", "PLAYER1");                     //Replace with logged in player value...eventually
    }
    else {
        tile.src = getSource("EMPTY", tile.getAttribute("data-letter"));
        tile.setAttribute("data-owner", "EMPTY");
    }
}

function loadInitial(id) {
    tile = document.getElementById(id);
    tile.src = getSource("EMPTY", tile.getAttribute("data-letter"));
}
