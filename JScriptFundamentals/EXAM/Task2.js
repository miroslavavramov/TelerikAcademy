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

    function hasEscaped(currRow, currCol) {
        return !(currRow >= 0 && currRow < maxRow && currCol >= 0 && currCol < maxCol);
    }

    function dirValuePair(dir, val) {
        return {
            dir: dir,
            value: val
        }
    }

    var grid = [];
    var dimensions = args[0].split(' ').clean('');
    var maxRow = parseInt(dimensions[0], 10);
    var maxCol = parseInt(dimensions[1], 10);
    var boxValue;
    var dirs;

    for (var r = 0; r < maxRow; r++) {
        boxValue = Math.pow(2, r);
        grid.push([]);
        dirs = args[r + 1].split(' ').clean('');
        for (var c = 0; c < maxCol; c++, boxValue++) {
            grid[r].push(new dirValuePair(dirs[c], boxValue));
        }
    }

    var sum = 0;
    var currRow = 0;
    var currCol = 0;

    while (true) {
        if (!hasEscaped(currRow, currCol)) {
            if (grid[currRow][currCol].value === -1) {
                return 'failed at (' + currRow + ', ' + currCol + ')';
            }

            sum += grid[currRow][currCol].value;
            grid[currRow][currCol].value = -1;  //mark as visited

            switch (grid[currRow][currCol].dir) {
                case 'dr':
                    currRow++;
                    currCol++;
                    break;
                case 'ur':
                    currRow--;
                    currCol++;
                    break;
                case 'dl':
                    currRow++;
                    currCol--;
                    break;
                case 'ul':
                    currRow--;
                    currCol--;
                    break;
            }
        } else {
            return 'successed with ' + sum;
        }
    }

}

var args = [
    '3 5',
    'dr dl dr ur ul',
    'dr dr ul ur ur',
    'dl dr ur dl ur'
];

var answer = solve(args);
console.log(answer);
