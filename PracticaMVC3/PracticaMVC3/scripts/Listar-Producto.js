$(document).ready(function()
{
	$("#btn-buscar").click(function(){AjaxLlamada();});
});
function AjaxLlamada()
{
	$.ajax(
	{
		url:"/Producto/BuscarPartial",
		data:{parametroBusqueda:$("#txt-prueba").val()},
		success:function()
		{
			$("div-resultado").html(data);
		},
		error:function(error)
		{
			$("div-resultado").html('<p>Se produjo un error'+error+'</p>');
		}
	});
};