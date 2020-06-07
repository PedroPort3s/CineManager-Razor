//Filmes Genero Edit

$(document).ready(function () {
    GeneroModalEdit($('#IdFilme').val());
    TipoFilmeModalEdit($('#IdFilme').val());    
});

function GeneroModalEdit(id) {
    var genFilmeEdit = $.ajax({
        url: '/Filme/GenerosFilmeEdit',
        data: {
            id: id
        }
    });
    genFilmeEdit.done(function (data) {
        $('#divPartialEdit').html(data);
    });
}
function GeneroModalOpenEdit() {
    $('#ShowModalEdit').modal('show');
}

function ArmazenarGenerosEdit() {
    var _generosJoin = [];
    $('input[name="cbxGenerosEdit"]:checked').each(function (index) {
        _generosJoin.push(parseInt($(this).val()));
        console.log($(this).val());
    });
    $("#generosIdsEdit").val(_generosJoin.join(","));
    $('#ShowModalEdit').modal('hide');
}
$('#genSaveEdit').click(ArmazenarGenerosEdit);

// Filmes TipoFilme Edit

function TipoFilmeModalEdit(id) {
    var tipoFilmeEdit = $.ajax({
        url: '/Filme/TiposFilmeEdit',
        data: {
            id: id
        }
    });
    tipoFilmeEdit.done(function (data) {
        $('#divPartialEditTF').html(data);
    });
}
function TipoFilmeModalOpenEdit() {
    $('#ShowModalEditTF').modal('show');
}

function ArmazenarTiposEdit() {
    var _tiposJoin = [];
    $('input[name="cbxTipoEdit"]:checked').each(function (index) {
        _tiposJoin.push(parseInt($(this).val()));
        console.log($(this).val());
    });
    $("#tiposIdsEdit").val(_tiposJoin.join(","));
    $('#ShowModalEditTF').modal('hide');
}
$('#tipoSaveEdit').click(ArmazenarTiposEdit);