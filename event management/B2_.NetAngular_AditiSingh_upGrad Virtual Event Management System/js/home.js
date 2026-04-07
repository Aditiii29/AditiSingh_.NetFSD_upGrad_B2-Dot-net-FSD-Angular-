(function () {
  "use strict";

  const container = document.getElementById("homeEventsContainer");

  function eventCardTemplate(event) {
    return `
      <div class="fade-in">
        <article class="card event-card h-100">
          <div class="card-body d-flex flex-column">
            <div class="d-flex justify-content-between align-items-center mb-2">
              <span class="event-chip">${event.eventCategory}</span>
              <small class="text-muted">${event.eventId}</small>
            </div>
            <h3 class="h5">${event.eventName}</h3>
            <p class="text-muted mb-2">Date: ${event.eventDate}</p>
            <p class="text-muted mb-3">Time: ${event.eventTime}</p>
            <a href="${event.eventUrl}" target="_blank" rel="noopener noreferrer" class="mb-3">Join Event</a>
            <a href="register.html?eventId=${encodeURIComponent(event.eventId)}" class="btn btn-primary mt-auto">Register</a>
          </div>
        </article>
      </div>
    `;
  }

  async function loadHomeEvents() {
    if (!container) {
      return;
    }

    try {
      const events = await window.EventDB.getAllEvents();

      if (!events.length) {
        container.innerHTML = '<div class="alert alert-info">No events available at the moment.</div>';
        return;
      }

      container.innerHTML = events.map(eventCardTemplate).join("");
    } catch (error) {
      container.innerHTML = '<div class="alert alert-danger">Failed to load events. Please refresh.</div>';
    }
  }

  loadHomeEvents();
})();
