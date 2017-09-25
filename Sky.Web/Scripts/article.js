layui.define(['table','form'], function (exports) {
    var table = layui.table;
    var form = layui.form;
    //执行渲染
    table.render({
        elem: '#demo' //指定原始表格元素选择器（推荐id选择器）
        , height: 260 //容器高度
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
        , skin: 'line' //行边框风格
        , even: true //开启隔行背景
        , cols: [[
            {
                field: 'AddTime', aligh: 'center', title: '发表时间', width: 100
            },
            {
                field: 'Title', aligh: 'center', title: '标题', width: 100
            },
            {
                field: 'Author', aligh: 'center', title: '作者', width: 100
            },
            {
                field: 'MyArticleClass.Name', aligh: 'center', title: '分类', width: 100
            },
            {
                field: 'IsTop', aligh: 'center', title: '置顶', templet: '#IsTopTpl', width: 100
            },
            {
                field: 'IsRecommend', aligh: 'center', title: '推荐', templet: '#IsRecommendTpl', width: 100
            },
            {
                aligh:'center', width: 100, toolbar: '#barDemo'
            }
        ]]
    });
    //var $ = layui.jquery,
    //    layer = layui.layer;
    //页数据初始化
    //currentIndex：当前也下标
    //pageSize：页容量（每页显示的条数）
    //function initilData(currentIndex, pageSize) {
    //    var index = layer.load(1);
    //    //模拟数据
    //    var data = new Array();
    //    for (var i = 0; i < 30; i++) {
    //        data.push({ id: i + 1, time: '2017-3-26 15:56', title: '不落阁后台模板源码分享', author: 'ShaDaMeng', category: 'Web前端' });
    //    }
    //    //模拟数据加载
    //    setTimeout(function () {
    //        layer.close(index);
    //        //计算总页数（一般由后台返回）
    //        pages = Math.ceil(data.length / pageSize);
    //        //模拟数据分页（实际上获取的数据已经经过分页）
    //        var skip = pageSize * (currentIndex - 1);
    //        var take = skip + Number(pageSize);
    //        data = data.slice(skip, take);
    //        var html = '';  //由于静态页面，所以只能作字符串拼接，实际使用一般是ajax请求服务器数据
    //        html += '<table style="" class="layui-table" lay-even>';
    //        html += '<colgroup><col width="180"><col><col width="150"><col width="180"><col width="90"><col width="90"><col width="50"><col width="50"></colgroup>';
    //        html += '<thead><tr><th>发表时间</th><th>标题</th><th>作者</th><th>类别</th><th colspan="2">选项</th><th colspan="2">操作</th></tr></thead>';
    //        html += '<tbody>';
    //        //遍历文章集合
    //        for (var i = 0; i < data.length; i++) {
    //            var item = data[i];
    //            html += "<tr>";
    //            html += "<td>" + item.time + "</td>";
    //            html += "<td>" + item.title + '[' + item.id + ']' + "</td>";
    //            html += "<td>" + item.author + "</td>";
    //            html += "<td>" + item.category + "</td>";
    //            html += '<td><form class="layui-form" action=""><div class="layui-form-item" style="margin:0;"><input type="checkbox" name="top" title="置顶" value="' + item.id + '" lay-filter="top" checked /></div></form></td>';
    //            html += '<td><form class="layui-form" action=""><div class="layui-form-item" style="margin:0;"><input type="checkbox" name="top" title="推荐" value="' + item.id + '" lay-filter="recommend" checked /></div></form></td>';
    //            html += '<td><button class="layui-btn layui-btn-small layui-btn-normal" onclick="layui.datalist.editData(\'' + item.id + '\')"><i class="layui-icon">&#xe642;</i></button></td>';
    //            html += '<td><button class="layui-btn layui-btn-small layui-btn-danger" onclick="layui.datalist.deleteData(\'' + item.id + '\')"><i class="layui-icon">&#xe640;</i></button></td>';
    //            html += "</tr>";
    //        }
    //        html += '</tbody>';
    //        html += '</table>';
    //        html += '<div id="' + laypageId + '"></div>';

    //        $('#dataContent').html(html);

    //        form.render('checkbox');  //重新渲染CheckBox，编辑和添加的时候
    //        $('#dataConsole,#dataList').attr('style', 'display:block'); //显示FiledBox

    //        laypage({
    //            cont: laypageId,
    //            pages: pages,
    //            groups: 8,
    //            skip: true,
    //            curr: currentIndex,
    //            jump: function (obj, first) {
    //                var currentIndex = obj.curr;
    //                if (!first) {
    //                    initilData(currentIndex, pageSize);
    //                }
    //            }
    //        });
    //        //该模块是我定义的拓展laypage，增加设置页容量功能
    //        //laypageId:laypage对象的id同laypage({})里面的cont属性
    //        //pagesize当前页容量，用于显示当前页容量
    //        //callback用于设置pagesize确定按钮点击时的回掉函数，返回新的页容量
    //        layui.pagesize(laypageId, pageSize).callback(function (newPageSize) {
    //            //这里不能传当前页，因为改变页容量后，当前页很可能没有数据
    //            initilData(1, newPageSize);
    //        });
    //    }, 500);
    //}

    ////监听置顶CheckBox
    //form.on('checkbox(top)', function (data) {
    //    var index = layer.load(1);
    //    setTimeout(function () {
    //        layer.close(index);
    //        if (data.elem.checked) {
    //            data.elem.checked = false;
    //        }
    //        else {
    //            data.elem.checked = true;
    //        }
    //        layer.msg('操作失败，返回原来状态');
    //        form.render();  //重新渲染
    //    }, 300);
    //});
    ////监听推荐CheckBox
    //form.on('checkbox(recommend)', function (data) {
    //    var index = layer.load(1);
    //    setTimeout(function () {
    //        layer.close(index);
    //        layer.msg('操作成功');
    //    }, 300);
    //});
    //监听工具栏
    table.on('tool(demo)', function (obj) {
        var data = obj.data;
        if (obj.event === 'detail') {
            layer.msg('ID：' + data.id + ' 的查看操作');
        } else if (obj.event === 'del') {
            layer.confirm('真的删除行么', function (index) {
                obj.del();
                layer.close(index);
            });
        } else if (obj.event === 'edit') {
            layer.alert('编辑行：<br>' + JSON.stringify(data))
        }
    });
    exports('article', {});
});