function solve(numOne, numTwo) {
    let firstFactorial = 1;
    let secondFactorial = 1;

    for (let i = 1; i <= numOne; i++) {
        firstFactorial *= i;
    }

    for (let i = 1; i <= numTwo; i++) {
        secondFactorial *= i;
    }

    console.log(`${(firstFactorial / secondFactorial).toFixed(2)}`);
}
