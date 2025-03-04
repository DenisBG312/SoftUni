function solve(arr, rotations) {
    let result = [];
    let startIndex = rotations % arr.length;

    for (let i = startIndex; i < arr.length; i++) {
        result.push(arr[i]);
    }

    for (let i = 0; i < startIndex; i++) {
        result.push(arr[i]);
    }


    console.log(result.join(' '));
}
