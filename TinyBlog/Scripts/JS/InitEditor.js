$(function () {
    var textarear = document.getElementById("blogcontent");
    var editor = new wangEditor(textarea);
    editor.config.menu = [
        'source',
        '|',
        'bold',
        'underline',
        'italic',
        'eraser',
        'forecolor',
        'bgcolor',
        '|',
        'quote',
        'fontfamily',
        'fontsize',
        'head',
        'unorderlist',
        'orderlist',
        'alignleft',
        'aligncenter',
        'alignright',
        '|',
        'link',
        'unlink',
        'emotion',
        '|',
        'img',
        'insertcode',
        '|',
        'undo',
        'redo',
        'fullscreen'
    ];

    editor.config.uploadImgUrl = "/Admin/BlogArticle/upload";
    editor.config.uploadImgFileName = "imgFile";
    editor.create();
});

function afterAddBlog(data) {
    var serverdata = data.split(":");
    if (serverdata[0] == "ok") {
        alert(serverdata[1]);
        window.location.reload();
    }
};