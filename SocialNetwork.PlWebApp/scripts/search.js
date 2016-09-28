/// <reference path="jquery-1.9.1.min.js" />
/// <reference path="jquery-1.9.1.intellisense.js" />
/// <reference path="bootstrap.min.js" />

(function () {
    var $searchInput = $('#SearchInput'),
        $anotherSearchForm = $('#AnotherSearchForm'),
        $anotherInput = $('#AnotherSearchInput');

    $searchInput.keypress(function (e) {
        if (e.which == 13) {
            $('#SearchForm').submit();
        }
    });

    $anotherInput.keypress(function (e) {
        if (e.which == 13) {
            $('#SearchForm').submit();
        }
    })
}())