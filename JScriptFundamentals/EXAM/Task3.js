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
    function isLetter(ch) {
        return (ch.charCodeAt(0) >= 65 && ch.charCodeAt(0) <= 90)
            || (ch.charCodeAt(0) >= 97 && ch.charCodeAt(0) <= 122);
    }

    function isDigit(ch) {
        return ch.charCodeAt(0) >= 48 && ch.charCodeAt(0) <= 57;
    }

    function isString(str) {

    }

    function isBoolean(str) {
        return str === 'true' || str === 'false';
    }

    function isArray(str) {
        return str.indexOf(',') > -1
    }

    function parseArray(str) {
        var arr = str.split(',').clean('');     //IF debug = remove whitespaces/ trim
        return arr;
    }

    function isEscaped(line, index) {
        if (index > 0 && line[index - 1] === '@') {
            return true;
        }
        return false;
    }

    function getOperationType(str) {
        if (str.substr(0, 8) === 'section ') {
            return 'section';
        } else if (str.substr(0, 14) === 'renderSection(') {
            return 'renderSection';
        } else if (str.substr(0, 3) === 'if ') {
            return 'if';
        } else if (str.substr(0, 8) === 'foreach ') {
            return 'foreach';
        }
        return 'variable';
    }

    var getName = function (str) {
        var result = '';
        for (var i = 0; i < str.length && (isLetter(str[i]) || isDigit(str[i])); i++) {
            result += str[i];
        }
        return result
    };

    var variables = {};
    var variablesCount = parseInt(args[0], 10);
    var argumentIndex = 1;

    for (; argumentIndex <= variablesCount; argumentIndex++) {
        var line = args[argumentIndex];
        var splittingIndex = line.indexOf(':');
        var name = line.substring(0, splittingIndex).trim();
        var value = line.substring(splittingIndex + 1).trim();

        if (!variables[name]) {
            if (isArray(value)) {
                value = parseArray(value);
            }
            variables[name] = value;
        }
    }

    var linesCount = parseInt(args[argumentIndex], 10);

    var inSection = false;
    var inTrueConditional = false;
    var inFalseConditional = false;
    var inLoop = false;
    var output = '';

    for (++argumentIndex; argumentIndex < args.length; argumentIndex++) {
        var line = args[argumentIndex];

        for (var k = 0; k < line.length; k++) {
            var symbol = line[k];

            if (inSection) {
                if (symbol === '}') {
                    inSection = false;
                    break;
                }
                if (symbol !== '{') {
                    variables[sectionName] += symbol;
                    continue;
                }
            } else {
                if (symbol === '@' && !isEscaped(line, k)) {
                    var operation = getOperationType(line.substr(k + 1));

                    if (operation === 'section') {
                        k += 9;
                        var sectionName = getName(line.substr(k)).trim();
                        inSection = true;
                        variables[sectionName] = '';
                        k += sectionName.length;
                    } else if (operation === 'renderSection') {
                        k += 16;
                        var sectionName = getName(line.substr(k));
                        output += variables[sectionName];
                        k += sectionName.length + 2;
                    } else if (operation === 'if') {

                    } else if (operation === 'foreach') {

                    } else if (operation === 'variable') {
                        k += 1;
                        var variableName = getName(line.substr(k)).trim();
                        k += variableName.length - 1;
                        output += variables[variableName];
                    }
                } else {
                    output += symbol;
                }
            }
        }

        if (!inSection) {
            output += '\r';
        } else {
            variables[sectionName] += '\r';
        }
    }

    return output;
}

