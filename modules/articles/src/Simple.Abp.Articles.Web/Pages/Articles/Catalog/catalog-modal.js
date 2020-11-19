var simple = simple || {};
simple.abp = simple.abp || {};
simple.abp.modals = simple.abp.modals || {};
(function ($) {

    simple.abp.modals.catalog = function () {

        var _selector = {
            catalogTree: '#CreateEditCatalogTree',
            id:'[name="Id"]',
            parentId: '[name="ViewModel.ParentId"]'
        }

        // catalog tree
        var _catalogTree = new simple.abp.CatalogTree({
            selector: _selector.catalogTree,
            filterIds: [$(_selector.id).val()],
            init_callback: function () {

                // 如果有parentId
                var parentId = $(_selector.parentId).val();
                if (parentId)
                    setTimeout(function () {
                        _catalogTree.select_node(parentId);
                    }, 100)
                 
            },
            onchange: function (e, data) {

                // 选择类别
                if (data.selected && data.selected.length > 0) {
                    $(_selector.parentId).val(data.selected[0]);
                }
                   
            }
        })

        // init dom 
        this.initDom = function ($el) {
            _catalogTree.init();
        };
    };
})(jQuery);
