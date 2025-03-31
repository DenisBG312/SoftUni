document.addEventListener('DOMContentLoaded', solve);

function solve() {
    

    document.getElementById('daysBtn').addEventListener('click', convertDays);
    document.getElementById('hoursBtn').addEventListener('click', convertHours);
    document.getElementById('minutesBtn').addEventListener('click', convertMinutes);
    document.getElementById('secondsBtn').addEventListener('click', convertSeconds);

    function convertDays(e) {
        e.preventDefault();
        let days = Number(document.getElementById('days-input').value);
        updateFields(days * 86400);
    }

    function convertHours(e) {
        e.preventDefault();
        let hours = Number(document.getElementById('hours-input').value);
        updateFields(hours * 3600);
    }

    function convertMinutes(e) {
        e.preventDefault();
        let minutes = Number(document.getElementById('minutes-input').value);
        updateFields(minutes * 60);
    }

    function convertSeconds(e) {
        e.preventDefault();
        let seconds = Number(document.getElementById('seconds-input').value);
        updateFields(seconds);
    }

    function updateFields(seconds) {
        document.getElementById('days-input').value = (seconds / 86400).toFixed(2);
        document.getElementById('hours-input').value = (seconds / 3600).toFixed(2);
        document.getElementById('minutes-input').value = (seconds / 60).toFixed(2);
        document.getElementById('seconds-input').value = (seconds).toFixed(2);  
    }
}