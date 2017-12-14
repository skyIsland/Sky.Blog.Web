layui.define([
    'editormd',
    'jquery',
    'upload',
    'form'
], function (exports) {
    'use strict';
    var $ = layui.$;
    var editormd = layui.editormd;
    var upload = layui.upload;
    var form = layui.form;
    var editor;
    //layer.msg('丹麦的面包不单卖好帅啊!');
    $(function () {
        editor = editormd("editormdContent", {//注意1：这里的就是上面的DIV的id属性值
            width: "90%",
            height: 640,
            syncScrolling: "single",
            sequenceDiagram: true,
            flowChart: true,
            tex: true,
            emoji: true,
            path: "/scripts/plug/editormd/lib/",//注意2：你的路径
            saveHTMLToTextarea: true,//注意3：这个配置，方便post提交表单

            /**设置主题颜色*/
            editorTheme: "pastel-on-dark",
            theme: "gray",
            previewTheme: "dark",


            /**上传图片相关配置如下*/
            imageUpload: true,
            imageFormats: ["jpg", "jpeg", "gif", "png", "bmp", "webp"],
            imageUploadURL: "/UploadFile/SaveFiles?isMd=true"//注意你后端的上传图片服务地址

        });
        //$('select').each(function () {
        //    var $this = $(this);
        //    if ($this.data('ingore') == '1') {
        //        $this.show();
        //    }
        //});
    });

    //封面图片上传
    upload.render({
        elem: '#test1' //绑定元素
        , url: '/UploadFile/SaveFiles' //上传接口
        , done: function (res) {
            //上传完毕回调
            if (res.code === 0) {
                $('#showImg').attr('src', res.data.src);
                $('#PhotoUrl').val(res.data.src);
            }
        }
        , error: function (result) {
            //请求异常回调
            layer.msg(result.Message);
        }
    });
    //保存
    //自定义验证规则
    form.verify({
        Title: function (value) {
            if (value.length < 2) return '标题至少也得2个字符吧';
            if (value.length > 50) return '标题写得太多啦，不要超过50个字符好吗？';
        },
        ArticlassId: function (value) {
            if (value === '') return '请选择分类啦^_^';
        },
        Author: function (value) {
            if (value === '') return '至少得告诉人家，这篇文章是谁写的吧？';
        }
        //tags: function (value) {
        //    if (value === '') return '给她贴个标签呗，可以用逗号分割哦。';
        //},
       
    });
    //监听提交
    form.on('submit(cg)', function (data) {
        //将状态设置为0
        data.field.State =0;
        data.field.Content = editor.getMarkdown();
        $.post('/Admin/Article/Save', data.field, function (result) {
            if (result.Result) {
                layer.msg(result.Message, { icon: 6 }, function () {
                    parent.tables.reload();
                    //假设这是iframe页
                    var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
                    parent.layer.close(index); //再执行关闭
                });
            } else {
                console.log(result.Message);
                layer.msg("出错了,请联系管理员!", { icon: 5 });
            }
        });
        return false;
    });
    form.on('submit(publish)', function (data) {
        //将状态设置为1
        data.field.State =1;
        data.field.Content = editor.getMarkdown();
        $.post('/Admin/Article/Save', data.field, function (result) {
            if (result.Result) {
                layer.msg(result.Message, { icon: 6 }, function () {
                    parent.tables.reload();
                    //假设这是iframe页
                    var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
                    parent.layer.close(index); //再执行关闭
                });
            } else {
                console.log(result.Message);
                layer.msg("出错了,请联系管理员!", { icon: 5 });
            }
        });
        return false;
    });     
    exports('articleEdit', {});
});