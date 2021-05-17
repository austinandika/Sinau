var txtUserID = document.getElementById('txtUserID');
var txtActivationCode = document.getElementById('txtActivationCode');
var txtEmail = document.getElementById('txtEmail');
var txtPassword = document.getElementById('txtPassword');
var TxtConfirmPassword = document.getElementById('TxtConfirmPassword');

var btnValidate = document.getElementById('btnValidate');
var btnActivate = document.getElementById('btnActivate');

// LABEL
var lblErrorID = document.getElementById('lblErrorID');
var lblErrorActivationCode = document.getElementById('lblErrorActivationCode');
var lblErrorEmail = document.getElementById('lblErrorEmail');
var lblErrorPassword = document.getElementById('lblErrorPassword');
var lblErrorConfirmPassword = document.getElementById('lblErrorConfirmPassword');

var validateFlag = true;
var activateFlag = true;

function validateUserValidation() {
    validateFlag = true;
    activateFlag = true;

    resetLblError();
    resetErrorEffect();
    resetAnimation();

    validateUserID();
    validateActivationCode();

    if (validateFlag == false) {
        btnValidate.classList.add("error");

        return false;
    }
    else {
        return true;
    }
}

function validateUserActivation() {
    validateFlag = true;
    activateFlag = true;

    resetLblError();
    resetErrorEffect();
    resetAnimation();

    validateEmail();
    validatePassword();
    validateConfirmPassword();

    if (activateFlag == false) {
        btnActivate.classList.add("error");

        return false;
    }
    else {
        return true;
    }
}

function resetLblError() {
    lblErrorID.innerHTML = "";
    lblErrorActivationCode.innerHTML = "";
    lblErrorEmail.innerHTML = "";
    lblErrorPassword.innerHTML = "";
    lblErrorConfirmPassword.innerHTML = "";
}

function resetErrorEffect() {
    txtUserID.classList.remove("error");
    txtActivationCode.classList.remove("error");
    txtEmail.classList.remove("error");
    txtPassword.classList.remove("error");
    TxtConfirmPassword.classList.remove("error");
    btnValidate.classList.remove("error");
    btnActivate.classList.remove("error");
}

function resetAnimation() {
    void btnValidate.offsetWidth;
    void btnActivate.offsetWidth;
}

function validateUserID() {
    var onlyNumbersRegex = /^[0-9]+$/;
    if (txtUserID.value.length == 0) {
        lblErrorID.innerHTML = "NISN/NIGN is required";
        txtUserID.classList.add("error");
        validateFlag = false;
    }
    else if (!txtUserID.value.match(onlyNumbersRegex)) {
        lblErrorID.innerHTML = "NISN/NIGN must be a number";
        txtUserID.classList.add("error");
        validateFlag = false;
    }
    else if (txtUserID.value.length < 10) {
        lblErrorID.innerHTML = "NISN/NIGN must be at least 10 numbers";
        txtUserID.classList.add("error");
        validateFlag = false;
    }
}

function validateActivationCode() {
    if (txtActivationCode.value.length == 0) {
        lblErrorActivationCode.innerHTML = "Activation code is required";
        txtActivationCode.classList.add("error");
        validateFlag = false;
    }
    else if (txtActivationCode.value.length < 8) {
        lblErrorActivationCode.innerHTML = "Activation code must be at least 8 characters";
        txtActivationCode.classList.add("error");
        validateFlag = false;
    }
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
        activateFlag = false;
    }
}

function validatePassword() {
    var passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;

    if (txtPassword.value.length == 0) {
        lblErrorPassword.innerHTML = "Password is required";
        txtPassword.classList.add("error");
        activateFlag = false;
    }
    else if (txtPassword.value.length < 8) {
        lblErrorPassword.innerHTML = "Password length must be at least 8 characters";
        txtPassword.classList.add("error");
        activateFlag = false;
    }
    else if (!txtPassword.value.match(passwordRegex)) {
        lblErrorPassword.innerHTML = "Password must contain at least one letter and one number";
        txtPassword.classList.add("error");
        activateFlag = false;
    }
}

function validateConfirmPassword() {
    var passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;

    if (TxtConfirmPassword.value.length == 0) {
        lblErrorConfirmPassword.innerHTML = "Password is required";
        TxtConfirmPassword.classList.add("error");
        activateFlag = false;
    }
    else if (TxtConfirmPassword.value.length < 8) {
        lblErrorConfirmPassword.innerHTML = "Password length must be at least 8 characters";
        TxtConfirmPassword.classList.add("error");
        activateFlag = false;
    }
    else if (!TxtConfirmPassword.value.match(passwordRegex)) {
        lblErrorConfirmPassword.innerHTML = "Password must contain at least one letter and one number";
        TxtConfirmPassword.classList.add("error");
        activateFlag = false;
    }
    else if (TxtConfirmPassword.value != txtPassword.value) {
        lblErrorConfirmPassword.innerHTML = "Password does not match";
        TxtConfirmPassword.classList.add("error");
        activateFlag = false;
    }
}

