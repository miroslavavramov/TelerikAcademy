function Solve(args) {
    var arr = args.splice(1).map(
        function (element) {
            return parseInt(element, 10);
        }
    );

    var maxSum = -2000000, currMax = 0;

    for (var i = 0; i < arr.length; i++) {
        currMax += arr[i];
        if (currMax > maxSum) {
            maxSum = currMax;
        }
        if (currMax < 0) {
            currMax = 0;
        }
    }
    return maxSum;
}
