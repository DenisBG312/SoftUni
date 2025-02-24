function solve(input) {

    let evenNumSum = 0;
    let oddNumSum = 0;
    
    for(let i = 0; i < input.length; i++) {
        if (input[i] % 2 == 0) {
            evenNumSum += input[i];
        }
        else {
            oddNumSum += input[i];
        }
    }
    
    console.log(evenNumSum - oddNumSum);
}

solve([2,4,6,8,10])

