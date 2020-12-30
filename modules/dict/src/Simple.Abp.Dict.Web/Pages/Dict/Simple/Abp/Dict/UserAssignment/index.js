$(function () {

    var l = abp.localization.getResource('Dict');

    var service = simple.abp.dict.userAssignment;
    var createModal = new abp.ModalManager(abp.appPath + 'Dict/Simple/Abp/Dict/UserAssignment/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Dict/Simple/Abp/Dict/UserAssignment/EditModal');

    var dataTable = $('#UserAssignmentTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Dict.UserAssignment.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Dict.UserAssignment.Delete'),
                                confirmMessage: function (data) {
                                    return l('UserAssignmentDeletionConfirmationMessage', data.record.id);
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
            { data: "wordCount" },
            { data: "phraseCount" },
            { data: "sentenceCount" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewUserAssignmentButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});