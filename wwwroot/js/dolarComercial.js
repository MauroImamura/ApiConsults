$(document).ready(function(){
    var info = $("#ctt").val();
    var data = $("#dt").val();
    console.log(data);
    console.log(info);
    MostrarCotacao(data,info);
})

function MostrarCotacao(data,info){
    var arr = $.parseJSON(info);
    var v = arr.value;
    if (v.length == 0) {
        $("#compra").val("Sem informação");
        $("#venda").val("Sem informação");
    }
    else {
        var cotCompra = v[0].cotacaoCompra;
        var cotVenda = v[0].cotacaoVenda;
        if (cotCompra != "") {
            $("#compra").val(cotCompra);
        }
        else {
            $("#compra").val("Sem informação");
        }
        if (cotVenda != "") {
            $("#venda").val(cotVenda);
        }
        else {
            $("#venda").val("Sem informação");
        }
    }
}

function AtualizaResultado(){
    var cc = $("#compra").val();
    var vc = $("#valorComprado").val();
    var cResult = cc*vc;
    $("#totalComprado").val(cResult);

    var cv = $("#venda").val();
    var vv = $("#valorVendido").val();
    var vResult = cv * vv;
    $("#totalVendido").val(vResult);
}

$("#valorComprado").change(function(){
    AtualizaResultado();
})

$("#valorVendido").change(function () {
    AtualizaResultado();
})