function calculate(fruit, weightGr, priceKg) {
    let weightKg = weightGr / 1000
    let totalPrice = priceKg * weightKg;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weightKg.toFixed(2)} kilograms ${fruit}.`)
}
