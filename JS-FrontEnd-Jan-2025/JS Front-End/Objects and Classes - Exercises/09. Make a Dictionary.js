function solve(data) {

    let dictionary = {};

    for (let objJson of data) {
        let obj = JSON.parse(objJson);

        let key = Object.keys(obj)[0];
        let value = obj[key];

        dictionary[key] = value;
    }

    let sortedTerms = Object.keys(dictionary).sort();

    for (let term of sortedTerms) {
        console.log(`Term: ${term} => Definition: ${dictionary[term]}`);
    }
}
