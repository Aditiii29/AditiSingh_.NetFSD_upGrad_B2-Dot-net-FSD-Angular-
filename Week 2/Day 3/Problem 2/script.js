// ================= SELECT ELEMENTS =================
const toggleButton = document.getElementById("toggleButton");
const body = document.body;

// ================= LOAD SAVED THEME =================
const savedTheme = localStorage.getItem("theme");

if (savedTheme) {
    body.classList.add(savedTheme);
    updateButtonText(savedTheme);
} else {
    body.classList.add("light");
}

// ================= TOGGLE FUNCTION =================
const toggleTheme = () => {

    if (body.classList.contains("light")) {
        body.classList.replace("light", "dark");
        localStorage.setItem("theme", "dark");
        updateButtonText("dark");
    } else {
        body.classList.replace("dark", "light");
        localStorage.setItem("theme", "light");
        updateButtonText("light");
    }
};

// ================= UPDATE BUTTON TEXT =================
const updateButtonText = (theme) => {
    toggleButton.textContent =
        theme === "dark"
        ? "Switch to Light Mode"
        : "Switch to Dark Mode";
};

// ================= EVENT LISTENER =================
toggleButton.addEventListener("click", toggleTheme);