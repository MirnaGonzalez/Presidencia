document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var initialLocaleCode = 'es';

    var calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        initialDate: '2020-09-12',
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
            //$("[id*='Button1']").trigger("click");
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
            if (confirm('Are you sure you want to delete this event?')) {
                arg.event.remove()
            }
        },
        editable: true,
        dayMaxEvents: true, // allow "more" link when too many events
        events: {
            url: 'http://serviciowebpjhgo.azurewebsites.net/Api/CitasAP',
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

    calendar.render();
});