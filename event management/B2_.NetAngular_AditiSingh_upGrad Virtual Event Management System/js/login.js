(function () {
  "use strict";

  const loginForm = document.getElementById("loginForm");
  const emailInput = document.getElementById("adminEmail");
  const passwordInput = document.getElementById("adminPassword");

  if (!loginForm) {
    return;
  }

  loginForm.addEventListener("submit", function (event) {
    event.preventDefault();

    if (!loginForm.checkValidity()) {
      loginForm.classList.add("was-validated");
      return;
    }

    const isValidUser = window.AuthService.loginAdmin(emailInput.value.trim(), passwordInput.value);

    if (isValidUser) {
      window.location.href = "events.html";
    } else {
      alert("Invalid credentials. Use admin@upgrad.com / 12345");
    }
  });
})();
