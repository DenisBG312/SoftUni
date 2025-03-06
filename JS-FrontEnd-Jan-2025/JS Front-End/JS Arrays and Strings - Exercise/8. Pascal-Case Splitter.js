function solve(text) {
    let pattern = /[A-Z][a-z]*/g;

    let result = text.match(pattern);

    console.log(result.join(', '));
}
