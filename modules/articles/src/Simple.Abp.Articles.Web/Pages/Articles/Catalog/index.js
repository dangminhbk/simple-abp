$(function () {

    var l = abp.localization.getResource('Articles');

    var service = simple.abp.articles.catalog;
    var createModal = new abp.ModalManager(abp.appPath + 'Articles/Catalog/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Articles/Catalog/EditModal');
    var catalogTree = new simple.abp.CatalogTree({
        selector: '#catalogTree'
    })

    $(function () {
        catalogTree.init();

        createModal.onResult(function () {
            catalogTree.init();
        });

        editModal.onResult(function () {
            catalogTree.init();
        });

        $('#NewCatalogButton').click(function (e) {
            e.preventDefault();
            createModal.open();
        });

        $('#UpdateCatalogButton').click(function (e) {
            e.preventDefault();
            var selectId = catalogTree.getSelected();
            if (!selectId || selectId.length <= 0) {
                abp.message.warn("请先选择要修改的类别！");
                return;
            }
            editModal.open({ id: selectId[0] });
        })

        $('#DeleteCatalogButton').click(function (e) {
            e.preventDefault();
            var selectId = catalogTree.getSelected();
            if (!selectId || selectId.length <= 0) {
                abp.message.warn("请先选择要删除的类别！");
                return;
            }

            service.delete(selectId[0]).done(function () {
                catalogTree.init();
            })
        })

        
    })

});