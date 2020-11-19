$(function () {

    var l = abp.localization.getResource('Articles');

    var service = simple.abp.articles.tag;
    var createModal = new abp.ModalManager(abp.appPath + 'Articles/Tag/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Articles/Tag/EditModal');

    var dataTable = $('#TagTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Articles.Tag.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Articles.Tag.Delete'),
                                confirmMessage: function (data) {
                                    return l('TagDeletionConfirmationMessage', data.record.id);
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
            { data: "name" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewTagButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});