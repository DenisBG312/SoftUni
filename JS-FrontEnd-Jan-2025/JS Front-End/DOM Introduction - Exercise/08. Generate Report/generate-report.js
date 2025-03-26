function solve() {
    let selected = new Map();

    let headers = document.querySelectorAll('thead [type="checkbox"]');

    for (let i = 0; i < headers.length; i++) {
        if (headers[i].checked) {
            selected.set(i, headers[i].name);
        }
    }

    let rows = document.querySelectorAll('tbody tr');

    let result = [];

    for (let row of rows) {
        let record = {};
        for (let i = 0; i < row.children.length; i++) {
            if (selected.has(i)){
                let propName = selected.get(i);
                let col = row.children[i];

                record[propName] = col.textContent;
            }
        }

        result.push(record);
    }

    let output = document.getElementById('output');
    output.value = JSON.stringify(result);
}