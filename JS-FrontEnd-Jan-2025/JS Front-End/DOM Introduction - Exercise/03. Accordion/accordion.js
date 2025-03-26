function toggle() {
    let content = document.getElementById('extra');
    let btn = document.querySelector('.button');

    if (btn.textContent == 'More') {
        content.style.display = 'block';
        btn.textContent = 'Less';
    } else {
        content.style.display = 'none';
        btn.textContent = 'More';
    }
}