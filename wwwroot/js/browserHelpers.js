function loadFromLocalStorage(key) {
    return JSON.parse(localStorage.getItem(key));
}

function saveToLocalStorage(key, obj) {
    localStorage.setItem(key, JSON.stringify(obj));
}

function updateFavicon(faviconUri) {
    let favicon = document.getElementById('favicon');
    if (!favicon) {
        console.error('Could not find favicon tag.');
        return;
    }
    let href = favicon.getAttributeNode('href');
    if (!href) {
        href = document.createAttribute('href');
        favicon.setAttributeNode(href);
    }
    href.value = faviconUri;
}