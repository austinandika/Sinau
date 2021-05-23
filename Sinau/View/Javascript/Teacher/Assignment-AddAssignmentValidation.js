var txtAssignmentTitle = document.getElementById('ContentPlaceHolder1_txtAssignmentTitle');
var txtAssignDate = document.getElementById('ContentPlaceHolder1_txtAssignDate');
var txtDueDate = document.getElementById('ContentPlaceHolder1_txtDueDate');
var fuQuestionFile = document.getElementById('ContentPlaceHolder1_fuQuestionFile');
var btnCreate = document.getElementById('ContentPlaceHolder1_btnCreate');

// LABEL
var lblErrorAssignmentTitle = document.getElementById('ContentPlaceHolder1_lblErrorAssignmentTitle');
var lblErrorAssignDate = document.getElementById('ContentPlaceHolder1_lblErrorAssignDate');
var lblErrorDueDate = document.getElementById('ContentPlaceHolder1_lblErrorDueDate');
var lblErrorQuestionFile = document.getElementById('ContentPlaceHolder1_lblErrorQuestionFile');

var createFlag = true;

function validateCreateAssignment() {
    createFlag = true;

    resetLblError();
    resetErrorEffect();
    resetAnimation();

    assignmentTitleValidation();
    assignDateValidation();
    dueDateValidation();
    fileUploadValidation();


    if (createFlag == false) {
        btnCreate.classList.add("error");

        return false;
    }
    else {
        return true;
    }
}

function assignmentTitleValidation() {
    if (txtAssignmentTitle.value.length == 0) {
        lblErrorAssignmentTitle.innerHTML = "Assignment title is required";
        txtAssignmentTitle.classList.add("error");
        createFlag = false;
    }
    else if (txtAssignmentTitle.value.length < 3) {
        lblErrorAssignmentTitle.innerHTML = "Assignment title must be at least 3 characters";
        txtAssignmentTitle.classList.add("error");
        createFlag = false;
    }
}

var isValidAssignDate = true;

function assignDateValidation() {
    isValidAssignDate = true;
    var isValidDate = true;
    var dateRegex = /(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/; // DD/MM/YYY format

    if (txtAssignDate.value.length == 0) {
        lblErrorAssignDate.innerHTML = "Assign date is required";
        txtAssignDate.classList.add("error");
        isValidDate = false;
    }
    else if (!txtAssignDate.value.match(dateRegex)) {
        lblErrorAssignDate.innerHTML = "Assign date must be follow 'dd/MM/yyyy' format";
        txtAssignDate.classList.add("error");
        isValidDate = false;
    }
    else {
        var assignDateParts = txtAssignDate.value.split("/");
        var dateObjectAssign = new Date(+assignDateParts[2], assignDateParts[1] - 1, +assignDateParts[0]);

        var today = new Date();
        //var dd = String(today.getDate()).padStart(2, '0');
        //var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
        //var yyyy = today.getFullYear();

        //today = mm + '/' + dd + '/' + yyyy;

        var diffDays = dateObjectAssign.getDate() - today.getDate();

        if (diffDays < 0) {
            lblErrorAssignDate.innerHTML = "Assign date must be same or greater than today date";
            txtAssignDate.classList.add("error");
            isValidDate = false;
        }
    }

    if (isValidDate == false) {
        createFlag = false;
        isValidAssignDate = false;
    }
}

function dueDateValidation() {
    var isValidDate = true;
    var dateRegex = /(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/; // DD/MM/YYY format

    if (txtDueDate.value.length == 0) {
        lblErrorDueDate.innerHTML = "Due date is required";
        txtDueDate.classList.add("error");
        isValidDate = false;
    }
    else if (!txtDueDate.value.match(dateRegex)) {
        lblErrorDueDate.innerHTML = "Due date must be follow 'dd/MM/yyyy' format";
        txtDueDate.classList.add("error");
        isValidDate = false;
    }

    if (isValidDate && isValidAssignDate) {
        var assignDateParts = txtAssignDate.value.split("/");
        var dateObjectAssign = new Date(+assignDateParts[2], assignDateParts[1] - 1, +assignDateParts[0]);

        var dueDateParts = txtDueDate.value.split("/");
        var dateObjectDue = new Date(+dueDateParts[2], dueDateParts[1] - 1, +dueDateParts[0]);

        var diffDays = dateObjectDue.getDate() - dateObjectAssign.getDate();

        if (diffDays < 0) {
            lblErrorDueDate.innerHTML = "Due date must be greater than assign date";
            txtDueDate.classList.add("error");
            isValidDate = false;
        }
    }

    if (isValidDate == false) {
        createFlag = false;
    }
}

function fileUploadValidation() {
    var isValidFile = true;

    if (fuQuestionFile.value == "") {
        lblErrorQuestionFile.innerHTML = "File is required";
        createFlag = false;
    }
    else {
        var isValidFileExtensions = false;
        var fileSizeLimit = 20000; // 20.000kb = 20mb
        var allowedExtensions = new Array('txt', 'pdf', 'ppt', 'xls', 'doc', 'pptx', 'xlsx', 'docx', 'rar', 'zip', 'jpg', 'jpeg', 'png', 'wav', 'mp3', 'mp4', 'avi', '3gp', 'mkv', 'mov', 'flv');
        var fileExtensions = fuQuestionFile.value.split('.').pop().toLowerCase(); // split function will split the filename by dot(.), and pop function will pop the last element from the array which will give you the extension as well. If there will be no extension then it will return the filename.

        for (var i = 0; i <= allowedExtensions.length; i++) {
            if (allowedExtensions[i] == fileExtensions) {
                isValidFileExtensions = true; // valid file extension
            }
        }

        if (isValidFileExtensions == false) {
            lblErrorQuestionFile.innerHTML = "File type is not allowed";
            fuQuestionFile.value = null;
            createFlag = false;
        } else if (typeof (fuQuestionFile.files) != "undefined") {
            var fileSize = parseFloat(fuQuestionFile.files[0].size / 1024).toFixed(2);

            if (fileSize > fileSizeLimit) {
                lblErrorQuestionFile.innerHTML = "File size is too big, maximum file size is 20mb";
                fuQuestionFile.value = null;
                createFlag = false;
            }
        } 
    }
}

function resetLblError() {
    lblErrorAssignmentTitle.innerHTML = "";
    lblErrorAssignDate.innerHTML = "";
    lblErrorDueDate.innerHTML = "";
    lblErrorQuestionFile.innerHTML = "";
}

function resetErrorEffect() {
    txtAssignmentTitle.classList.remove("error");
    txtAssignDate.classList.remove("error");
    txtDueDate.classList.remove("error");
    fuQuestionFile.classList.remove("error");
    btnCreate.classList.remove("error");
}

function resetAnimation() {
    void btnCreate.offsetWidth;
}