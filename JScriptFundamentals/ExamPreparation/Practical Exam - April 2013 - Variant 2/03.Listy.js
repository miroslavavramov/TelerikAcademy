function Solve(args){
	function isNumber(n) {
		return !isNaN(parseInt(n)) && isFinite(n);
	}

	String.prototype.removeDuplicateWhitespaces = function(){
		var len = this.length;
		var val = '';
		for (var i = 1; i < len; i++) {
			if(this[i] === ' ' && this[i-1] === ' '){
				continue;
			}
			val += this[i-1];
		}
		return val;
	}

	Array.prototype.clean = function (deleteValue) {
		for (var i = 0; i < this.length; i++) {
			if (this[i] == deleteValue) {
				this.splice(i, 1);
				i--;
			}
		}
		return this;
	};

	Array.prototype.sum = function () {
		var sum = this[0];
		for (var i = 1; i < this.length; i++) {
			sum += this[i];
		}
		return sum;
	};

	Array.prototype.min = function () {
		var min = this[0];
		for (var i = 1; i < this.length; i++) {
			min = this[i] < min ? this[i] : min;
		}
		return min;
	}

	Array.prototype.max = function () {
		var max = this[0];
		for (var i = 1; i < this.length; i++) {
			max = this[i] > max ? this[i] : max;
		}
		return max;
	}

	Array.prototype.avg = function () {
		return Math.floor(this.sum() / this.length);
	}

	function parseStrToIntArray(str){

		var numbersAsString = str.replace('[','').replace(']','').split(',').clean('');
		var parsedNumbers = [];

		for (var i = 0; i < numbersAsString.length; i++) {
			var element = numbersAsString[i].trim();
			if(isNumber(element)){
				parsedNumbers.push(parseInt(element, 10));
			} else {
				var val = variables[element];
				if(val instanceof Array){
					for (var k = 0; k < val.length; k++) {
						var n = val[k];
						parsedNumbers.push(n);
					}
				} else {
					parsedNumbers.push(val);
				}
			}
		}
		return parsedNumbers;
	}

	function evaluateExpression(expression) {
		var operation = getOperationType(expression);

		switch (operation){
			case 'sum': return parseStrToIntArray(expression.substring(4)).sum();
			case 'min': return parseStrToIntArray(expression.substring(4)).min();
			case 'max': return parseStrToIntArray(expression.substring(4)).max();
			case 'avg': return parseStrToIntArray(expression.substring(4)).avg();
			default : return parseStrToIntArray(expression);
		}
	}

	function isDeclaration(str) {
		return str.substr(0,3) === 'def'
	}

	function getSplittingIndex(str) {
		for (var i = 0; i < str.length; i++) {
			if(str[i] === ' ' || str[i] === '[') return i;
		}
	}

	function getOperationType(str) {
		var sumIndex = str.indexOf('sum');
		var minIndex = str.indexOf('min');
		var maxIndex = str.indexOf('max');
		var avgIndex = str.indexOf('avg');

		if(sumIndex == -1) sumIndex = Number.MAX_VALUE;
		if(minIndex == -1) minIndex = Number.MAX_VALUE;
		if(maxIndex == -1) maxIndex = Number.MAX_VALUE;
		if(avgIndex == -1) avgIndex = Number.MAX_VALUE;

		if(sumIndex > -1 && sumIndex < minIndex && sumIndex < maxIndex && sumIndex < avgIndex){
			return 'sum';
		}
		if (minIndex > -1 && minIndex < sumIndex && minIndex < maxIndex && minIndex < avgIndex) {
			return 'min';
		}
		if (maxIndex > -1 && maxIndex < sumIndex && maxIndex < minIndex && maxIndex < avgIndex) {
			return 'max';
		}
		if (avgIndex > -1 && avgIndex < sumIndex < avgIndex < minIndex && avgIndex < maxIndex) {
			return 'avg';
		}
		return 'none';
	}

	var variables = {};

	for (var i = 0; i < args.length; i++) {
		var line = args[i].removeDuplicateWhitespaces().trim();

		if(isDeclaration(line)){
			line = line.slice(3).trim();
			var splittingIndex = getSplittingIndex(line);
			var variableName = line.substring(0, splittingIndex);
			var expression = line.substr(splittingIndex);
			var result = evaluateExpression(expression);
			variables[variableName] = result;
		} else {
			var res = evaluateExpression(line);
			if(res instanceof Array) return res[0];
			return res;
		}
	}
}