var FollowService = function () {

    var createfollow = function (artistid, done, fail) {
        console.log("artistid",artistid)
        $.post("/api/Followings/", { "FolloweeId":artistid })
            .done(done)
            .fail(fail)

    };
    var deletefollow = function (artistid, done, fail) {
        $.ajax({
            url: "/api/Followings/" + artistid,
            method: "DELETE"
        })
            .done(done)
            .fail(fail)
    };


    return {
        createfollow: createfollow,
        deletefollow: deletefollow
    }



}()