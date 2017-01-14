$(document).ready(function()
{
    $("#btn-buscar").click(function () {
        LlamadaAjax();
    });
});
function LlamadaAjax()
{
    $.ajax(
    {
        url: "/Persona/BuscarPartial",
        data: {parametroBusqueda:$("#txt-prueba").val()},
        success: function (data)
        {
            console.log(data);
            $("#div-resultado").html(data);
        },
        error: function (error)
        {
            console.log(error);
            $("#div-resultado").html('<p>Le Produjo un Error' + error + '</p>');
        }
    });
};