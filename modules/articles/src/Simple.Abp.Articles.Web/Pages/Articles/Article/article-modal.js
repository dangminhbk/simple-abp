var simple = simple || {};
simple.abp = simple.abp || {};
simple.abp.modals = simple.abp.modals || {};
(function ($) {

    simple.abp.modals.article = function () {

        var _selector = {
            catalogTree: '#CreateEditCatalogTree',
            catalogId: '[name="ViewModel.CatalogId"]',

            tagSelect2: '#tagSelect2',
            tagSelect2Val: '[name="ViewModel.Tag"]',
            content:'[name="ViewModel.Content"]'
        }

        // catalog tree
        var _catalogTree = new simple.abp.CatalogTree({
            selector: _selector.catalogTree,
            init_callback: function () {

                // 如果有类别 ，默认选中
                var catalogId = $(_selector.catalogId).val();
                if (catalogId)
                    setTimeout(function () {
                        _catalogTree.select_node(catalogId);
                    }, 100)

            },
            onchange: function (e, data) {
                // 选择类别
                if (data.selected && data.selected.length > 0) {
                    $(_selector.catalogId).val(data.selected[0]);
                }
          
            }
        })

        // tag select2
        var _tagSelect2 = new simple.abp.TagSelect2({
            selector: _selector.tagSelect2,
            select: [$(_selector.tagSelect2Val).val()],
            selected: function (data) {
                $(_selector.tagSelect2Val).val(data.id);
            }
        })

        // set content
        var _setConsent = function (editor) {
            var content = editor.getContent();
            console.log(content);
            $(_selector.content).val(content);
         
        }

        // editor
        function _initTinymce() {
            tinymce.remove(_selector.content);
            tinymce.init({
                selector: _selector.content,
                language: 'zh_CN',
                plugins: "codesample image link",
                toolbar: 'bold italic underline | alignleft aligncenter alignright codesample image link',
                images_upload_url: '/oss/file/uploadRichImg?dir=image',
                images_upload_handler: function (blobInfo, success, failure) {
                    var formdata = new FormData()
                    formdata.set('upload_file', blobInfo.blob())

                    console.log("upload_file")
                    $.ajax({
                        type: "POST",
                        url: '/api/upload',
                        data: formdata,
                        contentType: false,
                        processData: false,
                        success: function (data) {
                            console.log(data)
                            success(data);
                        }
                    });
                },
                init_instance_callback: function (editor) {

                    editor.on('keyup', function (e) {
                        _setConsent(editor);
                    });

                    editor.on('change', function (e) {
                        _setConsent(editor);
                    });
                }
            });
        }

        // init dom
        this.initDom = function ($el) {

            _catalogTree.init();

            setTimeout(function () {
                _tagSelect2.init();
            }, 200);

            _initTinymce();
        };
    };
})(jQuery);
