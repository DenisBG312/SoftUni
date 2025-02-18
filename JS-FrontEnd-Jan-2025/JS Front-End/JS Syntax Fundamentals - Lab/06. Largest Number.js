function solve(numOne, numTwo, numThree) {
    let biggestNum;
    if (numOne > numTwo && numOne > numThree) {
        biggestNum = numOne;
    }
    else if (numTwo > numOne && numTwo > numThree) {
        biggestNum = numTwo;
    }
    else {
        biggestNum = numThree;
    }

    console.log(`The largest number is ${biggestNum}.`);
}
