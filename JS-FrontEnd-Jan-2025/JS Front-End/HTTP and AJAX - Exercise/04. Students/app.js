document.querySelector('form').addEventListener('submit', onCreate);

onLoad();

async function onLoad() {
    let students = await loadStudents();

    let list = document.querySelector('tbody');
    list.replaceChildren();

    for (let student of students) {
        let row = document.createElement('tr');

        let firstNameCell = document.createElement('td');
        firstNameCell.textContent = student.firstName;
        row.appendChild(firstNameCell);

        let lastNameCell = document.createElement('td');
        lastNameCell.textContent = student.lastName;
        row.appendChild(lastNameCell);

        let facultyNumberCell = document.createElement('td');
        facultyNumberCell.textContent = student.facultyNumber;
        row.appendChild(facultyNumberCell);

        let gradeCell = document.createElement('td');
        gradeCell.textContent = student.grade;
        row.appendChild(gradeCell);

        list.appendChild(row);
    }
}

async function onCreate(e) {
    e.preventDefault();

    let inputs = {
        firstName: document.querySelector('[name="firstName"]'),
        lastName: document.querySelector('[name="lastName"]'),
        facultyNumber: document.querySelector('[name="facultyNumber"]'),
        grade: document.querySelector('[name="grade"]')
    };

    let student = {
        firstName: inputs.firstName.value,
        lastName: inputs.lastName.value,
        facultyNumber: inputs.facultyNumber.value,
        grade: inputs.grade.value
    };

    if (!student.firstName || !student.lastName || !student.facultyNumber || isNaN(student.grade)) {
        return;
    }

    await createStudent(student);

    document.querySelector('form').reset();

    onLoad();
}

async function loadStudents() {
    let res = await fetch('http://localhost:3030/jsonstore/collections/students');
    let data = await res.json();

    return Object.values(data);
}

async function createStudent(student) {

    let options = {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(student)
    };

    await fetch('http://localhost:3030/jsonstore/collections/students', options);
}