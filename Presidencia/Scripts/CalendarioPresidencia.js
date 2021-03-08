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
            var fecha = arg.startStr;
            window.location = "ReservaPresidencia.aspx?fecha="+fecha;
            calendar.unselect()
        },
        eventClick: function (arg) {                  
            window.location = "ReservaPresidencia.aspx?key=" + arg.event.id;
          
        },
        editable: true,
        dayMaxEvents: true, // allow "more" link when too many events
        events: {
            url: 'https://serviciowebpjhgo.azurewebsites.net/api/CitasAP?esPresi=SI',
            cache: false,
            failure: function () {
                document.getElementById('script-warning').style.display = 'block'
            }
        },

    });

    $('#exampleModal').on('hidden.bs.modal', function () {

        calendar.refetchEvents();

    });

    calendar.render();
});