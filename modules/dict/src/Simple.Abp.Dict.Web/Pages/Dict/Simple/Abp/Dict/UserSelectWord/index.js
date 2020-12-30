$(function () {

    var l = abp.localization.getResource('Dict');

    var service = simple.abp.dict.userSelectWord;
    var createModal = new abp.ModalManager(abp.appPath + 'Dict/Simple/Abp/Dict/UserSelectWord/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Dict/Simple/Abp/Dict/UserSelectWord/EditModal');

    var dataTable = $('#UserSelectWordTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('Dict.UserSelectWord.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Dict.UserSelectWord.Delete'),
                                confirmMessage: function (data) {
                                    return l('UserSelectWordDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                        service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            { data: "wordId" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewUserSelectWordButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});