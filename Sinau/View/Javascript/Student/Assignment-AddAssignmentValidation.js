////var fuAnswerFile = null;
////$('.button-create button-design').click(function () {
////    fuAnswerFile = $(this).attr('id');
////})

////var btnCreate = null;
////$('.fu-answer-file').click(function () {
////    btnCreate = $(this).attr('id');
////})


//var fuAnswerFile = document.getElementById('ContentPlaceHolder1_rptStudentAssignment_fuAnswerFile_0');
//var btnCreate = document.getElementById('ContentPlaceHolder1_rptStudentAssignment_btnCreate_0');

var fuAnswerFile = document.getElementById('ContentPlaceHolder1_rptStudentAssignment_fuAnswerFile_0');
var btnCreate = document.getElementById('ContentPlaceHolder1_rptStudentAssignment_btnCreate_0');

// LABEL

var lblErrorAnswerFile = document.getElementById('ContentPlaceHolder1_rptStudentAssignment_lblErrorAnswerFile_0');

var createFlag = true;

function validateCreateAssignment() {
    createFlag = true;

    //resetLblError();
    resetErrorEffect();
    resetAnimation();

    fileUploadValidation();


    if (createFlag == false) {
        btnCreate.classList.add("error");

        return false;
    }
    else {
        return true;
    }
}

function fileUploadValidation() {
    var isValidFile = true;

    if (fuAnswerFile.value == "") {
        lblErrorAnswerFile.innerHTML = "File is required";
        createFlag = false;
    }
    else {
        var isValidFileExtensions = false;
        var fileSizeLimit = 20000; // 20.000kb = 20mb
        var allowedExtensions = new Array('txt', 'pdf', 'ppt', 'xls', 'doc', 'pptx', 'xlsx', 'docx', 'rar', 'zip', 'jpg', 'jpeg', 'png', 'wav', 'mp3', 'mp4', 'avi', '3gp', 'mkv', 'mov', 'flv');
        var fileExtensions = fuAnswerFile.value.split('.').pop().toLowerCase(); // split function will split the filename by dot(.), and pop function will pop the last element from the array which will give you the extension as well. If there will be no extension then it will return the filename.

        for (var i = 0; i <= allowedExtensions.length; i++) {
            if (allowedExtensions[i] == fileExtensions) {
                isValidFileExtensions = true; // valid file extension
            }
        }

        if (isValidFileExtensions == false) {
            lblErrorAnswerFile.innerHTML = "File type is not allowed";
            fuAnswerFile.value = null;
            createFlag = false;
        } else if (typeof (fuAnswerFile.files) != "undefined") {
            var fileSize = parseFloat(fuAnswerFile.files[0].size / 1024).toFixed(2);

            if (fileSize > fileSizeLimit) {
                lblErrorAnswerFile.innerHTML = "File size is too big, maximum file size is 20mb";
                fuAnswerFile.value = null;
                createFlag = false;
            }
        }
    }
}

function resetLblError() {
    lblErrorAnswerFile.innerHTML = "";
}

function resetErrorEffect() {
    fuAnswerFile.classList.remove("error");
    btnCreate.classList.remove("error");
}

function resetAnimation() {
    void btnCreate.offsetWidth;
}
