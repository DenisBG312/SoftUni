function solve() {
  let textInput = document.getElementById('text');
  let commandInput = document.getElementById('naming-convention');

  let text = textInput.value.toLocaleLowerCase();
  let tokens = text.split(' ');
  let command = commandInput.value;

  let output = document.getElementById('result');

  if (command != 'Pascal Case' && command != 'Camel Case') {
    output.textContent = 'Error!';

    return;
  }

  let startIndex = command == 'Pascal Case' ? 0 : 1;

  for (let i = startIndex; i < tokens.length; i++) {
    let word = tokens[i];

    word = word[0].toLocaleUpperCase() + word.slice(1);

    tokens[i] = word;
  }

  output.textContent = tokens.join('');
}