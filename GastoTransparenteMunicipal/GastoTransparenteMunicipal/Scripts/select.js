(function ($, window) {
    var arrowWidth = 30;

    $.fn.resizeselect = function (settings) {
        return this.each(function () {

            $(this).change(function () {
                var $this = $(this);

                // crear elemento de prueba
                var text = $this.find("option:selected").text();
                var $test = $("<span>").html(text).css({
                    "font-size": $this.css("font-size"), // asegura el mismo tamaño de texto
                    "visibility": "hidden"               // previene el FOUC
                });


                // agregar al padre, obtener ancho y salir
                $test.appendTo($this.parent());
                var width = $test.width();
                $test.remove();

                // establecer ancho de selección
                $this.width(width + arrowWidth);
                $this.className = "blue";
                // ejecutar al inicio
                
                switch (text) {
                    case "Municipio Total":
                        $("select").removeClass("muntotal admmunicipal salud educacion cementerio");
                        $("select").addClass("muntotal");
                        break;
                    case "Adm. y Serv. Municipal":
                        $("select").removeClass("muntotal admmunicipal salud educacion cementerio");
                        $("select").addClass("admmunicipal");
                        break;
                    case "Salud":
                        $("select").removeClass("muntotal admmunicipal salud educacion cementerio");
                        $("select").addClass("salud");
                        break;
                    case "Educación":
                        $("select").removeClass("muntotal admmunicipal salud educacion cementerio");
                        $("select").addClass("educacion");
                        break;
                    case "Cementerio":
                        $("select").removeClass("muntotal admmunicipal salud educacion cementerio");
                        $("select").addClass("cementerio");
                        break;
                }


            }).change();

        });
    };

    // run by default
    $("select.resizeselect").resizeselect();

})(jQuery, window);