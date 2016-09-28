/// <reference path="jquery-1.9.1.min.js" />
/// <reference path="jquery-1.9.1.intellisense.js" />
/// <reference path="bootstrap.min.js" />

(function () {
    var $dialogsList = $("#DialogsList"),
        $tabsWithMessages = $dialogsList.nextAll(),
        $dialogsListChildren = $dialogsList.children();
    i = 0,
    $tabs = $("#Tabs"),
    $messageForms = $(".sendForm");

    for (i = 0; i < $dialogsListChildren.length; i++) {
        addTab($dialogsListChildren[i], $tabs);
    }

    for (i = 0; i < $tabsWithMessages.length; i++) {
        ajaxReceiveMessagesForDialog($($tabsWithMessages[i].children[0]));
    }

    for (i = 0; i < $messageForms.length; i++) {
        ajaxMessageFormSend($messageForms[i]);
    };

    ajaxReceiveDialogs();

    function ajaxReceiveMessagesForDialog($dialogList) {
        this.setInterval(function () {
            $.ajax({
                url: 'ReceiveMessagesForDialog',
                method: 'get',
                data: {
                    secondPersonId: $dialogList.attr('id')
                }
            }).success(function (data) {
                $dialogList.append(data);
            });
        }, 100);
    }

    function ajaxReceiveDialogs() {
        this.setInterval(function () {
            $.ajax({
                url: 'ReceiveDialogs',
                method: 'get',
            }).success(function (data) {
                var $context = $(data.trim()),
                    $newDialogs = $("#DialogsList", $context),
                    $newDialogsChildren = $newDialogs.children(),
                    $newTabsWithNewMessages = $newDialogs.nextAll();
                i = 0;

                for (i = 0; i < $newDialogsChildren.length; i++) {
                    addTab($newDialogsChildren[i], $tabs);
                }

                for (i = 0; i < $newTabsWithNewMessages.length; i++) {
                    ajaxReceiveMessagesForDialog($($newTabsWithNewMessages[i].children[0]));
                }

                $dialogsList.append($newDialogsChildren);
                $dialogsList.after($newTabsWithNewMessages);
            })
        }, 100);
    }

    function addTab(dialog, $tabs) {
        var name = dialog.children[1].innerText,
            id = dialog.children[2].value;
        dialog.onclick = function () {
            var $tab = $('<li class="btn btn-link" data-toggle="tab" data-target="#' +
                id + '">' + name + '</li>');
            if (!$('li[data-target="' + '#' + id + '"]', $tabs).length) {
                $tabs.append($tab);
            }
            $tab.tab('show');
        };
    }

    function ajaxMessageFormSend(curForm) {
        var formElements = curForm.children;
        $(formElements[2]).click(function () {
            if (formElements[0].value.trim().length) {
                $.ajax({
                    url: 'SendMessage',
                    method: 'post',
                    data: {
                        text: formElements[0].value,
                        receiverId: formElements[1].value
                    }
                }).success(function (data) {
                    formElements[0].value = "";
                    var $previousElement = $(curForm).prev();
                    $previousElement.append(data);
                });
            }
        });
        $(formElements[0]).keypress(function (e) {
            if (e.which == 13) {
                if (formElements[0].value.trim().length) {
                    $.ajax({
                        url: 'SendMessage',
                        method: 'post',
                        data: {
                            text: formElements[0].value,
                            receiverId: formElements[1].value
                        }
                    }).success(function (data) {
                        formElements[0].value = "";
                        var $previousElement = $(curForm).prev();
                        $previousElement.append(data);
                    });
                }
            }
        })
    }
})();