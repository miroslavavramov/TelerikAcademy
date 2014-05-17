function solve(args) {
    Array.prototype.clean = function (deleteValue) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] == deleteValue) {
                this.splice(i, 1);
                i--;
            }
        }
        return this;
    };

    function Ball(x, y, z) {
        return{
            ballW: x,
            ballH: y,
            ballD: z
        }
    }

    var whd = args[0].split(' ').clean('').map(function (el) {
        return parseInt(el, 10);
    });
    var maxW = whd[0];
    var maxH = whd[1];
    var maxD = whd[2];

    var cuboid = [];

    for (var h = 0; h < maxH; h++) {
        var layer = args[h + 1].split('|').clean('');
        cuboid.push([]);
        for (var d = 0; d < maxD; d++) {
            var segment = layer[d].split(')').map(function (el) {
                return el.replace('(', '')
            }).clean('');
            cuboid[h].push([]);
            for (var w = 0; w < maxW; w++) {
                cuboid[h][d].push(segment[w].trim());
            }
        }
    }

    var ballWD = args[args.length - 1].split(' ').clean('').map(function (el) {
        return parseInt(el, 10);
    });
    var b = new Ball(ballWD[0], 0, ballWD[1]);

    var nextW = b.ballW;
    var nextH = b.ballH;
    var nextD = b.ballD;
    var currCell = '';

    while (true) {
        currCell = cuboid[b.ballH][b.ballD][b.ballW].split(' ').clean('');

        switch (currCell[0]) {
            case 'S':
                nextH++;
                switch (currCell[1]) {
                    case 'L':
                        nextW--;
                        break;
                    case 'R':
                        nextW++;
                        break;
                    case 'B':
                        nextD++;
                        break;
                    case 'F':
                        nextD--;
                        break;
                    case 'FL':
                        nextD--;
                        nextW--;
                        break;
                    case 'FR':
                        nextD--;
                        nextW++;
                        break;
                    case 'BL':
                        nextD++;
                        nextW--;
                        break;
                    case 'BR':
                        nextD++;
                        nextW++;
                        break;
                }
                break;
            case 'T':
                nextW = parseInt(currCell[1], 10);
                nextD = parseInt(currCell[2], 10);
                break;
            case 'E':
                nextH++;
                break;
            case 'B':
                return 'No\n' + b.ballW + ' ' + b.ballH + ' ' + b.ballD;
                break;
        }

        if (nextH >= maxH) {
            return 'Yes\n' + b.ballW + ' ' + b.ballH + ' ' + b.ballD;
        }
        if (nextW < 0 || nextW >= maxW || nextD < 0 || nextD >= maxD) {
            return 'No\n' + b.ballW + ' ' + b.ballH + ' ' + b.ballD;
        }

        b.ballW = nextW;
        b.ballH = nextH;
        b.ballD = nextD;
    }
}