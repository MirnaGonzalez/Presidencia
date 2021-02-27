document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
var initialLocaleCode = 'es';



    var calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        locale: initialLocaleCode,
        buttonIcons: false, // show the prev/next text
        weekNumbers: true,
        navLinks: true, // can click day/week names to navigate views
        editable: true,
        dayMaxEvents: true, // allow "more" link when too many events
        navLinks: true, // can click day/week names to navigate views
        selectable: true,
        selectMirror: true,
        select: function (arg) {
            var fecha = arg.start.getFullYear() + "-" + ("0" + (arg.start.getMonth() + 1)).slice(-2) + "-" + ("0" + arg.start.getDate()).slice(-2);
            var fech = arg.startStr;

            $("[id*='btnEditar']").css('visibility', 'hidden');
            $("[id*='btnEliminar']").css('visibility', 'hidden');
            $("[id*='btnGuardar']").css('visibility', 'show');
            $("[id*='txtFecha']").val(fecha);
           // $('#txtFecha').val(fech);
            $('#exampleModal').modal('show')
           // $("[id*='Button1']").trigger("click");
            //var title = prompt('Event Title:');
            //if (title) {
            //    calendar.addEvent({
            //        title: title,
            //        start: arg.start,
            //        end: arg.end,
            //        allDay: arg.allDay
            //    })
            //}
            calendar.unselect()
        },
        eventClick: function (arg) {  
            $("[id*='btnEditar']").css('visibility', 'show');
            $("[id*='btnEliminar']").css('visibility', 'show');
            $("[id*='btnGuardar']").css('visibility', 'hidden');

            var minutosInicial;
            var number = arg.event.start.getMinutes();
            var numberOutput = Math.abs(number); /* Valor absoluto del número */
            var length = number.toString().length; /* Largo del número */
            var zero = "0"; /* String de cero */

            if (2 <= length) {
                if (number < 0) {
                    minutosInicial = ("-" + numberOutput.toString());
                } else {
                    minutosInicial = numberOutput.toString();
                }
            } else {
                if (number < 0) {
                    minutosInicial = ("-" + (zero.repeat(2 - length)) + numberOutput.toString());
                } else {
                    minutosInicial = ((zero.repeat(2 - length)) + numberOutput.toString());
                }
            }

            var minutosFinal;
            var number2 = arg.event.end.getMinutes();
            var numberOutput2 = Math.abs(number2); /* Valor absoluto del número */
            var length2 = number2.toString().length; /* Largo del número */
            var zero2 = "0"; /* String de cero */

            if (2 <= length2) {
                if (number2 < 0) {
                    minutosFinal = ("-" + numberOutput2.toString());
                } else {
                    minutosFinal = numberOutput2.toString();
                }
            } else {
                if (number2 < 0) {
                    minutosFinal = ("-" + (zero2.repeat(2 - length2)) + numberOutput2.toString());
                } else {
                    minutosFinal = ((zero2.repeat(2 - length2)) + numberOutput2.toString());
                }
            }


          // var minutosInicial = arg.event.start.getMinutes();
            

            //var minutosFinal = arg.event.end.getMinutes();
            //if (minutosFinal == 0) {
            //    minutosFinal = '00';
            //}


            var HoraInicial = arg.event.start.getHours() + ':' + minutosInicial;
            var HoraFinal = arg.event.end.getHours() + ':' + minutosFinal;
            var fecha = arg.event.start.getFullYear() + "-" + ("0" + (arg.event.start.getMonth() + 1)).slice(-2) + "-" + ("0" + arg.event.start.getDate()).slice(-2) ;
            $("[id*='hiddenIdReserva']").val(arg.event.id);
            $("[id*='txtNombreEvento']").val(arg.event.title);
            $("[id*='txtFecha']").val(fecha);
            $("[id*='txtHoraInicio']").val(HoraInicial);
            $("[id*='txtHoraFinal']").val(HoraFinal);
            $("[id*='txtInformacion']").val(arg.event.extendedProps.descripcion);
            $('#exampleModal').modal('show')

          //  $("[id*='btnBucarId']").trigger("click");
            //$('#exampleModal').modal('show');
            //if (confirm('Are you sure you want to delete this event?')) {
            //    arg.event.remove()
            //}
           // $("[id*='btnGuardar']").trigger("click");
        },
        editable: true,
        dayMaxEvents: true, // allow "more" link when too many events
        events: {
            url: 'http://serviciowebpjhgo.azurewebsites.net/Api/CitasAP',
            cache: false,
            failure: function () {
                document.getElementById('script-warning').style.display = 'block'
            }
        },
        //events: function (start, end, timezone, callback) {
        //    $.ajax({
        //        type: "GET"
        //        , url: "http://serviciowebpjhgo.azurewebsites.net/Api/CitasAP"
        //        //, data: JSON.stringify({})
        //        //, contentType: "application/json; charset=utf-8"
        //        , dataType: "json"
        //        , success: function (doc) {
        //           // var ResWS = jQuery.parseJSON(doc); //Obtiene los datos de la llamada al WS y los convierte en un objeto 
        //            var ResWS = doc; //Obtiene los datos de la llamada al WS y los convierte en un objeto 
        //            var events = [];

        //           // if (ResWS.Resultado.Exito) {

        //                for (i = 0; i < ResWS.length; i++) {
        //                    evento = ResWS[i];
        //                    events.push({ start: evento.start, end: evento.end, title: evento.title, editable: false, textColor: 'white', borderColor: '#974830' });
        //                }
        //               // callback(events);
        //          // }
        //           // else {
        //          //      new PNotify({ title: 'SICA INFORMA', type: 'error', text: "El servicio web devolvio el siguiente Error: " + ResWS.Resultado.Mensaje.toString() });
        //        //    }
        //        }
        //        //En caso de que la llamada al WS haya generado un error se muestra el error 
        //        , error: function (msg) {
        //            new PNotify({ title: 'SICA INFORMA', type: 'error', text: "Error al realizar la llamada a el servicio web. Asegurese de estar conectado a la red: " + msg });
        //        }
        //    });
        //}
    });

    $('#exampleModal').on('hidden.bs.modal', function () {

        calendar.refetchEvents();

    });

    calendar.render();
});