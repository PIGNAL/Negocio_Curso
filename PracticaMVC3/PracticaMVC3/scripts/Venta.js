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