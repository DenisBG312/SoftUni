function solve(word, text) {
    if (text.toLowerCase().split(' ').includes(word.toLowerCase())) {
        console.log(word);
    } else {
        console.log(`${word} not found!`);
    }
}
