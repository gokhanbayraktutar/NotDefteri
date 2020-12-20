$(function () {
    $(document).ready(function () {
        $("#btnRegister").click(function () {
            var UserName = $("#UserName").val()
            var Email = $("#Email").val()
            var Password = $("#Password").val()
            $.ajax({
                url: '/Account/Register',
                type: 'POST',
                dataType: 'json',
                data: { UserName: UserName, Email: Email, Password: Password },
                success: function (data) {
                    debugger
                },
            });
        })
    });
});