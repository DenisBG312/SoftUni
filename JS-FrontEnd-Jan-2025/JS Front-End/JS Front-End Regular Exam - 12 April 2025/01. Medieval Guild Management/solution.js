function solve(input) {
    let guildMembers = {};

    let n = Number(input.shift());

    for (let i = 0; i < n; i++) {
        let [name, role, skillsString] = input.shift().split(' ');
        
        let skills = skillsString.split(',');

        guildMembers[name] = {
            role,
            skills
        };
    }

    while (input[0] != 'End') {
        let [command, name, arg1, arg2] = input.shift().split(' / ');

        if (command == 'Perform') {
            let role = arg1;
            let skill = arg2;

            if (guildMembers[name].role == role && guildMembers[name].skills.includes(skill)) {
                console.log(`${name} has successfully performed the skill: ${skill}!`);
            } else {
                console.log(`${name} cannot perform the skill: ${skill}.`);
            }

        } else if (command == 'Reassign') {
            let newRole = arg1;

            guildMembers[name].role = newRole;
            console.log(`${name} has been reassigned to: ${newRole}`);


        } else if (command == 'Learn Skill') {
            let newSkill = arg1;

            if (guildMembers[name].skills.includes(newSkill)) {
                console.log(`${name} already knows the skill: ${newSkill}.`);
            } else {
                guildMembers[name].skills.push(newSkill);
                console.log(`${name} has learned a new skill: ${newSkill}.`);
            }
        }
    }

    for (let name in guildMembers) {
        let member = guildMembers[name];
        let sortedSkills = member.skills.sort((a, b) => a.localeCompare(b));
        console.log(`Guild Member: ${name}, Role: ${member.role}, Skills: ${sortedSkills.join(', ')}`);
    }
}
