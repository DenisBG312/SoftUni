function solve(peopleCount, groupType, dayOfWeek) {

    let singlePrice = 0;

    if (groupType == 'Students') {
        if (dayOfWeek == 'Friday') {
            singlePrice = 8.45;
        } else if (dayOfWeek == 'Saturday') {
            singlePrice = 9.8;
        } else if (dayOfWeek == 'Sunday') {
            singlePrice = 10.46;
        }
    } else if (groupType == 'Business') {
        if (dayOfWeek == 'Friday') {
            singlePrice = 10.9;
        } else if (dayOfWeek == 'Saturday') {
            singlePrice = 15.6;
        } else if (dayOfWeek == 'Sunday') {
            singlePrice = 16;
        }
    } else if (groupType == 'Regular') {
        if (dayOfWeek == 'Friday') {
            singlePrice = 15;
        } else if (dayOfWeek == 'Saturday') {
            singlePrice = 20;
        } else if (dayOfWeek == 'Sunday') {
            singlePrice = 22.5;
        }
    }

    let totalPrice = peopleCount * singlePrice;

    if (groupType == 'Students' && peopleCount >= 30) {
        totalPrice -= totalPrice * 0.15;
    } else if (groupType == 'Business' && peopleCount >= 100) {
        totalPrice -= singlePrice * 10;
    } else if (groupType == 'Regular' && peopleCount >= 10 && peopleCount <= 20) {
        totalPrice -= totalPrice * 0.05;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}
