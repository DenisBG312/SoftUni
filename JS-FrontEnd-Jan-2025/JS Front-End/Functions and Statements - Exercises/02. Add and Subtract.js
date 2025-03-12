function solve(a, b, c) {

    console.log(subtract(sum(a,b), c));
    
    function sum(x, y) {
        return x + y;
    }

    function subtract(p, q) {
        return p - q;
    }
}
