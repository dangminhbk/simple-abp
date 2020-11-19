var simple = simple || {};
simple.abp = simple.abp || {};
(function ($) {
    simple.abp.CatalogTree = (function () {
        //options={
        //  selector,
        //  onchange
        //}
        return function (options) {
            var _catalogTree = null;
            var _selected = [];

            function _isFilterData(id) {

                if (!options.filterIds)
                    return false;

                for (var i in options.filterIds) {
                    var filterId = options.filterIds[i];
                    return id === filterId;
                }

                return false;
            }

            function _getChildren(childs) {
                var jstreeData = [];

                if (!childs)
                    return jstreeData;

                for (var i in childs) {
                    var item = childs[i];

                    // 过滤数据
                    if (_isFilterData(item.id))
                        continue;
                        
                    jstreeData.push({
                        id: item.id,
                        text: item.title,
                        icon: "fa fa-file",
                        state: {
                            opened: true
                        },
                        children: _getChildren(item.childs)
                    })
                }

                return jstreeData;
            }
     
            function _getSelected() {
                return _selected;
            }

            function _select_node(id) {

                if (!_catalogTree)
                    return;

                _catalogTree.jstree(true).select_node(id)
            }

            function _init() {

                var service = simple.abp.articles.catalog;

                service.getTree().done(function (data) {
                    var jstreeData = _getChildren(data);

                    // 刷新数据
                    if (_catalogTree) {
                        _catalogTree.jstree(true).settings.core.data = jstreeData;
                        _catalogTree.jstree(true).refresh();
                        return;
                    }

                    // 第一次初始化
                    _catalogTree = $(options.selector).on('changed.jstree', function (e, data) {
                        _selected = data.selected;
                        if (options.onchange)
                            options.onchange(e, data);

                    }).jstree({
                        "core": {
                            "data": jstreeData
                        }
                    });

                    // 回调
                    if (options.init_callback) {
                        options.init_callback();
                    }
                })
            }

            return {
                init: _init,
                getSelected: _getSelected,
                select_node: _select_node
            };
        }

    })();
})(jQuery)