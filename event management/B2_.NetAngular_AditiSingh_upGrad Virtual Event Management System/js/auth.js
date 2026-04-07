(function () {
  "use strict";

  const AUTH_KEY = "upgradAdminLoggedIn";
  const ADMIN_EMAIL = "admin@upgrad.com";
  const ADMIN_PASSWORD = "12345";

  function loginAdmin(email, password) {
    const isValid = email === ADMIN_EMAIL && password === ADMIN_PASSWORD;
    if (isValid) {
      sessionStorage.setItem(AUTH_KEY, "true");
    }
    return isValid;
  }

  function logoutAdmin() {
    sessionStorage.removeItem(AUTH_KEY);
  }

  function isAuthenticated() {
    return sessionStorage.getItem(AUTH_KEY) === "true";
  }

  window.AuthService = {
    loginAdmin,
    logoutAdmin,
    isAuthenticated
  };
})();
