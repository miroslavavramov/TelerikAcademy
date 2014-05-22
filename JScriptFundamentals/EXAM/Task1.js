function solve(args) {
    var target = parseInt(args[0], 10);
    var count = 0;

    for (var a = 0; a <= target; a += 10) {
        for (var b = 0; b <= target; b += 4) {
            for (var c = 0; c <= target; c += 3) {
                if (a + b + c === target) {
                    count++;
                }
            }
        }
    }

    return count;
}