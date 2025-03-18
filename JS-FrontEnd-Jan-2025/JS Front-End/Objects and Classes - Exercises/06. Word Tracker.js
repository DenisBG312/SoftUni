function solve(data) {
    let wordsToTrack = data[0].split(' ');
    let wordCount = {};

    for (let word of wordsToTrack) {
        wordCount[word] = 0;
    }

    for (let i = 1; i < data.length; i++) {
        let word = data[i];
        if (wordCount.hasOwnProperty(word)) {
            wordCount[word]++;
        }
    }

    let sortedWords = Object.entries(wordCount).sort((a, b) => b[1] - a[1]);

    for (let [key, value] of sortedWords) {
        console.log(`${key} - ${value}`);
    }
}
