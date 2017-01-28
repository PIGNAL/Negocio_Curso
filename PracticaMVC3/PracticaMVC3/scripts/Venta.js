$(document).ready(function(){
    BuscarPorLetra();
});

function BorrarRegistro(){
	alert();
}
function AgregarProducto() {
    var x = document.getElementById("mySelect");
    if (x.selectedIndex >= 0) {
        var option = document.createElement("option");
        option.text = "Kiwi";
        var sel = x.options[x.selectedIndex];
        x.add(option, sel);
    }
}
function CargarDatosEnComboBox() {

}

function BuscarPorLetra(){
    $('#txt-prueba').keyup(function() {
        var value = $(this).val();
       

        $('.producto').each(function() {
            var nombre = $(this).find("td.nombre").html();
            console.log(nombre);
            console.log(value);
            console.log(nombre.indexOf(value));
            if(nombre.indexOf(value)>=0){
                $(this).show();
            }
            else
            {
                $(this).hide();
            }
        })
    })
}