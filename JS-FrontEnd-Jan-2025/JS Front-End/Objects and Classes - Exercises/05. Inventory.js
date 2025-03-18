function solve(data) {
    let objects = [];

    for (let heroInfo of data) {
        let [name, level, items] = heroInfo.split(' / '); 
        level = Number(level);

        let hero = {
            name,
            level,
            items
        };

        objects.push(hero);
    }

    objects.sort(compareLevels);

    for (let hero of objects) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    }

    function compareLevels(a, b) {
        return a.level - b.level;
    }
}
