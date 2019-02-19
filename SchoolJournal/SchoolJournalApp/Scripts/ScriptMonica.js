let today = new Date().toISOString().substr(0, 10);
document.querySelector("#today").value = today;

$(document).ready(function () {
    getSubjects();
});

function getSubjects() {
    $.ajax({
        url: "/Persons/GetAllSubjects",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $("#schoolSubject").autocomplete({
                source: data
            });
        },
        error: function (error) {
            alert("Error")
        }
    });

}