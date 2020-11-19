var simple = simple || {};
simple.abp = simple.abp || {};
(function ($) {
    simple.abp.TagSelect2 = (function () {
        //options={
        //  selector,
        //  onchange,
        //  maximumSelectionLength:1
        //  selected:func,
        //  select:[]
        //}
        return function (options) {

            if (!options.maximumSelectionLength)
                options.maximumSelectionLength = 1;

            function _isSelected(id) {
                if (!options.select)
                    return false;

                for (var i in options.select) {
                    var item = options.select[i];
                    if (item === id)
                        return true;
                }

                return false;
            }

            function _generateSelect2Data(data) {
                var select2Data = [];
                for (var i in data) {
                    var item = data[i];
                    select2Data.push({
                        id: item.name,
                        text: item.name,
                        selected: _isSelected(item.name)
                    })
                }

                return select2Data;
            }

            function _init() {

                var service = simple.abp.articles.tag;
                service.getAll().done(function (data) {

                    var select2Data = _generateSelect2Data(data);

                    // init select2
                    $(options.selector).select2({
                        placeholder: "Add a tag",
                        tags: true,
                        maximumSelectionLength: options.maximumSelectionLength ,
                        data: select2Data
                    }).on("select2:select", function (e, data) {
                        if (options.selected)
                            options.selected(e.params.data);
                    });
                })         
            }

            return {
                init: _init
            };
        }

    })();
})(jQuery)