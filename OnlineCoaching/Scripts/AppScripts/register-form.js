(function () {
    $('#is-coach-checkbox').change(function () {
        if (this.checked) {
            this.setAttribute("value", "true");
            $("#coach-form").show();
            //setRequiredFields("true");
        }
        else {
            this.setAttribute("value", "false");
            $("#coach-form").hide();
            //setRequiredFields("false");
        }
    });
})()

function setRequiredFields(areRequired) {
    $("#Age").attr("data-val", areRequired);
    $("#AboutMe").attr("data-val", areRequired);
    if (areRequired==="true") {
        $("#Age").attr("data-val-required", "Age is required");
        $("#AboutMe").attr("data-val-required", "Skills are required");
    }
}