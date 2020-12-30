$(function () {

    var l = abp.localization.getResource('Dict');

    var service = simple.abp.dict.catalogWordMapping;
    var createModal = new abp.ModalManager(abp.appPath + 'Dict/Simple/Abp/Dict/CatalogWordMapping/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Dict/Simple/Abp/Dict/CatalogWordMapping/EditModal');

    var dataTable = $('#CatalogWordMappingTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Dict.CatalogWordMapping.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Dict.CatalogWordMapping.Delete'),
                                confirmMessage: function (data) {
                                    return l('CatalogWordMappingDeletionConfirmationMessage', data.record.id);
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
            { data: "wordId" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCatalogWordMappingButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});