function solve(a, b) {
    let code1 = a.charCodeAt(0);
    let code2 = b.charCodeAt(0);

    let result = [];

    for (let i = Math.min(code1, code2) + 1; i < Math.max(code1, code2); i++) {
        result.push(String.fromCharCode(i));
    }

    console.log(result.join(' '));
}
