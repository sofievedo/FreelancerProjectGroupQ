

    //Källa: https://www.youtube.com/watch?v=XVbRcLAmK4U & https://www.c-sharpcorner.com/UploadFile/4d9083/creating-simple-cascading-dropdownlist-in-mvc-4-using-razor/ 

        $(document).ready(function () {
            $("#RoleId").change(function () {
                $.get("/Freelancer_Competence/GetCompetenceList", { RoleId: $("#RoleId").val() }, function (competence) {
                    $("#CompetenceId").empty();
                    $.each(competence, function (index, row) {
                        $("#CompetenceId").append("<option value='" + row.Id + "'>" + row.CompetenceName + "</option>");
                    });
                });
            })
        });
