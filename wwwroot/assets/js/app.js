let navToggled = false;

function toggleNav() {
    let textElements = document.getElementsByClassName('sidebar-navlink-text');
    let toggleElement = document.getElementById('sidebar-toggle');

    navToggled = !navToggled;

    for (const element of textElements) {
        if (navToggled) {
            element.style.display = 'none';
            toggleElement.className = 'bi bi-arrow-bar-right sidebar-navlink-icon';
        }
        else {
            element.style.display = 'flex';
            toggleElement.className = 'bi bi-arrow-bar-left sidebar-navlink-icon';
        }
    }
}