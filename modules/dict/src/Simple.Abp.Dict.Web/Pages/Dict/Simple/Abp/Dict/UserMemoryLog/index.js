$(function () {

    var l = abp.localization.getResource('Dict');

    var service = simple.abp.dict.userMemoryLog;
    var createModal = new abp.ModalManager(abp.appPath + 'Dict/Simple/Abp/Dict/UserMemoryLog/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Dict/Simple/Abp/Dict/UserMemoryLog/EditModal');

    var dataTable = $('#UserMemoryLogTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Dict.UserMemoryLog.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Dict.UserMemoryLog.Delete'),
                                confirmMessage: function (data) {
                                    return l('UserMemoryLogDeletionConfirmationMessage', data.record.id);
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
            { data: "type" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewUserMemoryLogButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});