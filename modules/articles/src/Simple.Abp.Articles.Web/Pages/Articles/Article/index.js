(function ($, tinymce) {

    var l = abp.localization.getResource('Articles');

    var service = simple.abp.articles.article;
    var createModal = new abp.ModalManager(abp.appPath + 'Articles/Article/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Articles/Article/EditModal');

    var _renderBool = function (data) {
        var state = data ? 'success' : 'primary';
        return '<span class="label label-' + state + ' label-dot mr-2"></span><span class="font-weight-bold text-' + state + '">' +
            data + '</span>';
    }

    $(function () {

        var dataTable = $('#ArticleTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: true,
            autoWidth: false,
            scrollCollapse: true,
            //order: [[0, "asc"]],
            ajax: abp.libs.datatables.createAjax(service.getList),
            columnDefs: [
                {
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('Articles.Article.Update'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('Articles.Article.Delete'),
                                    confirmMessage: function (data) {
                                        return l('ArticleDeletionConfirmationMessage', data.record.id);
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
                { data: "title" },
                {
                    data: "catalog",
                    render: function (data) {
                        if (data)
                            return data.title;

                        return "";
                    }
                },
                { data: "tag" },
                {
                    data: "isTop",
                    render: _renderBool
                },
                {
                    data: "isRefinement",
                    render: _renderBool
                },
                {
                    data: "displayState"
                }

            ]
        }));

        createModal.onResult(function () {
            dataTable.ajax.reload();
        });

        editModal.onResult(function () {
            dataTable.ajax.reload();
        });

        $('#NewArticleButton').click(function (e) {
            e.preventDefault();
            createModal.open();
        });
    })

})(jQuery, tinymce);