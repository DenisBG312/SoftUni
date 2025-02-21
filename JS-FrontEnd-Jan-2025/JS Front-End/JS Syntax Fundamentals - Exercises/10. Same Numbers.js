function solve(number) {
  let areSame = true;
  let sum = 0;
  let asString = number.toString();

  for(let i = 0; i < asString.length - 1; i++) {
    if(asString[i] !== asString[i + 1]) {
      areSame = false;
    }
  }
  
  for(let i = 0; i < asString.length; i++) {
    sum += Number(asString[i]);
  }

  console.log(areSame);
  console.log(sum);
}
