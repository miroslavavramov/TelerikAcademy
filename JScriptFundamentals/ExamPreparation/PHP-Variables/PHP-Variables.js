function Solve(args) {
    function isEscaped(str, index) {
        var res = index > 0 && str[index - 1] === '\\';
        return res;
    }

    function isLetter(ch) {
        return (ch.charCodeAt(0) >= 65 && ch.charCodeAt(0) <= 90)
            || (ch.charCodeAt(0) >= 97 && ch.charCodeAt(0) <= 122);
    }

    function isDigit(ch) {
        return ch.charCodeAt(0) >= 48 && ch.charCodeAt(0) <= 57;
    }

    var phpVariables = {};
    var inMultiLineComment = false;
    var inSingleLineComment = false;
    var inString = false;
    var stringWrappingSymbol = '';

    for (var i = 0; i < args.length; i++) {
        var line = args[i];
        inSingleLineComment = false;
        inString = false;

        for (var k = 0; k < line.length; k++) {
            var symbol = line[k];

            if ((symbol === '\'' || symbol === "\"") && !isEscaped(line, k)) {
                if (!inString) {
                    inString = true;
                    stringWrappingSymbol = symbol;
                } else {
                    if (symbol === stringWrappingSymbol) {
                        inString = false;
                    }
                }
            }
            if (!inString && !inSingleLineComment && symbol === '/') {
                if (k < line.length - 1 && line[k + 1] === '*') {
                    inMultiLineComment = true;
                    k++;
                }
            }
            if (!inString && !inMultiLineComment && symbol === '#') {
                inSingleLineComment = true;
            }
            if (!inString && !inMultiLineComment && symbol === '/') {
                if (k < line.length - 1 && line[k + 1] === '/') {
                    inSingleLineComment = true;
                    k++;
                }
            }
            if (inMultiLineComment && symbol === '*') {
                if (k < line.length - 1 && line[k + 1] === '/') {
                    inMultiLineComment = false;
                    k++;
                }
            }

            if (inSingleLineComment) {
                break;  //continue?
            }
            if (inMultiLineComment) {
                continue;
            }

            if (symbol === '$' && !isEscaped(line, k)) {
                var variableName = '';
                var index = k + 1;
                var variableSymbol = line[index];

                while (true) {
                    if (isLetter(variableSymbol) || isDigit(variableSymbol) || variableSymbol === '_') {
                        variableName += variableSymbol;
                        index += 1;
                        variableSymbol = line[index];
                    } else {
                        break;
                    }
                }

                if (!phpVariables[variableName]) {
                    phpVariables[variableName] = true;
                }
            }
        }
    }

    var outputArr = [];

    for (var v in phpVariables) {
        outputArr.push(v);
    }

    outputArr.sort();
    var output = outputArr.length + '\r';

    for (var i = 0; i < outputArr.length; i++) {
        output += outputArr[i] + '\r';

    }
    return output;
}
