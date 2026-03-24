(function () {
  "use strict";

  const contactForm = document.getElementById("contactForm");

  if (!contactForm) {
    return;
  }

  contactForm.addEventListener("submit", function (event) {
    event.preventDefault();

    if (!contactForm.checkValidity()) {
      contactForm.classList.add("was-validated");
      return;
    }

    alert("Thank you! Your query has been submitted successfully.");
    contactForm.reset();
    contactForm.classList.remove("was-validated");
  });
})();
