// ================= COMMON FORMAT FUNCTION =================

const formatWeather = (data) => `
    <h3>Weather Report</h3>
    <p>Temperature: ${data.current_weather.temperature}°C</p>
    <p>Wind Speed: ${data.current_weather.windspeed} km/h</p>
    <p>Time: ${data.current_weather.time}</p>
`;


// ================= PROMISE VERSION =================

const getWeatherPromise = () => {

    const lat = document.getElementById("lat").value;
    const lon = document.getElementById("lon").value;

    const url =
        `https://api.open-meteo.com/v1/forecast?latitude=${lat}&longitude=${lon}&current_weather=true`;

    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error("Network response failed");
            }
            return response.json();
        })
        .then(data => {
            document.getElementById("output").innerHTML =
                formatWeather(data);
        })
        .catch(error => {
            document.getElementById("output").innerHTML =
                `<p style="color:red;">Error: ${error.message}</p>`;
        });
};


// ================= ASYNC/AWAIT VERSION =================

const getWeatherAsync = async () => {

    try {

        const lat = document.getElementById("lat").value;
        const lon = document.getElementById("lon").value;

        const url =
            `https://api.open-meteo.com/v1/forecast?latitude=${lat}&longitude=${lon}&current_weather=true`;

        const response = await fetch(url);

        if (!response.ok) {
            throw new Error("Network response failed");
        }

        const data = await response.json();

        document.getElementById("output").innerHTML =
            formatWeather(data);

    } catch (error) {

        document.getElementById("output").innerHTML =
            `<p style="color:red;">Error: ${error.message}</p>`;
    }
};


// ================= MAKE FUNCTIONS GLOBAL =================

// Because you're using onclick in HTML

window.getWeatherPromise = getWeatherPromise;
window.getWeatherAsync = getWeatherAsync;