function solve(text) {
    let pattern = /^#([A-Za-z]+)$/;

    let words = text.split(' ');

    for (let word of words) {
        const match = word.match(pattern);
        if (match) {
            console.log(match[1]);
        }
    }
}
