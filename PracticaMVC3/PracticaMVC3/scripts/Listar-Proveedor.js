$(document).ready(function()
{
	$("#btn-buscar").click(function(){AjaxLlamada();});
});
function AjaxLlamada()
{
    $.ajax(
    {
        url:"/Proveedor/BuscarPartial",
        data:{parametroBusqueda:$("txt-prueba").val()},
        succsses:function()
        {
            $("#div-resultado").html(data);
        },
        error:function(error)
        {
            $("div-resutado").html('<p>Se produjo un error'+error+'/p>');
        }
	
    });
}