function solve (args) {
	Array.prototype.clean = function(deleteValue) {
		for (var i = 0; i < this.length; i++) {
			if (this[i] == deleteValue) {
				this.splice(i, 1);
				i--;
			}
		}
		return this;
	};

	function escaped(field, row, col) {
		return row < 0 || row >= maxRows || col < 0 || col >= maxCols;
	}

	var initParams = args[0].split(' ').clean('');
	var maxRows = parseInt(initParams[0]);
	var maxCols = parseInt(initParams[1]);
	var jumps = parseInt(initParams[2]);

	var field = [];

	var boxValue = 1;

	for (var row = 0; row < maxRows; row++) {
		field.push([]);
		for (var col = 0; col < maxCols; col++, boxValue++) {
			field[row].push(boxValue);
		}
	}

	var startCoords = args[1].split(' ').clean('');

	var row = parseInt(startCoords[0]);
	var col = parseInt(startCoords[1]);
	var score = field[row][col];
	var steps = 1;

	for (var i = 0; ; i++, i %= jumps) {
		var dirs = args[i+2].split(' ').clean('');
		var dirX = parseInt(dirs[0]);
		var dirY = parseInt(dirs[1]);
		row += dirX;
		col += dirY;

		if(escaped(field, row, col)){
			return 'escaped ' + score;
		} else if(field[row][col] == -1){
			return 'caught ' + i+1;
		}

		steps++;
		score += field[row][col];
		field[row][col] = -1;   //mark as visited
	}
}
