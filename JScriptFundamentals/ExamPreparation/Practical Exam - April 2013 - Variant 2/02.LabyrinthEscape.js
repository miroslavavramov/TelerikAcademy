function Solve(args) {
    function valueDirectionPair(val, dir) {
        return{
            val: val,
            dir: dir
        }
    }

    var fieldDimensions = args[0].split(' ');
    var maxRows = parseInt(fieldDimensions[0], 10);
    var maxCols = parseInt(fieldDimensions[1], 10);
    var field = [];
    var boxValue = 1;

    for (var r = 0; r < maxRows; r++) {
        field.push([]);
        var line = args[r + 2];
        for (var c = 0; c < maxCols; c++, boxValue++) {
            field[r].push(
                    new valueDirectionPair(parseInt(boxValue, 10), args[r + 2][c])
            );
        }
    }

    var startCoords = args[1].split(' ');
    var row = parseInt(startCoords[0], 10);
    var col = parseInt(startCoords[1], 10);

    var sum = 0;
    var cellsInPath = 0;
    var dir = '';

    while (true) {
        sum += field[row][col].val;
        cellsInPath++;
        field[row][col].val = -1;   //mark as visited
        dir = field[row][col].dir;

        switch (dir) {
            case 'l': col--; break;
            case 'r': col++; break;
            case 'u': row--; break;
            case 'd': row++; break;
        }

        if (row < 0 || row >= maxRows || col < 0 || col >= maxCols) {
            return 'out ' + sum;
        }
        if (field[row][col].val === -1) {
            return 'lost ' + cellsInPath;
        }
    }
}