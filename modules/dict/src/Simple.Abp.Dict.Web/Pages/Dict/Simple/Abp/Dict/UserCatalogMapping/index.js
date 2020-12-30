$(function () {

    var l = abp.localization.getResource('Dict');

    var service = simple.abp.dict.userCatalogMapping;
    var createModal = new abp.ModalManager(abp.appPath + 'Dict/Simple/Abp/Dict/UserCatalogMapping/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Dict/Simple/Abp/Dict/UserCatalogMapping/EditModal');

    var dataTable = $('#UserCatalogMappingTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Dict.UserCatalogMapping.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Dict.UserCatalogMapping.Delete'),
                                confirmMessage: function (data) {
                                    return l('UserCatalogMappingDeletionConfirmationMessage', data.record.id);
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
            { data: "catalogId" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewUserCatalogMappingButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});