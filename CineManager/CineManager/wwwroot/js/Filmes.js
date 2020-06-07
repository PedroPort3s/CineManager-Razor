$(document).ready(function () {
    GeneroModal();
    TipoFilmeModal();
});

//Filme Generos

function GeneroModal() {
    var genFilme = $.ajax({
        url: 'GenerosFilme',
        data: {
        }
    });
    genFilme.done(function (data) {
        $('#divPartial').html(data);
    });
}
function GeneroModalOpen() {   
   $('#ShowModal').modal('show');   
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

//TipoFilme

function TipoFilmeModal() {
    var tipoFilme = $.ajax({
        url: 'TiposFilme',
        data: {
        }
    });
    tipoFilme.done(function (data) {
        $('#divPartialTF').html(data);
    });
}
function TipoFilmeModalOpen() {   
   $('#ShowModalTF').modal('show');   
}

function ArmazenarTipos() {
    var _tiposJoin = [];
    $('input[name="cbxTF"]:checked').each(function (index) {
        _tiposJoin.push(parseInt($(this).val()));
        console.log($(this).val());
    });
    $("#tiposIds").val(_tiposJoin.join(","));
    $('#ShowModalTF').modal('hide');
}
$('#tipoSave').click(ArmazenarTipos);
