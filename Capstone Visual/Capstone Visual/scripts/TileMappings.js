var wordIds = new Array(30);
var letterCount = 0;
function getSource(owner, letter) {
    var newSrc;
    if (owner == "EMPTY") {
        switch (letter) {
            case "A": newSrc = "http://i.imgur.com/z9vlX9v.png"; break;
            case "B": newSrc = "http://i.imgur.com/fFkw2qO.png"; break;
            case "C": newSrc = "http://i.imgur.com/pB2ZqNf.png"; break;
            case "D": newSrc = "http://i.imgur.com/VakY6cL.png"; break;
            case "E": newSrc = "http://i.imgur.com/3hefvZn.png"; break;
            case "F": newSrc = "http://i.imgur.com/zbM0gGB.png"; break;
            case "G": newSrc = "http://i.imgur.com/dhMwX4r.png"; break;
            case "H": newSrc = "http://i.imgur.com/DC7eoit.png"; break;
            case "I": newSrc = "http://i.imgur.com/P54aVv9.png"; break;
            case "J": newSrc = "http://i.imgur.com/59svHlI.png"; break;
            case "K": newSrc = "http://i.imgur.com/a6vhVs0.png"; break;
            case "L": newSrc = "http://i.imgur.com/E7Qcpcs.png"; break;
            case "M": newSrc = "http://i.imgur.com/xpZ0aNL.png"; break;
            case "N": newSrc = "http://i.imgur.com/F3vhM76.png"; break;
            case "O": newSrc = "http://i.imgur.com/AVWZiZC.png"; break;
            case "P": newSrc = "http://i.imgur.com/aP0IZON.png"; break;
            case "Q": newSrc = "http://i.imgur.com/oZ2PRaC.png"; break;
            case "R": newSrc = "http://i.imgur.com/nkNStiz.png"; break;
            case "S": newSrc = "http://i.imgur.com/tKEtukb.png"; break;
            case "T": newSrc = "http://i.imgur.com/Z5WAOCQ.png"; break;
            case "U": newSrc = "http://i.imgur.com/QECvVp2.png"; break;
            case "V": newSrc = "http://i.imgur.com/XeJJE3h.png"; break;
            case "W": newSrc = "http://i.imgur.com/gTNftV6.png"; break;
            case "X": newSrc = "http://i.imgur.com/zzftSWE.png"; break;
            case "Y": newSrc = "http://i.imgur.com/e77tePd.png"; break;
            case "Z": newSrc = "http://i.imgur.com/gBcJFEM.png"; break;
            default: newSrc = "http://i.imgur.com/bbaSk8D.png"; break;
        }
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
    var let1 = tile.getAttribute("data-letter");
    if (tile.getAttribute("data-owner") == "EMPTY") {   //If empty
        tile.src = getSource("PLAYER1", let1);
        tile.setAttribute("data-owner", "PLAYER1");                     //Replace with logged in player value...eventually
        letterCount++;
        wordIds[letterCount] = id;
    }
    else {
        tile.src = getSource("EMPTY", let1);
        tile.setAttribute("data-owner", "EMPTY");
        var index = wordIds.indexOf(id);
        for(index; index < letterCount-1; index++)
        {
            wordIds[index] = wordIds[index + 1];
        }
        wordIds[letterCount] = "";
        letterCount--;
    }
}

