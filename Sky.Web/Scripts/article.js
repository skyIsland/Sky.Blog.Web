var tables;
layui.define(['table', 'form'], function (exports) {
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    //执行渲染
    tables=table.render({
        elem: '#demo' //指定原始表格元素选择器（推荐id选择器）
        , height: 500 //容器高度
        , url: '/Admin/Article/GetDataList'
        , loading: true
        , page: true
        , limits: [5, 7, 10]
        , limit: 5
        , request: {
            pageName: 'PageNo' //页码的参数名称，默认：page
            , limitName: 'PageSize' //每页数据量的参数名，默认：limit
        }
        , response: {
            statusName: 'Result' //数据状态的字段名称，默认：code
            , statusCode: true //成功的状态码，默认：0
            , msgName: 'Message' //状态信息的字段名称，默认：msg
            , countName: 'Count' //数据总数的字段名称，默认：count
            , dataName: 'Data' //数据列表的字段名称，默认：data
        }
        //, skin: 'line' //行边框风格
        , even: true //开启隔行背景
        , cols: [[
            {
                field: 'AddTime', aligh: 'center', title: '发表时间', width: 150, templet: '<div>{{dateFormat(d.AddTime)}}</div>'
            },
            {
                field: 'Title', aligh: 'center', title: '标题', width: 150
            },
            {
                field: 'Author', aligh: 'center', title: '作者', width: 150
            },
            {
                field: 'State', aligh: 'center', title: '状态', width: 150,templet:'#status'
            },
            {
                field: 'ArticleClassName', aligh: 'center', title: '分类', width: 100
            },
            {
                field: 'IsTop', aligh: 'center', title: '置顶', templet: '#IsTopTpl', width: 100
            },
            {
                field: 'IsRecommend', aligh: 'center', title: '推荐', templet: '#IsRecommendTpl', width: 100
            },
            {
                title:"操作",aligh:'center', width: 150, toolbar: '#barDemo'
            }
        ]]
    });  
    //监听工具栏
    table.on('tool(demo)', function (obj) {
        var data = obj.data;
        if (obj.event === 'del') {
            var msg = '你真的要把  <span style="color:red;">' +
                data.ClassName +
                '</span> 给删除吗？<img src="' +
                location.origin +
                '/Scripts/plug/layui/images/face/4.gif" alt="[可怜]">';
            var title = '萌萌的提示<img src="' + location.origin + '/Scripts/plug/layui/images/face/7.gif" alt="[害羞]">'
            layer.confirm(msg, { icon: 3, title: title }, function (index) {
                //do something
                $.get('/Admin/Article/Delete/' + data.Id, {}, function (result) {
                    if (result.Result) {
                        layer.msg('你好狠，居然要删除我！！！');
                        obj.del();
                        layer.close(index);
                    } else {
                        layer.msg(result.Message, { icon: 5 });
                    }
                });
            });
        } else if (obj.event === 'edit') {
            layer.open({
                id: 'layer-articleClass',
                type: 2,
                title: '编辑文章',
                shade: 0.4,
                shadeClose: true,
                area: ['800px', '500px'],
                anim: 1,
                skin: 'pm-layer-login',
                content: "/Admin/Article/Edit/" + data.Id
            });
        }
    });
    $('#addArticle').on('click',function () {
        var val = $('select[name=articleClass]').val();
        layer.open({
            id: 'layer-articleClass',
            type: 2,
            title: '添加文章',
            shade: 0.4,
            shadeClose: true,
            area: ['800px', '500px'],
            anim: 1,
            skin: 'pm-layer-login',
            content: "/Admin/Article/Add?ArticlassId=" + val
            });
     });
    exports('article', {});
});