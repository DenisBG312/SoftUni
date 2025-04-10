async function lockedProfile() {
    let profiles = await getAllProfiles();
    let main = document.getElementById('main');
    main.replaceChildren();

    let counter = 1;

    for (let profile of profiles) {
        let profileDiv = document.createElement('div');
        profileDiv.className = 'profile'; 

        let img = document.createElement('img');
        img.src = './iconProfile2.png';
        img.className = 'userIcon';

        let lockLabel = document.createElement('label');
        lockLabel.textContent = 'Lock';

        let inputRadio = document.createElement('input');
        inputRadio.type = 'radio';
        inputRadio.name = `user${counter}Locked`;
        inputRadio.value = 'lock';
        inputRadio.checked = true;

        let unlockLabel = document.createElement('label');
        unlockLabel.textContent = 'Unlock';

        let unlockRadio = document.createElement('input');
        unlockRadio.type = 'radio';
        unlockRadio.name = `user${counter}Locked`;
        unlockRadio.value = 'unlock';

        let br = document.createElement('br');
        let hr1 = document.createElement('hr');

        let usernameLabel = document.createElement('label');
        usernameLabel.textContent = 'Username';

        let usernameInput = document.createElement('input');
        usernameInput.type = 'text';
        usernameInput.name = `user${counter}Username`;
        usernameInput.value = profile.username;
        usernameInput.disabled = true;
        usernameInput.readOnly = true;

        let hiddenDiv = document.createElement('div');
        hiddenDiv.id = `user${counter}HiddenFields`;
        hiddenDiv.style.display = 'none';

        let hr2 = document.createElement('hr');

        let emailLabel = document.createElement('label');
        emailLabel.textContent = 'Email:';

        let emailInput = document.createElement('input');
        emailInput.type = 'email';
        emailInput.name = `user${counter}Email`;
        emailInput.value = profile.email;
        emailInput.disabled = true;
        emailInput.readOnly = true;

        let ageLabel = document.createElement('label');
        ageLabel.textContent = 'Age:';

        let ageInput = document.createElement('input');
        ageInput.type = 'number';
        ageInput.name = `user${counter}Age`;
        ageInput.value = profile.age;
        ageInput.disabled = true;
        ageInput.readOnly = true;

        hiddenDiv.appendChild(hr2);
        hiddenDiv.appendChild(emailLabel);
        hiddenDiv.appendChild(emailInput);
        hiddenDiv.appendChild(ageLabel);
        hiddenDiv.appendChild(ageInput);

        let button = document.createElement('button');
        button.textContent = 'Show more';

        button.addEventListener('click', () => toggleProfile(unlockRadio, hiddenDiv, button));

        profileDiv.appendChild(img);
        profileDiv.appendChild(lockLabel);
        profileDiv.appendChild(inputRadio);
        profileDiv.appendChild(unlockLabel);
        profileDiv.appendChild(unlockRadio);
        profileDiv.appendChild(br);
        profileDiv.appendChild(hr1);
        profileDiv.appendChild(usernameLabel);
        profileDiv.appendChild(usernameInput);
        profileDiv.appendChild(hiddenDiv);
        profileDiv.appendChild(button);

        main.appendChild(profileDiv);
        counter++;
    }
}

function toggleProfile(unlockRadio, hiddenDiv, button) {
    if (!unlockRadio) {
        return;
    }

    let isHidden = hiddenDiv.style.display == 'none';

    hiddenDiv.style.display = isHidden ? 'block' : 'none';
    button.textContent = isHidden ? 'Hide it' : 'Show more';
}

async function getAllProfiles() {
    let res = await fetch('http://localhost:3030/jsonstore/advanced/profiles');
    let data = await res.json();

    return Object.values(data);
}