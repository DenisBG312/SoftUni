function solve() {

    let firstNameInput = document.getElementById('first_name');
    let lastNameInput = document.getElementById('last_name');
    let phoneInput = document.getElementById('phone');
    let addButton = document.getElementById('add_btn');

    let pendingList = document.getElementById('pending_contact_list');
    let contactList = document.getElementById('contact_list');

    addButton.addEventListener('click', onAdd);

    function onAdd(e) {
        e.preventDefault();

        let firstName = document.getElementById('first_name').value;
        let lastName = document.getElementById('last_name').value;
        let phone = document.getElementById('phone').value;

        if (!firstName || !lastName || !phone) {
            return;
        }

        let li = document.createElement('li');
        li.className = 'contact';

        let nameSpan = document.createElement('span');
        nameSpan.className = 'names';
        nameSpan.textContent = firstName + ' ' + lastName;

        let phoneSpan = document.createElement('span');
        phoneSpan.className = 'phone_number';
        phoneSpan.textContent = phone;

        let editBtn = document.createElement('button');
        editBtn.className = 'edit_btn';
        editBtn.textContent = 'Edit';
        editBtn.addEventListener('click', () => onEdit(li, firstName, lastName, phone));

        let verifyBtn = document.createElement('button');
        verifyBtn.className = 'verify_btn';
        verifyBtn.textContent = 'Verify';
        verifyBtn.addEventListener('click', () => onVerify(li, nameSpan, phoneSpan));

        li.appendChild(nameSpan);
        li.appendChild(phoneSpan);
        li.appendChild(editBtn);
        li.appendChild(verifyBtn);

        pendingList.appendChild(li);


        document.getElementById('first_name').value = '';
        document.getElementById('last_name').value = '';
        document.getElementById('phone').value = '';
    }

    function onEdit(li, firstName, lastName, phone) {
        firstNameInput.value = firstName;
        lastNameInput.value = lastName;
        phoneInput.value = phone;
        li.remove();
    }

    function onVerify(li, nameSpan, phoneSpan) {
        pendingList.removeChild(li);

        let verifiedLi = document.createElement('li');
        verifiedLi.className = 'verified_contact';

        let verifiedName = document.createElement('span');
        verifiedName.className = 'names';
        verifiedName.textContent = nameSpan.textContent;

        let verifiedPhone = document.createElement('span');
        verifiedPhone.className = 'phone_number';
        verifiedPhone.textContent = phoneSpan.textContent;

        let deleteBtn = document.createElement('button');
        deleteBtn.className = 'delete_btn';
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', () => onDelete(verifiedLi));

        verifiedLi.appendChild(verifiedName);
        verifiedLi.appendChild(verifiedPhone);
        verifiedLi.appendChild(deleteBtn);

        contactList.appendChild(verifiedLi);
    }

    function onDelete(verifiedLi) {
        contactList.removeChild(verifiedLi);
    }
};
