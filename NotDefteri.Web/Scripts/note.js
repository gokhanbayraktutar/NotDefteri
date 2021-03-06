﻿
$(function () {
    $('#AddtoNote').click(function () {
        var title = $("#title").val();
        var content = $("#txtcontent").val();
        var category = $("#categoryid").val();

        if (user == "") {
            swal({
                title: "Hata",
                text: "Önce Giriş Yapınız",
                icon: "error"
            });
        }
        else {
            if (category == "") {
                swal({
                    title: "Hata",
                    text: "Kategori Seçiniz",
                    icon: "error"
                });
            } else {
                $.ajax({
                    async: true,
                    type: "POST",
                    contentType: false,
                    processData: false,
                    data: JSON,
                    dataType: 'html',
                    url: '/Note/NoteAdd/?title=' + title + "&content=" + content + "&categoryid=" + category,
                    success: function () {
                        $("#tbl").load(" #tbl")
                        swal({
                            title: "Başarılı",
                            text: "Not eklendi",
                            icon: "success"
                        });

                        $("#title").val("");
                        $("#txtcontent").val("");
                    },
                    error: function () {
                        alert("Hata oluştu!")
                    }
                });
            }
        }
    })
});