function solve(initial, orders) {
    let stock = new Map();

    for (let i = 0; i < initial.length; i += 2) {
        let key = initial[i];
        let value = Number(initial[i + 1]);

        stock.set(key, value);
    }

    for (let i = 0; i < orders.length; i += 2) {
        let key = orders[i];
        let value = Number(orders[i + 1]);

        if (!stock.has(key)) {
            stock.set(key, 0);
        }
        
        let current = stock.get(key);
        stock.set(key, current + value);
    }

    for (let [key, value] of stock) {
        console.log(`${key} -> ${value}`);
    }
}
