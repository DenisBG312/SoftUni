function solve(towns) {

    for (let item of towns) {
        let [town, latitude, longitude] = item.split(' | ');
        latitude = Number(latitude).toFixed(2);
        longitude = Number(longitude).toFixed(2);

        let current = {
            town,
            latitude,
            longitude
        };

        console.log(current);
    }
}
