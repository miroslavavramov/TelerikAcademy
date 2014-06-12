var applicationName = navigator.appName;
var hasScroll = navigator.userAgent.indexOf('MSIE 5') > 0 || navigator.userAgent.indexOf('MSIE 6') > 0;

var off = 0;
var txt = '';
var positionX = 0;
var positionY = 0;

document.onmousemove = mouseMove;

if (applicationName == 'Netscape') {
    document.captureEvents(Event.MOUSEMOVE)
}

function mouseMove(evn) {
    if (applicationName == 'Netscape') {
        positionX = evn.pageX - 5;
        positionY = evn.pageY;

        if (document.layers['ToolTip'].visibility == 'show') {
            popTip();
        }
    } else {
        positionX = event.x - 5;
        positionY = event.y;

        if (document.all['ToolTip'].style.visibility == 'visible') {
            popTip();
        }
    }
}

function popTip() {
    if (applicationName == 'Netscape') {
        theLayer = eval('document.layers[\'ToolTip\']');

        if ((positionX + 120) > window.innerWidth) {
            positionX = window.innerWidth - 150;
        }

        theLayer.left = positionX + 10;
        theLayer.top = positionY + 15;
        theLayer.visibility = 'show';
    } else {
        theLayer = eval('document.all[\'ToolTip\']');

        if (theLayer) {
            positionX = event.x - 5;
            positionY = event.y;

            if (hasScroll) {
                positionX = positionX + document.body.scrollLeft;
                positionY = positionY + document.body.scrollTop;
            }
            if ((positionX + 120) > document.body.clientWidth) {
                positionX = positionX - 150;
            }

            theLayer.style.pixelLeft = positionX + 10;
            theLayer.style.pixelTop = positionY + 15;
            theLayer.style.visibility = 'visible';
        }
    }
}

function hideTip() {
    if (b == 'Netscape') {
        document.layers['ToolTip'].visibility = 'hide';
    }
    else {
        document.all['ToolTip'].style.visibility = 'hidden';
    }
}

function hideMenu1() {
    if (b == 'Netscape') {
        document.layers['menu1'].visibility = 'hide';
    } else {
        document.all['menu1'].style.visibility = 'hidden';
    }
}

function showMenu1() {
    if (b == 'Netscape') {
        theLayer = eval('document.layers[\'menu1\']');
        theLayer.visibility = 'show';
    } else {
        theLayer = eval('document.all[\'menu1\']');
        theLayer.style.visibility = 'visible';
    }
}

function hideMenu2() {
    if (b == "Netscape") {
        document.layers['menu2'].visibility = 'hide';
    } else {
        document.all['menu2'].style.visibility = 'hidden';
    }
}

function ShowMenu2() {
    if (b == "Netscape") {
        theLayer = eval('document.layers[\'menu2\']');
        theLayer.visibility = 'show';
    } else {
        theLayer = eval('document.all[\'menu2\']');
        theLayer.style.visibility = 'visible';
    }
}