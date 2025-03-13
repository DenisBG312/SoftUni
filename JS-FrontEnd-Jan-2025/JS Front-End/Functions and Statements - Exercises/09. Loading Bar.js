function visualizeBar(num) {
    let percentages = '%'.repeat(num / 10);
    let dots = '.'.repeat(10 - num / 10);
    if (num == 100) {
        console.log('100% Complete!');
        console.log('[%%%%%%%%%%]');
    } else {
        console.log(`${num}% [${percentages}${dots}]`);
        console.log(`Still loading...`);
    }
}
