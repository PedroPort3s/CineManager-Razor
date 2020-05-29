jQuery(function ($) {
    $("input[id='txtCep']").change(function () {
        var cep_code = $(this).val();
        if (cep_code.length <= 0) return;
        $.get("https://apps.widenet.com.br/busca-cep/api/cep.json", { code: cep_code }, function (result) {
            if (result.status == 200) {
                $("input[id='txtCep']").val(result.code);
                $("input[id='txtEstado']").val(result.state);
                $("input[id='txtCidade']").val(result.city);
                $("input[id='txtBairro']").val(result.district);
                $("input[id*='txtEndereco']").val(result.address);
            }
            else {
                alert(result.message || "Houve um erro.");
                return;
            }
        });
    });
});