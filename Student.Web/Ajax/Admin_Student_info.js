// 通过id获取修改的信息,因为数据原因不在asp中使用
/*
function edit_Adm_Studentinfo(id) {
    $.ajax({
        type: "get",
        url: "Adm_StudentInfo.aspx",
        data: { "id": id, "op": "edit" },
        success: function (data) {
            alert("" + data);
            var list = eval(data)

            $("#edit_id").val(list[0].Stu_id);
            $("#edit_name").val(list[0].Stu_name);
            $("#edit_sex").val(list[0].Stu_sex);
            $("#edit_birth").val(list[0].Stu_birth);
            $("#edit_edu").val(list[0].Stu_edu);
            $("#edit_tel").val(list[0].Stu_tel);
            $("#edit_pwd").val(list[0].Stu_pwd);
            $("#edit_address").val(list[0].Stu_address);
            $("#edit_origin").val(list[0].Stu_origin);
            $("#edit_time").val(list[0].Stu_time);
        }
    });
}
*/
//打开模态框
function edit_Adm() {
    $("#editDialog").modal("show");
}

