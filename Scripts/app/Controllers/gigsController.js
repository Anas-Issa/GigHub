var gigsController = function (attendanceService) {


    var init = function () {
        $(".js-toggle-attendence").click(toggleAttendance);
       // $(container).on(container,"click", ".js-toggle-attendence", toggleAttendance)

    }
    var button;
    var toggleAttendance = function (e) {
        button = $(e.target);
        var gigid = button.attr("data-gigid")
        console.log(button.attr("data-gigid"));
        if (button.hasClass("btn-default"))
            attendanceService.createAttend(gigid, done, fail);
        else
            attendanceService.deleteAttend(gigid, done, fail);


    };
    var fail = function () {
        alert("Something get wrong!")
    };
    var done = function () {
        var text = (button.text() == "Going") ? "Going?" : "Going";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };
    //var createAttendance = function () {
    //    $.post("/api/Attendences", { "gigid": button.attr("data-gigid") })
    //        .done(done)
    //        .fail(fail)

    //};
    //var deleteAttendance = function () {
    //    $.ajax({
    //        url: "/api/Attendences/" + button.attr("data-gigid"),
    //        method: "DELETE"
    //    })
    //        .done(done)
    //        .fail(fail)
    //};
    return {
        init: init
    }
}(AttendanceService)
//var gigsController = function (attendanceservice) {
//    var button;
//    console.log("sssss");

//    var init = function () {
//        $(".js-toggle-attendence").click(toggleAttendance)



//        var toggleAttendance = function (e) {
//            console.log("sasasa");
//            button = $(e.target);
//            var gigid = button.attr("data-gigid")
//            console.log(button.attr("data-gigid"));
//            if (button.hasClass("btn-default"))
//                attendanceservice.createAttend(gigid, done, fail)

//            else
//                attendanceservice.deleteAttend(gigid, done, fail)

//        }

//        var fail = function () {
//            alert("Something get wrong!")
//        }
//        var done = function () {
//            var text = (button.text() == "Going") ? "Going?" : "Going";
//            button.toggleClass("btn-info").toggleClass("btn-default").text(text);
//        }

//    }
//    return {
//        init: init
//    }
//}(AttendanceService)
