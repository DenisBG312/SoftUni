function validatePassword(passowrd) {
    
let isValid = true;

    if (passowrd.length < 6 || passowrd.length > 10) {
        console.log('Password must be between 6 and 10 characters');
        isValid = false;
    } 
    
    if (!passowrd.match(/^[A-Za-z0-9]*$/)) {
        console.log('Password must consist only of letters and digits');
        isValid = false;
    } 
    
    if (!passowrd.match(/\d.*\d/)) {
        console.log('Password must have at least 2 digits');
        isValid = false;
    } 
    
    if (isValid) {
        console.log('Password is valid');
    }
}
