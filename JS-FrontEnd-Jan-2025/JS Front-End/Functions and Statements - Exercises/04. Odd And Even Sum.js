function solve(num) {
    let numAsString = num.toString();

    let oddSum = 0;
    let evenSum = 0;

    for (let digit of numAsString) {
        digit = Number(digit);

        if (digit % 2 == 0) {
            evenSum += digit;
        } else {
            oddSum += digit;
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}
