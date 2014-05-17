function solve (args) {
	var n = args[0];
	var sequencesFound = 1;

	for (var i = 0; i < n; i++) {
		if(parseInt(args[i+1]) > parseInt(args[i+2])){
			sequencesFound++;
		}
	}
	return sequencesFound;
}
