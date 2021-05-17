var txtEmail = document.getElementById('txtEmail');
var txtPassword = document.getElementById('txtPassword');

var btnLogin = document.getElementById('btnLogin');

// LABEL
var lblErrorEmail = document.getElementById('lblErrorEmail');
var lblErrorPassword = document.getElementById('lblErrorPassword');

var loginFlag = true;

function validateLogin() {
    loginFlag = true;

    resetLblError();
    resetErrorEffect();
    resetAnimation();

    validateEmail();
    validatePassword();

    if (loginFlag == false) {
        btnLogin.classList.add("error");

        return false;
    }
    else {
        return true;
    }
}

function resetLblError() {
    lblErrorEmail.innerHTML = "";
    lblErrorPassword.innerHTML = "";
}

function resetErrorEffect() {
    txtEmail.classList.remove("error");
    txtPassword.classList.remove("error");
    btnLogin.classList.remove("error");
}

function resetAnimation() {
    void btnLogin.offsetWidth;
}

function validateEmail() {
    var isValidEmail = true;
    var atEmail = txtEmail.value.indexOf('@');

    if (txtEmail.value.length == 0) {
        lblErrorEmail.innerHTML = "Email is required";
        txtEmail.classList.add("error");
        isValidEmail = false;
    }
    else if (txtEmail.value.length < 2) {
        lblErrorEmail.innerHTML = "Please enter a valid email address";
        txtEmail.classList.add("error");
        isValidEmail = false;
    }
    else if (atEmail == -1) {   // No '@' at email address
        lblErrorEmail.innerHTML = "Please enter a valid email address";
        txtEmail.classList.add("error");
        isValidEmail = false;
    }

    if (isValidEmail == true) {
        var emailParts = txtEmail.value.split("@");
        var dotEmail = emailParts[1].indexOf('.');
        var dotSplits = emailParts[1].split(".");
        var dotCount = dotSplits.length - 1;

        if (dotEmail == -1 || dotEmail < 2 || dotCount > 2) { // at least one dot, max 2 dot after "@" and minimum 1 character after "@"
            lblErrorEmail.innerHTML = "Please enter a valid email address";
            txtEmail.classList.add("error");
            isValidEmail = false;
        }

        for (var i = 0; i < dotSplits.length; i++) { // dot cannot be the last of the character and dots are not repeated
            if (dotSplits[i].length == 0) {
                lblErrorEmail.innerHTML = "Please enter a valid email address";
                txtEmail.classList.add("error");
                isValidEmail = false;
            }
        }
    }

    if (isValidEmail == false) {
        loginFlag = false;
    }
}

function validatePassword() {
    var passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;

    if (txtPassword.value.length == 0) {
        lblErrorPassword.innerHTML = "Password is required";
        txtPassword.classList.add("error");
        loginFlag = false;
    }
    else if (txtPassword.value.length < 8) {
        lblErrorPassword.innerHTML = "Password length must be at least 8 characters";
        txtPassword.classList.add("error");
        loginFlag = false;
    }
    else if (!txtPassword.value.match(passwordRegex)) {
        lblErrorPassword.innerHTML = "Password must contain at least one letter and one number";
        txtPassword.classList.add("error");
        loginFlag = false;
    }
}
