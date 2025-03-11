function solve(nums) {
    for (let num of nums) {
        let numAsString = num.toString();
        let isPalendrome = true;

        for (let i = 0; i < (numAsString.length - 1) / 2; i++) {
            if (numAsString[i] != numAsString[numAsString.length - i - 1]) {
                isPalendrome = false;
                break;
            }
        }

        console.log(isPalendrome);
    }
}
