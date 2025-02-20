function sum(startNum, endNum) {
    let sum = 0;
    let numbers = '';

    for(let i = startNum; i <= endNum; i++) {
        numbers += i;
        numbers += ' ';
        sum += i; 
    }

    console.log(numbers);
    console.log(`Sum: ${sum}`);
}
