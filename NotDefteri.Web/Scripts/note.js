
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
    $('#UpdatetoNote').click(function () {

        var id = $("#noteid").val();
        var title = $("#edittitle").val();
        var content = $("#editcontent").val();
        var category = $("#editcategory").val();
        $.ajax({
            async: true,
            type: "POST",
            contentType: false,
            processData: false,
            dataType: 'html',
            url: '/Note/NoteEdit/?id=' + id + "&title=" + title + "&content=" + content + "&categoryid=" + category,
            success: function (data) {
                swal({
                    title: "Başarılı",
                    text: "Not Güncellendi",
                    icon: "success"
                });
                $("#nottablo").html(data);
            },
            error: function () {
                alert("Hata")
            }
        });
    })

    $('#DeletetoNote').click(function () {
        $('#mymodal').modal('show');
        var noteId = $(this).data("model-id");

        $('#hiddenNoteId').val(noteId);
    });

    $('#DeleteNote').click(function () {
        var noteId = $('#hiddenNoteId').val();

        $.ajax({
            type: "POST",
            url: '/Note/NoteRemove',
            data: { id: noteId },
            success: function (result) {
                $('#mymodal').modal('hide');
                $('#row_' + noteId).remove();

            },
            error: function () {
            }
        });
    });
});