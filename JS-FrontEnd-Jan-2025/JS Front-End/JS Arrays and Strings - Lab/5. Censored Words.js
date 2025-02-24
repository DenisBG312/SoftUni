function censor(text, word) {
    let censored = text.replaceAll(word, '*'.repeat(word.length));

    console.log(censored);
}
