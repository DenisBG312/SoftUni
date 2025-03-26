function solve() {
   let rows = document.querySelectorAll('.container tbody tr');
   let input = document.getElementById('searchField');

   let pattern = input.value;

   if (!pattern) {
      return;
   }

   for (let row of rows) {
      if (row.textContent.includes(pattern)) {
         row.classList.add('select');
      } else {
         row.classList.remove('select');
      }
   }

   input.value = '';
}