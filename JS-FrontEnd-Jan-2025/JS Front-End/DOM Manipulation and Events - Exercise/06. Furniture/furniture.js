document.addEventListener('DOMContentLoaded', solve);

  function solve() {
    let [generateBtn, buyBtn] = Array.from(document.querySelectorAll('[type="submit"]'));
    generateBtn.addEventListener('click', onGenerate);
    buyBtn.addEventListener('click', onBuy)

    let table = document.querySelector('tbody');

    function onGenerate(e) {
      e.preventDefault();

      let data = JSON.parse(document.querySelector('#input textarea').value);

      data.map(createRow).forEach(c => table.appendChild(c));
    }

    function onBuy(e) {
      e.preventDefault();

      let selected = [];
      let total = 0;
      let decFactor = 0;

      for (let row of table.children) {
        if (row.querySelector('input').checked) {

          let [nameP, priceP, decP] = Array.from(row.querySelectorAll('p'));

          selected.push(nameP.textContent);
              total += Number(priceP.textContent);
              decFactor += Number(decP.textContent);
        }
      }

      let result = [
        `Bought furniture: ${selected.join(', ')}`,
        `Total price: ${total}`,
        `Average decoration factor: ${decFactor / selected.length}`
      ];

      document.querySelector('#shop textarea').value = result.join('\n'); 
    }

    function createRow(entry) {
      let row = document.createElement('tr');

      let imgCol = document.createElement('td');
      let img = document.createElement('img');
      img.src = entry.img
      imgCol.appendChild(img);
      row.appendChild(imgCol);

      row.appendChild(createCol(entry.name));
      row.appendChild(createCol(entry.price));
      row.appendChild(createCol(entry.decFactor));

      let buyCol = document.createElement('td');
      let buyCheck = document.createElement('input');
      buyCheck.type = 'checkbox';
      buyCol.appendChild(buyCheck);
      row.appendChild(buyCol);

      return row;
    }

    window.createRow = createRow;

    function createCol(content) {
      let col = document.createElement('td');
      let p = document.createElement('p');
      p.textContent = content;
      col.appendChild(p);

      return col;
    }
  }