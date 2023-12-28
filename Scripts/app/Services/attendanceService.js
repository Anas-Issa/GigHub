var AttendanceService = function () {
    var createAttend = function (gigid, done, fail) {
        $.post("/api/Attendences", { "gigid": gigid })
            .done(done)
            .fail(fail)

    }
    var deleteAttend = function (gigid, done, fail) {
        $.ajax({
            url: "/api/Attendences/" + gigid,
            method: "DELETE"
        })
            .done(done)
            .fail(fail)

    }
    return {
        createAttend: createAttend,
        deleteAttend: deleteAttend
    }
}();


//var AttendanceService = function () {
//    var createAttend = function (gigid, done, fail) {
//        $.post("/api/Attendences", { "gigid": gigid })
//            .done(done)
//            .fail(fail)

//    }
//    var deleteAttend = function (gigid, done, fail) {
//        $.ajax({
//            url: "/api/Attendences/" + gigid,
//            method: "DELETE"
//        })
//            .done(done)
//            .fail(fail)

//    }
//    return {
//        createAttend: createAttend,
//        deleteAttend: deleteAttend
//    }
//}();
