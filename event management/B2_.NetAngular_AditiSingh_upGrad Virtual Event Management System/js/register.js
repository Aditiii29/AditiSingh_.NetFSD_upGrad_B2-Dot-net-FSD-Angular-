(function () {
  "use strict";

  const form = document.getElementById("registerForm");

  function getQueryEventId() {
    const params = new URLSearchParams(window.location.search);
    return params.get("eventId");
  }

  async function populateEventData() {
    const eventId = getQueryEventId();

    if (!eventId) {
      alert("No event selected. Redirecting to home page.");
      window.location.href = "index.html";
      return;
    }

    try {
      const event = await window.EventDB.getEventById(eventId);

      if (!event) {
        alert("Event not found.");
        window.location.href = "index.html";
        return;
      }

      document.getElementById("regEventId").value = event.eventId;
      document.getElementById("regEventName").value = event.eventName;
      document.getElementById("regCategory").value = event.eventCategory;
      document.getElementById("regDate").value = event.eventDate;
      document.getElementById("regTime").value = event.eventTime;
    } catch (error) {
      alert("Unable to load event details.");
      window.location.href = "index.html";
    }
  }

  function bindRegistration() {
    if (!form) {
      return;
    }

    form.addEventListener("submit", function (event) {
      event.preventDefault();

      if (!form.checkValidity()) {
        form.classList.add("was-validated");
        return;
      }

      alert("You are successfully registered to this event!");
      form.reset();
      window.location.href = "index.html";
    });
  }

  populateEventData();
  bindRegistration();
})();
