window.onload = solution;

async function solution() {
    let accordions = await getAccordions();
    let mainSection = document.getElementById('main');

    mainSection.replaceChildren();

    for (let accordion of accordions) {
        let accordionDiv = document.createElement('div');
        accordionDiv.className = 'accordion';

        let headDiv = document.createElement('div');
        headDiv.className = 'head';

        let headSpan = document.createElement('span');
        headSpan.textContent = accordion.title;

        let headButton = document.createElement('button');
        headButton.className = 'button';
        headButton.id = accordion._id;
        headButton.textContent = 'More';

        let extraDiv = document.createElement('div');
        extraDiv.className = 'extra';
        extraDiv.style.display = 'none';

        headButton.addEventListener('click', () => toggleContentVisibility(accordion, extraDiv, headButton));

        headDiv.appendChild(headSpan);
        headDiv.appendChild(headButton);

        accordionDiv.appendChild(headDiv);
        accordionDiv.appendChild(extraDiv);

        mainSection.appendChild(accordionDiv);
    }  
}

async function toggleContentVisibility(accordion, extraDiv, headButton) {
    if (extraDiv.style.display == 'none') {
        let content = await getAccordionById(accordion._id);
        let extraP = document.createElement('p');
        extraP.textContent = content.content;

        extraDiv.appendChild(extraP);
        extraDiv.style.display = 'block';
        headButton.textContent = 'Less';
    } else {
        extraDiv.style.display = 'none';
        headButton.textContent = 'More';
    }
}



async function getAccordions() {
    let res = await fetch('http://localhost:3030/jsonstore/advanced/articles/list');
    let data = await res.json();

    return Object.values(data);
}

async function getAccordionById(accordionId) {
    let res = await fetch('http://localhost:3030/jsonstore/advanced/articles/details/' + accordionId);
    let data = await res.json();

    return data;
}