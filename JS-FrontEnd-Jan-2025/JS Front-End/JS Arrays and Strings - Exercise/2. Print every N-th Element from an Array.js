function solve(strArr, step) {
    let array = [];

    for (let i = 0; i < strArr.length; i+= step) {
        array.push(strArr[i]);
    }

    return array;
}
