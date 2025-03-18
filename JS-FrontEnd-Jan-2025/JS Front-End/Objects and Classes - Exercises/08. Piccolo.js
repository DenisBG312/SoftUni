function solve(commands) {
    let parking = new Set();

    for (let row of commands) {
        let [command, id] = row.split(', ');

        if (command == 'IN') {
            parking.add(id)
        } else if (command == 'OUT') {
            parking.delete(id);
        }
    }

    if (parking.size) {
        console.log([...parking].sort().join('\n'));
    } else {
        console.log('Parking Lot is Empty');
    }
}
