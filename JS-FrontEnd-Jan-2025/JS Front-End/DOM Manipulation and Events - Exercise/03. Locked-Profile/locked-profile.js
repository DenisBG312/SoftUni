document.addEventListener('DOMContentLoaded', solve);

function solve() {
    
    
    let buttons = Array.from(document.querySelectorAll('button'))

    for (let button of buttons) {
        button.addEventListener('click', toggleText);
    }

    function toggleText(e) {
        let profile = e.target.parentElement;

        let isLocked = profile.querySelector('[type="radio"]').checked;

        if (isLocked) {
            return;
        }

        let info = profile.querySelector('.hidden-fields');

        if (info.style.display == 'block') {
            info.style.display = 'none'
            e.target.textContent = 'Show less';
        } else {
            info.style.display = 'block'
            e.target.textContent = 'Show less';
        }
    }
}