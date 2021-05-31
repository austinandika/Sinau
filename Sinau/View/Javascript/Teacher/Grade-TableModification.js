////function editScoreMode(){
////    var btnEditId = document.getElementById('ContentPlaceHolder1_btnEdit');
////    var btnSubmitId = document.getElementById('ContentPlaceHolder1_btnSubmit');
////    var btnCancelId = document.getElementById('ContentPlaceHolder1_btnCancel');
////    var btnAddComponent = document.getElementById('ContentPlaceHolder1_btnAddComponent');
    //var txtScoreClass = document.getElementsByClassName('txt-score');
    //var cbIsActiveClass = document.getElementsByClassName('cb-is-active');

    //for (i = 0; i < cbIsActiveClass.length; i++) {
    //    // cb isActive become editable
    //    cbIsActiveClass[i].removeAttribute('disabled');
    //}

    //for (i = 0; i < txtScoreClass.length; i++) {
    //    // txt become editable
    //    txtScoreClass[i].removeAttribute('readonly');
    //    txtScoreClass[i].classList.add("edit-mode");
    //}

    //btnEditId.classList.add("hide-button");
    //btnAddComponent.classList.add("hide-button");
    //btnSubmitId.classList.remove("hide-button");
    //btnCancelId.classList.remove("hide-button");
    //return true;
//}

var errorMainDiv = document.getElementById('ContentPlaceHolder1_errorMain');

function editScoreMode() {
    var txtScoreClass = document.getElementsByClassName('txt-score');
    var isCorrect = true;

    for (i = 0; i < txtScoreClass.length; i++) {
        // validation for score
        var txtScoreClassValueTemp = parseInt(txtScoreClass[i].value);

        if (txtScoreClassValueTemp < 0 || txtScoreClassValueTemp > 100) {
            txtScoreClass[i].classList.add("error");
            isCorrect = false;
        }
    }


    if (isCorrect == true) {
        return true;
    }
    else {
        errorMainDiv.classList.add("error");
        errorMainDiv.innerHTML = "Score is not valid, please enter a score between 0 and 100";
        return false;
    }
}

// only can type number
function ValidNumeric() {

    var charCode = (event.which) ? event.which : event.keyCode;
    if (charCode >= 48 && charCode <= 57) { return true; }
    else { return false; }
}   


var txtComponentName = document.getElementById('ContentPlaceHolder1_txtComponentName');
var lblErrorComponentName = document.getElementById('ContentPlaceHolder1_lblErrorComponentName');
var btnCreateComponent = document.getElementById('ContentPlaceHolder1_btnCreateComponent');

var createFlag = true;

function validateCreateComponent() {
    createFlag = true;

    resetLblError();
    resetErrorEffect();
    resetAnimation();

    if (txtComponentName.value.length == 0) {
        lblErrorComponentName.innerHTML = "Assignment title is required";
        txtComponentName.classList.add("error");
        createFlag = false;
    }
    else if (txtComponentName.value.length < 3) {
        lblErrorComponentName.innerHTML = "Assignment title must be at least 3 characters";
        txtComponentName.classList.add("error");
        createFlag = false;
    }
    else if (txtComponentName.value.length > 20) {
        lblErrorComponentName.innerHTML = "Assignment title must be less than or equal to 20 characters";
        txtComponentName.classList.add("error");
        createFlag = false;
    }

    if (createFlag == false) {
        btnCreateComponent.classList.add("error");

        return false;
    }
    else {
        return true;
    }
}

function resetLblError() {
    lblErrorComponentName.innerHTML = "";
}

function resetErrorEffect() {
    txtComponentName.classList.remove("error");
    btnCreateComponent.classList.remove("error");
}

function resetAnimation() {
    void btnCreateComponent.offsetWidth;
}