function subtract() {
    let a = Number(document.getElementById('firstNumber').value);
    let b = Number(document.getElementById('secondNumber').value);

    let result = document.getElementById('result');
    result.textContent = a - b;
}