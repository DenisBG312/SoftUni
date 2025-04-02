document.addEventListener('DOMContentLoaded', solve);

function solve() {
    let encodeBtn = document.querySelector('#encode button');
    encodeBtn.addEventListener('click', encodeMessage);

    let decodeBtn = document.querySelector('#decode button');
    decodeBtn.addEventListener('click', decodeMessage);
    
    function encodeMessage(e) {
        e.preventDefault();
        
        let encodeTextArea = document.querySelector('#encode textarea');
        let decodeTextArea = document.querySelector('#decode textarea');

        let message = encodeTextArea.value;
        let encodedMessage = message
            .split('')
            .map(char => String.fromCharCode(char.charCodeAt(0) + 1))
            .join('');

        decodeTextArea.value = encodedMessage;

        encodeTextArea.value = '';
    }

    function decodeMessage(e) {
        e.preventDefault();

        let decodeTextArea = document.querySelector('#decode textarea');

        let encodedMessage = decodeTextArea.value;
        let decodedMessage = encodedMessage
            .split('')
            .map(char => String.fromCharCode(char.charCodeAt(0) - 1))
            .join('');

        decodeTextArea.value = decodedMessage;
    }
}
