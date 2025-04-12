let loadBtn = document.getElementById('load-history');
let addBtn = document.getElementById('add-reservation');
let editBtn = document.getElementById('edit-reservation');

let inputNames = document.getElementById('names');
let inputDays = document.getElementById('days');
let inputDate = document.getElementById('date');

let listContainer = document.getElementById('list');
let currentId = null;

loadBtn.addEventListener('click', onLoad);
addBtn.addEventListener('click', onAdd);
editBtn.addEventListener('click', onEdit);

async function onLoad() {
    let reservations = await getReservations();

    listContainer.innerHTML = '';
    addBtn.disabled = false;
    editBtn.disabled = true;

    for (let res of reservations) {
        let div = document.createElement('div');
        div.className = 'container';

        let h2 = document.createElement('h2');
        h2.textContent = res.names;

        let h3Date = document.createElement('h3');
        h3Date.textContent = res.date;

        let h3Days = document.createElement('h3');
        h3Days.id = 'reservation_days';
        h3Days.textContent = res.days;

        let buttonsDiv = document.createElement('div');
        buttonsDiv.className = 'buttons-container';

        let changeBtn = document.createElement('button');
        changeBtn.className = 'change-btn';
        changeBtn.textContent = 'Change';
        changeBtn.addEventListener('click', () => onChangeReservation(res, div));

        let deleteBtn = document.createElement('button');
        deleteBtn.className = 'delete-btn';
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', () => onDeleteReservation(res._id));

        buttonsDiv.appendChild(changeBtn);
        buttonsDiv.appendChild(deleteBtn);

        div.appendChild(h2);
        div.appendChild(h3Date);
        div.appendChild(h3Days);
        div.appendChild(buttonsDiv);

        listContainer.appendChild(div);
    }
}

function onChangeReservation(reservation, element) {
    inputNames.value = reservation.names;
    inputDays.value = reservation.days;
    inputDate.value = reservation.date;

    currentId = reservation._id;

    editBtn.disabled = false;
    addBtn.disabled = true;

    element.remove();
}

async function onAdd() {
    let names = inputNames.value;
    let days = inputDays.value;
    let date = inputDate.value;

    if (names && days && date) {
        await addReservation(names, days, date);
        clearInputs();
        await onLoad();
    }
}

async function onEdit() {
    let names = inputNames.value;
    let days = inputDays.value;
    let date = inputDate.value;

    if (names && days && date && currentId) {
        await editReservation(currentId, names, days, date);
        clearInputs();
        await onLoad();

        addBtn.disabled = false;
        editBtn.disabled = true;
        currentId = null;
    }
}

async function onDeleteReservation(id) {
    await deleteReservation(id);
    await onLoad();
}


async function getReservations() {
    let res = await fetch('http://localhost:3030/jsonstore/reservations');
    let data = await res.json();

    return Object.values(data);
}

async function addReservation(names, days, date) {
    let reservation = {
        names,
        days,
        date
    };

    let options = {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(reservation)
    };

    await fetch('http://localhost:3030/jsonstore/reservations', options);
}

async function editReservation(_id, names, days, date) {
    let reservation = {
        names,
        days,
        date,
        _id
    };

    let options = {
        method: 'put',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(reservation)
    };

    await fetch('http://localhost:3030/jsonstore/reservations/' + _id, options);
}

async function deleteReservation(_id) {
    let options = {
        method: 'delete'
    };

    await fetch('http://localhost:3030/jsonstore/reservations/' + _id, options);
}

function clearInputs() {
    inputNames.value = '';
    inputDays.value = '';
    inputDate.value = '';
}