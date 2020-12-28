$(function () {
    $('#AddtoNote').click(function () {
        var title = $("#title").val();
        var content = $("#txtcontent").val();
        var category = $("#categoryid").val();

        if (user == "") {
            alert("Kullanıcı Girişi Yapınız!");
        }
        else {
            if (category == "") {
                alert("Kategori seçiniz!")
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
                        alert("Not eklendi.");
                        location.reload();
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
            success: function () {
                alert("Not Güncellendi.")
                location.reload();

            },
            error: function (data) {
                alert(data)
            }
        });
    })
});