function BorrarRegistro(){
	alert();
}
function BuscarPorLetra(){
	$('#txt-prueba').keyup(function() {
    var value = $(this).val();
    var exp = new RegExp('^' + value, 'i');

    $('.producto').each(function() {
      var nombre =$(this).find("td.nombre").html();
	if(nombre.indexOf(value)>0){
		$(this).show();
	}
	else
		$(this).hide();

    });
});​
}