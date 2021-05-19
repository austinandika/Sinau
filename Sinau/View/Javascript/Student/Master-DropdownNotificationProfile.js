// PROFILE DROPDOWN
/* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
function dropProfileBtn() {
    document.getElementById("profile-dropdown").classList.toggle("show-dropdown");
}

// NOTIFICATION DROPDOWN
/* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
function dropNotificationBtn() {
    document.getElementById("notification-dropdown").classList.toggle("show-dropdown");
}

// Close the dropdown if the user clicks outside of it
window.onclick = function (event) {
    var dropdowns;
    var i;
    var openDropdown;

    if (!event.target.closest('.notification-container')) {
        dropdowns = document.getElementsByClassName("notification-dropdown-content");
        for (i = 0; i < dropdowns.length; i++) {
            openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show-dropdown')) {
                openDropdown.classList.remove('show-dropdown');
            }
        }
    }

    if (!event.target.closest('.profile-container')) {
        dropdowns = document.getElementsByClassName("profile-dropdown-content");
        for (i = 0; i < dropdowns.length; i++) {
            openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show-dropdown')) {
                openDropdown.classList.remove('show-dropdown');
            }
        }
    }
}