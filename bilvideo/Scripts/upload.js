$(document).ready(function () {
    var fileupload = document.getElementById("FileUpload1");
    var filePath = document.getElementById("spnFilePath");
    var button = document.getElementById("btnFileUpload");
    var cmntBtn = document.getElementById("cmntBtn");
    var cmntText = document.getElementById("cmntText");
    var videono = document.getElementById("video-no");
    if (button !== null && fileupload !== null) {
        button.onclick = function () {
            fileupload.click();
        };
        fileupload.onchange = function () {
            var fileName = fileupload.value.split('\\')[fileupload.value.split('\\').length - 1];
            filePath.innerHTML = "<b>Selected File: </b>" + fileName;
            $('#iptal i').click(function () {
                window.location.reload();
            });
            var videopath = document.getElementById('video-path');
            if (videopath !== null)
                videopath.value = fileupload.files[0].mozFullPath;
        };
    }
    if (cmntText !== null) {
        cmntText.onclick = function () {
            cmntText.innerHTML = "";
        };
    }
    if (cmntBtn !== null) {
        var firstCmntText = cmntText.value;
        cmntBtn.onclick = function () {
            var cmnt = cmntText.value;
            var memberid = 0;
            $.ajax({
                type: "GET",
                url: "/Home/GetMemberId/",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data !== 0) {
                        memberid = data;
                        if (cmnt !== firstCmntText && memberid !== 0) {
                            var model = {
                                comment: cmnt,
                                videoNo: videono.innerHTML,
                                memberId: memberid
                            };
                            $.ajax({
                                url: '/api/Comment/',
                                type: 'POST',
                                data: model,
                                success: function (data) {
                                    $.ajax({
                                        url: 'http://127.0.0.1:5000/api/getcomments',
                                        type: 'GET',
                                        dataType: 'json',
                                        success: function (data) {
                                            //alert(data.value);
                                            //window.location.reload();
                                            //alert(data);
                                            window.location = "/Video/Watch/" + data;
                                        }
                                    });
                                    //var comment = {
                                    //    commentNo: 1
                                    //};
                                    //$.ajax({
                                    //    url: 'http://127.0.0.1:5000/api/postcomments',
                                    //    type: 'POST',
                                    //    dataType: 'json',
                                    //    data: comment,
                                    //    success: function (data) {
                                    //        for (var i = 0; i < data.comments.length; i++) {
                                    //            alert(data.comments[i].comment);
                                    //        }
                                    //    }
                                    //});
                                }
                            });
                        }
                    }
                    else
                        window.location = "/giris-yap";
                },
                error: function (data) { }
            });
        };
    }
    if (document.getElementById('FileUpload1') !== null) {
        document.getElementById('FileUpload1').addEventListener('change', function () {
            //$('.u-area').empty();
            //var html = '@using (Html.BeginForm("Upload", "Video", FormMethod.Post, new{enctype="multipart/form-data", @class="login100-form validate-form", autocomplete="off"})){<div class="col-md-3" id="video-image"> <img src="~/Content/Photos/fotoyok.jpg" id="yuklenen"/><span id="video-name"></span> </div><div class="col-md-6"> <span>Video Başlığı</span>@Html.TextBoxFor(model=>model.videoTitle,new{placeholder="Video Başlığı"}) <span>Video Açıklaması</span>@Html.TextAreaFor(model=>model.videoText,new{cols="50", rows="5", placeholder="Video Açıklaması", maxlength="100", style="resize:vertical;"}) <div class="col-md-5"><span>Video Kategorisi</span>@Html.DropDownListFor(model=> model.content, new SelectList(ContentNames))</div><div class="col-md-7"><input type="submit" value="Paylaş"/> </div></div><div class="col-md-2" id="iptal"> <i class="cv cvicon-cv-cancel"></i> </div>}';
            //$('.u-area').append(html);
            var element;
            var divhdn = document.createElement("div");
            divhdn.className = "hidden-xs";
            var img = document.createElement("img");
            img.setAttribute('src', '/Content/Photos/upload-background.png');
            divhdn.appendChild(img);
            var uppage = document.getElementById("page-upload");
            uppage.insertBefore(divhdn, uppage.firstChild);
            $('div[class="u-area"]').each(function (index, item) {
                if (parseInt($(item).data('index')) === 1) {
                    $(item).css('display', 'none');
                    element = $('#FileUpload1').detach();
                }
                else if (parseInt($(item).data('index')) === 2) {
                    $(item).css('display', 'table');
                }
            });
            $('#video-form').append(element);
            //$('.u-area').css('display', 'table');
            var file = event.target.files[0];
            var filename = file.name;
            var fileReader = new FileReader();
            if (file.type.match('image')) {
                fileReader.onload = function () {
                    var img = document.createElement('img');
                    img.src = fileReader.result;
                    document.getElementById('video-image').appendChild(img);
                };
                fileReader.readAsDataURL(file);
            } else {
                fileReader.onload = function () {
                    var blob = new Blob([fileReader.result], { type: file.type });
                    var url = URL.createObjectURL(blob);
                    var video = document.createElement('video');
                    var timeupdate = function () {
                        if (snapImage()) {
                            video.removeEventListener('timeupdate', timeupdate);
                            video.pause();
                        }
                    };
                    video.addEventListener('loadeddata', function () {
                        if (snapImage()) {
                            video.removeEventListener('timeupdate', timeupdate);
                        }
                    });
                    var snapImage = function () {
                        var canvas = document.createElement('canvas');
                        canvas.width = video.videoWidth;
                        canvas.height = video.videoHeight;
                        canvas.getContext('2d').drawImage(video, 0, 0, canvas.width, canvas.height);
                        var image = canvas.toDataURL();
                        var success = image.length > 100000;
                        if (success) {
                            //var img = document.createElement('img');
                            var img = document.getElementById('yuklenen');
                            img.src = image;
                            document.getElementById('thumbnail').appendChild(img);
                            $('#video-name').html(filename);
                            URL.revokeObjectURL(url);
                        }
                        return success;
                    };
                    video.addEventListener('timeupdate', timeupdate);
                    video.preload = 'metadata';
                    video.src = url;
                    // Load video in Safari / IE11
                    video.muted = true;
                    video.playsInline = true;
                    video.play();
                };
                fileReader.readAsArrayBuffer(file);
            }
        });
    }
});