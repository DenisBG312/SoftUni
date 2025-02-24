function solve(text, searchWord) {
    let count = 0;

    let words = text.split(' ');

    for(let word of words) {
        if (word == searchWord) {
            count++;
        }
    }

    console.log(count);
}
