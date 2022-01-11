var purchaseNexus = {};

purchaseNexus.setSessionStorage = function (key, data) {
    sessionStorage.setItem(key, data);
}

purchaseNexus.getSessionStorage = function (key) {
    return sessionStorage.getItem(key);
}

purchaseNexus.hideModal = function (element) {
    bootstrap.Modal.getInstance(element).hide();
}