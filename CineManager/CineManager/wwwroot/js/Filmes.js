function GeneroModal() {
    var genFilme = $.ajax({
        url: 'GenerosFilme',
        data: {
        }
    });
    genFilme.done(function (data) {
        $('#divPartial').html(data);
        $('#ShowModal').modal('show');
    });
}

function ArmazenarGeneros() {
    var _generosJoin = [];
    $('input[name="cbxGeneros"]:checked').each(function (index) {
        _generosJoin.push(parseInt($(this).val()));
        console.log($(this).val());
    });
    $("#generosIds").val(_generosJoin.join(","));
    $('#ShowModal').modal('hide');
}
$('#genSave').click(ArmazenarGeneros);
