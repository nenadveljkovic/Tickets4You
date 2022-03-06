
function Potvrdi(id) {
    var value = id.value;
    if (value.length < 5)
        $('#potvrdi').attr('disabled', 'disabled');
    else
        $('#potvrdi').removeAttr('disabled');
}