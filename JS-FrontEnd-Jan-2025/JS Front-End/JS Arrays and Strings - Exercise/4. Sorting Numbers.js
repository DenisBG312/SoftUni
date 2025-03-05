function solve(arr) {
    arr.sort((a, b) => a - b);

    let result = [];

    while (arr.length) {
        if (result.length % 2 == 0) {
            result.push(arr.shift());
        } else {
            result.push(arr.pop());
        }
    }

    return result;
}
