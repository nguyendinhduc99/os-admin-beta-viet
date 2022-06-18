// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var Upload = function (file) {
    this.file = file;
};

Upload.prototype.getType = function () {
    return this.file.type;
};
Upload.prototype.getSize = function () {
    return this.file.size;
};
Upload.prototype.getName = function () {
    return this.file.name;
};
Upload.prototype.doUpload = function (successCallback, errorCallback) {
    var that = this;
    var formData = new FormData();

    // add assoc key values, this will be posts values
    formData.append("file", this.file, this.getName());
    formData.append("upload_file", true);

    $.ajax({
        type: "POST",
        url: "/api/files/upload",
        xhr: function () {
            var myXhr = $.ajaxSettings.xhr();
            if (myXhr.upload) {
                myXhr.upload.addEventListener('progress', that.progressHandling, false);
            }
            return myXhr;
        },
        success: successCallback,
        error: errorCallback,
        async: true,
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        timeout: 60000
    });
};
Upload.prototype.doUploadPromise = function () {
    var that = this;
    
    return new Promise((resolve, reject) => {
        const xhr = new XMLHttpRequest();
        var formData = new FormData();

        // add assoc key values, this will be posts values
        formData.append("file", that.file, that.getName());
        formData.append("upload_file", true);

        //xhr.responseType = 'json';
        xhr.addEventListener('load', event => resolve(xhr.responseText), false);
        xhr.addEventListener('error', event => reject(event), false);
        xhr.addEventListener('abort', event => reject(event), false);
        xhr.open('POST', "/api/files/upload", true);
        xhr.send(formData);
    });
};

Upload.prototype.progressHandling = function (event) {
    var percent = 0;
    var position = event.loaded || event.position;
    var total = event.total;
    var progress_bar_id = "#progress-wrp";
    if (event.lengthComputable) {
        percent = Math.ceil(position / total * 100);
    }
    // update progressbars classes so it fits your code
    $(progress_bar_id + " .progress-bar").css("width", +percent + "%");
    $(progress_bar_id + " .status").text(percent + "%");
};


let ckeditor5Options = {

    toolbar: {
        items: [
            'heading',
            'fontColor',
            'fontBackgroundColor',
            'fontSize',
            'highlight',
            '|',
            'bold',
            'italic',
            'link',
            'bulletedList',
            'numberedList',
            '|',
            'outdent',
            'indent',
            'alignment',
            'underline',
            '|',
            'blockQuote',
            'insertTable',
            'imageUpload',
            'mediaEmbed',
            'undo',
            'redo'
        ]
    },
    language: 'vi',
    table: {
        contentToolbar: [
            'tableColumn',
            'tableRow',
            'mergeTableCells'
        ]
    },
    licenseKey: '',

}

function showNotification(text, type = 'error', pos = 'topRight') {
    noty({
        theme: 'app-noty',
        text: text,
        type: type,
        timeout: 3000,
        layout: pos,
        closeWith: ['button', 'click'],
        animation: {
            open: 'noty-animation fadeIn',
            close: 'noty-animation fadeOut'
        }
    });
}