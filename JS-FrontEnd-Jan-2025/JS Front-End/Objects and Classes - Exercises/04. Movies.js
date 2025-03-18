function solve(data) {
    let movies = [];

    for (let command of data) {
        let tokens = command.split(' ');

        if (tokens[0] == 'addMovie') {

            let movieName = tokens.slice(1).join(' ');

            let movie = {
                name: movieName
            };

            movies.push(movie);

        } else if (tokens.includes('directedBy')) {
            let [movieName, director] = command.split(' directedBy ');
            let movie = movies.find(m => m.name == movieName);

            if (movie) {
                movie.director = director;
            };
        } else if (tokens.includes('onDate')) {
            let [movieName, date] = command.split(' onDate ');
            let movie = movies.find(m => m.name == movieName);

            if (movie) {
                movie.date = date;
            };
        };
    }

    let completeMovies = movies.filter(movie => movie.name && movie.director && movie.date);

    completeMovies.forEach(movie => console.log(JSON.stringify(movie)));

}
