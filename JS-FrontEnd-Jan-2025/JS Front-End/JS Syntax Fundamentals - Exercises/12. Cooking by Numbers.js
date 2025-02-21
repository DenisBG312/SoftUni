function solve(number, p1, p2, p3, p4, p5) {
    let numberAsNum = Number(number);

    for(let i = 1; i <= 5; i++) {
        let command = arguments[i];

        if (command == 'chop') {
            numberAsNum /= 2;
        } else if (command == 'dice') {
            numberAsNum = Math.sqrt(numberAsNum);
        } else if (command == 'spice') {
            numberAsNum += 1;
        } else if (command == 'bake') {
            numberAsNum *= 3;
        } else {
            numberAsNum -= numberAsNum * 0.2;
        }

        console.log(numberAsNum);
    }
}
