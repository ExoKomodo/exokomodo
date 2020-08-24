function loadFromLocalStorage(key) {
    return JSON.parse(localStorage.getItem(key));
}

function saveToLocalStorage(key, obj) {
    localStorage.setItem(key, JSON.stringify(obj));
}