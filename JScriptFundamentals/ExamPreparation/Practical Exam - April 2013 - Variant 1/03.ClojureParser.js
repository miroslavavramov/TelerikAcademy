function Solve(args) {
	function isNumber(n) {
		return !isNaN(parseInt(n)) && isFinite(n);
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

	Array.prototype.product = function () {
		var prod = this[0];
		for (var i = 1; i < this.length; i++) {
			prod *= this[i];
		}
		return prod;
	};

	Array.prototype.subtraction = function () {
		var sum = this[0];
		for (var i = 1; i < this.length; i++) {
			sum -= this[i];
		}
		return sum;
	};

	Array.prototype.division = function () {
		var prod = this[0];
		for (var i = 1; i < this.length; i++) {
			if (this[i] !== 0) {
				prod = Math.floor(prod / this[i]);
			} else {
				return 'pesho';
			}
		}
		return prod;
	};

	function parseExpression(expression) {
		var expressionLiterals = expression.split(' ').clean('');
		var values = [];

		for (var i = 1; i < expressionLiterals.length; i++) {
			var literal = expressionLiterals[i];

			if (isNumber(literal)) {
				values.push(parseInt(literal))
			} else {
				values.push(parseInt(variables[literal]));
			}
		}

		switch (expressionLiterals[0]) {
			case '+':return values.sum();
			case '-':return values.subtraction();
			case '*':return values.product();
			case '/':return values.division();
		}
	}

	var variables = {};

	for (var i = 0; i < args.length; i++) {
		var line = args[i].replace(/\s{2,}/g, ' ').trim();
		line = line.substr(1, line.length - 2);     //remove parent brackets

		var isDeclaration = line.substr(0, 3) === 'def';

		if (isDeclaration) {
			var variableName = line.substring(3, line.indexOf(' ', 4)).trim();
			var containsExpression = line.indexOf('(') > 0;

			if (containsExpression) {
				var expression = line.substring(line.indexOf('(') + 1, line.indexOf(')'));
				var val = parseExpression(expression);
				if (val === 'pesho') {
					return 'Division by zero! At Line:' + (i + 1);
				}
				variables[variableName] = val;
			} else {
				var tokens = line.split(' ').clean('');
				var val = tokens[tokens.length - 1].trim();
				if(isNumber(val)){
					variables[variableName] = parseInt(val);
				} else {
					variables[variableName] = variables[val];
				}
			}
		} else {
			var val = parseExpression(line);
			if (val === 'pesho') {
				return 'Division by zero! At Line:' + (i + 1);
			}
			return val;
		}
	}
}
