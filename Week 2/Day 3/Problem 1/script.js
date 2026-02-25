// Select button and message element
const feedbackBtn = document.getElementById("feedbackBtn");
const message = document.getElementById("response");

// Add event listener
feedbackBtn.addEventListener("click", () => {

    // Dynamic DOM manipulation
    message.textContent = "✅ Thank you! Your feedback has been submitted successfully.";

});