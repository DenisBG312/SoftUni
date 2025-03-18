function solve(data) {
    let words = data.toLowerCase().split(' ');
    let wordCounts = {};

    for (let word of words) {
        if (!wordCounts.hasOwnProperty(word)) {
            wordCounts[word] = 1;
        } else {
            wordCounts[word]++;
        }
    }

    let oddOccurences = [];
    
    for (let entry of Object.entries(wordCounts)) {
        let word = entry[0];
        let count = entry[1];

        if (count % 2 != 0) {
            oddOccurences.push(word);
        }
    }

    console.log(oddOccurences.join(' '))

}
