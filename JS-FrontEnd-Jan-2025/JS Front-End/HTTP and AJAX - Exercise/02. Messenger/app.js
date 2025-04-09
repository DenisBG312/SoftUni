function attachEvents() {
    document.getElementById('submit').addEventListener('click', onPost);
    document.getElementById('refresh').addEventListener('click', onRefresh);
}

attachEvents();

async function onPost() {
    let authorInput = document.querySelector('[name="author"]');
    let contentInput = document.querySelector('[name="content"]');

    let author = authorInput.value;
    let content = contentInput.value;

    await postMessage(author, content);

    authorInput.value = '';
    contentInput.value = '';
}

async function onRefresh() {
    let messages = await loadMessages();

    let output = messages.map(m => `${m.author}: ${m.content}`);

    document.getElementById('messages').value = output.join('\n');
}

async function loadMessages() {
    let res = await fetch('http://localhost:3030/jsonstore/messenger');
    let data = await res.json();

    return Object.values(data);
}

async function postMessage(author, content) {
    let message = { author, content };
    let options = {
        method: 'post',
        header: { 'Content-Type': 'application/json' },
        body: JSON.stringify(message)
    };

    await fetch('http://localhost:3030/jsonstore/messenger', options);
}