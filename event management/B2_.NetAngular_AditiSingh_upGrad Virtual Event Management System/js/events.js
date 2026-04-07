(function () {
  "use strict";

  const form = document.getElementById("eventForm");
  const container = document.getElementById("adminEventsContainer");
  const logoutBtn = document.getElementById("logoutBtn");

  const searchById = document.getElementById("searchById");
  const searchByName = document.getElementById("searchByName");
  const searchByCategory = document.getElementById("searchByCategory");

  let allEvents = [];

  function getFormData() {
    return {
      eventId: document.getElementById("eventId").value.trim(),
      eventName: document.getElementById("eventName").value.trim(),
      eventCategory: document.getElementById("eventCategory").value,
      eventDate: document.getElementById("eventDate").value,
      eventTime: document.getElementById("eventTime").value,
      eventUrl: document.getElementById("eventUrl").value.trim()
    };
  }

  function renderEvents(events) {
    if (!container) {
      return;
    }

    if (!events.length) {
      container.innerHTML = '<div class="alert alert-warning">No matching events found.</div>';
      return;
    }

    container.innerHTML = events
      .map(
        (event) => `
        <div class="fade-in">
          <article class="card event-card h-100">
            <div class="card-body d-flex flex-column">
              <div class="d-flex justify-content-between align-items-center mb-2">
                <span class="event-chip">${event.eventCategory}</span>
                <small class="text-muted">${event.eventId}</small>
              </div>
              <h3 class="h5">${event.eventName}</h3>
              <p class="mb-2 text-muted">Date: ${event.eventDate}</p>
              <p class="mb-2 text-muted">Time: ${event.eventTime}</p>
              <a href="${event.eventUrl}" target="_blank" rel="noopener noreferrer" class="mb-3">Join Event</a>
              <button type="button" class="btn btn-outline-danger mt-auto delete-event-btn" data-id="${event.eventId}">Delete</button>
            </div>
          </article>
        </div>
      `
      )
      .join("");

    bindDeleteButtons();
  }

  function applySearch() {
    const idQuery = searchById.value.trim().toLowerCase();
    const nameQuery = searchByName.value.trim().toLowerCase();
    const categoryQuery = searchByCategory.value;

    const filtered = allEvents.filter((event) => {
      const idMatch = !idQuery || event.eventId.toLowerCase().includes(idQuery);
      const nameMatch = !nameQuery || event.eventName.toLowerCase().includes(nameQuery);
      const categoryMatch = !categoryQuery || event.eventCategory === categoryQuery;
      return idMatch && nameMatch && categoryMatch;
    });

    renderEvents(filtered);
  }

  function bindDeleteButtons() {
    const deleteButtons = document.querySelectorAll(".delete-event-btn");

    deleteButtons.forEach((button) => {
      button.addEventListener("click", async function () {
        const eventId = this.dataset.id;

        try {
          await window.EventDB.deleteEvent(eventId);
          allEvents = allEvents.filter((event) => event.eventId !== eventId);
          applySearch();
          alert("Event deleted successfully.");
        } catch (error) {
          alert("Unable to delete event. Please try again.");
        }
      });
    });
  }

  async function loadEvents() {
    try {
      allEvents = await window.EventDB.getAllEvents();
      allEvents.sort((a, b) => a.eventId.localeCompare(b.eventId));
      renderEvents(allEvents);
    } catch (error) {
      if (container) {
        container.innerHTML = '<div class="alert alert-danger">Could not load events.</div>';
      }
    }
  }

  function bindSearch() {
    [searchById, searchByName, searchByCategory].forEach((input) => {
      if (input) {
        input.addEventListener("input", applySearch);
        input.addEventListener("change", applySearch);
      }
    });
  }

  function bindAddEvent() {
    if (!form) {
      return;
    }

    form.addEventListener("submit", async function (event) {
      event.preventDefault();

      if (!form.checkValidity()) {
        form.classList.add("was-validated");
        return;
      }

      const payload = getFormData();

      try {
        await window.EventDB.addEvent(payload);
        allEvents.push(payload);
        allEvents.sort((a, b) => a.eventId.localeCompare(b.eventId));
        applySearch();
        form.reset();
        form.classList.remove("was-validated");
        alert("Event added successfully.");
      } catch (error) {
        alert("Event ID already exists or save failed.");
      }
    });
  }

  function bindLogout() {
    if (!logoutBtn) {
      return;
    }

    logoutBtn.addEventListener("click", function () {
      window.AuthService.logoutAdmin();
      window.location.href = "login.html";
    });
  }

  function protectRoute() {
    if (!window.AuthService.isAuthenticated()) {
      alert("Unauthorized access. Please login first.");
      window.location.href = "login.html";
    }
  }

  protectRoute();
  bindAddEvent();
  bindSearch();
  bindLogout();
  loadEvents();
})();
