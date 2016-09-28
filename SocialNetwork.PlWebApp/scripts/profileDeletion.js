/// <reference path="jquery-1.9.1.js" />
/// <reference path="bootstrap.min.js" />

(function () {
    var $myModal = $('#DeletionModal');
    $myModal.modal('show');
    $('#DeletionModal').on('hidden.bs.modal', function () {
        location.replace("/User");
    })
})()