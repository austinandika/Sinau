function editScoreMode(){
    var btnEditId = document.getElementById('ContentPlaceHolder1_btnEdit');
    var btnSubmitId = document.getElementById('ContentPlaceHolder1_btnSubmit');
    var txtScoreClass = document.getElementsByClassName('txt-score');
    for (i = 0; i < txtScoreClass.length; i++) {
        txtScoreClass[i].removeAttribute('readonly');
        txtScoreClass[i].classList.add("edit-mode");
    }

    btnEditId.classList.add("hide-button");
    btnSubmitId.classList.remove("hide-button");
    return false;
}