function solve(words, template) {
    let wordsArr = words.split(', ');

    let tokens = template.split(' ');

    for (let i = 0; i < tokens.length; i++) {
        for (let word of wordsArr) {
            let stars = '*'.repeat(word.length);
            if (tokens[i] == stars) {
                tokens[i] = word;
                break;
            }
        }
    }

    console.log(tokens.join(' '))
}
