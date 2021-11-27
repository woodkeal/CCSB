var routeURL = location.protocol + "//" + location.host;
$(document).ready(function () {
    $("#appointmentDate").kendoDateTimePicker({
        value: new Date(),
        dateInput: false
    })
    InitializeCalendar();
});
var calendar;
function InitializeCalendar() {
    try {
        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) {
            calendar = new FullCalendar.Calendar(calendarEl, {
                locale: 'nl',
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                selectable: true,
                weekNumbers: true,
                editable: false,
                select: function (event) {
                    onShowModal(event, null);
                },
                eventDisplay: 'block',
                events: function (fetchInfo, succesCallback, failureCallback) {
                    $.ajax({
                        url: routeURL + '/api/AppointmentApi/GetCalendarData',
                        type: 'GET',
                        dataType: 'json',
                        success: function (response) {
                            var events = [];
                            if (response.status === 1) {
                                $.each(response.dataenum, function (i, data) {
                                    events.push({
                                        title: data.title,
                                        description: data.description,
                                        start: data.appointmentDate,
                                        textColor: "black",
                                        id: data.id,
                                    });
                                })
                            }
                            succesCallback(events);
                        },
                        error: function (xhr) {
                            $.notify("Error", "error")
                        }

                    });
                },
                eventClick: function (info) {
                    getEventDetailsByEventId(info.event);
                }
            });
            calendar.render();
        }
    }
    catch (e) {
        alert(e);
    }
}

function onShowModal(obj, isEventDetail) {
    if (isEventDetail) {
        $("#title").val(obj.title);
        $("#description").val(obj.description);
        $("#appointmentDate").val(obj.appointmentDate);
        $("#ApplicationUserId").val(obj.ApplicationUserId);
    }
    else {
        var appointmentdate = obj.start.getDate() + "-" + obj.start.getMonth() + "-" +
            obj.start.getFullYear() + " " + new moment().format("HH:mm")
        $("#Id").val(obj.id);
        $("#title").val(obj.title);
        $("#description").val(obj.description);
        $("#appointmentDate").val(appointmentdate);
    }
    $("#appointmentInput").modal("show");
}

function onCloseModal() {
    $("#appointmentInput").modal("hide");
}

function onSubmitForm() {
    if (!checkValidation()) return;
    var requestData = {
        Id: parseInt($("id").val()),
        Title: $("#title").val(),
        Description: $("#description").val(),
        AppointmentDate: $("#appointmentDate").val(),
        ApplicationUserId: $("#ApplicationUserId").val(),
    }

    $.ajax({
        url: routeURL + "/api/AppointmentApi/SaveCalendarData",
        type: "POST",
        data: JSON.stringify(requestData),
        contentType: "application/json",
        success: function (response) {
            if (response.status === 1 || response.status === 2) {
                calendar.refetchEvents();
                $.notify(response.message, "succes");
                onCloseModal();
            } else {
                $.notify(response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error", "Foutje");
        }
    })
}

function checkValidation() {
    var isValid = true;
    if ($("#title").val() === undefined || $("#title").val().trim() === "") {
        isValid = false;
        $("#title").addClass("error");
    } else {
        $("#title").removeClass("error");
    }
    if ($("#appointmentDate").val() === undefined || $("#appointmentDate").val().trim() === "") {
        isValid = false;
        $("#appointmentDate").addClass("error");
    } else {
        $("#appointmentDate").removeClass("error");
    }
    return isValid;
}

function getEventDetailsByEventId(info) {
    $.ajax({
        url: routeURL + '/api/AppointmentApi/GetCalendarDataById/' + info.id,
        type: 'get',
        dataType: 'json',
        success: function (response) {
            if (response.status === 1 && response.dataenum != undefined) {
                onShowModal(response.dataenum, true);
            }
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}

function onUserChange() {
    calendar.refetchEvents();
}