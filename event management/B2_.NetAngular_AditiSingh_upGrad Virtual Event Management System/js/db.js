(function () {
  "use strict";

  const DB_NAME = "upgradEMS";
  const DB_VERSION = 1;
  const STORE_NAME = "events";

  const defaultEvents = [
    {
      eventId: "EVT-100",
      eventName: "AI Future Summit",
      eventCategory: "Tech & Innovations",
      eventDate: "2026-04-15",
      eventTime: "10:00",
      eventUrl: "https://www.upgrad.com"
    },
    {
      eventId: "EVT-101",
      eventName: "Smart Factory Connect",
      eventCategory: "Industrial Events",
      eventDate: "2026-05-09",
      eventTime: "14:30",
      eventUrl: "https://www.upgrad.com"
    }
  ];

  function openDatabase() {
    return new Promise((resolve, reject) => {
      const request = indexedDB.open(DB_NAME, DB_VERSION);

      request.onerror = function () {
        reject(new Error("Unable to open IndexedDB."));
      };

      request.onupgradeneeded = function (event) {
        const db = event.target.result;
        const store = db.createObjectStore(STORE_NAME, { keyPath: "eventId" });
        store.createIndex("eventName", "eventName", { unique: false });
        store.createIndex("eventCategory", "eventCategory", { unique: false });

        defaultEvents.forEach((evt) => store.add(evt));
      };

      request.onsuccess = function (event) {
        resolve(event.target.result);
      };
    });
  }

  async function withStore(mode, callback) {
    const db = await openDatabase();

    return new Promise((resolve, reject) => {
      const tx = db.transaction(STORE_NAME, mode);
      const store = tx.objectStore(STORE_NAME);

      let request;
      try {
        request = callback(store);
      } catch (error) {
        reject(error);
        return;
      }

      request.onsuccess = function () {
        resolve(request.result);
      };

      request.onerror = function () {
        reject(request.error || new Error("IndexedDB operation failed."));
      };

      tx.oncomplete = function () {
        db.close();
      };

      tx.onerror = function () {
        reject(tx.error || new Error("IndexedDB transaction failed."));
      };
    });
  }

  function getAllEvents() {
    return withStore("readonly", (store) => store.getAll());
  }

  function getEventById(eventId) {
    return withStore("readonly", (store) => store.get(eventId));
  }

  function addEvent(eventData) {
    return withStore("readwrite", (store) => store.add(eventData));
  }

  function deleteEvent(eventId) {
    return withStore("readwrite", (store) => store.delete(eventId));
  }

  window.EventDB = {
    getAllEvents,
    getEventById,
    addEvent,
    deleteEvent
  };
})();
