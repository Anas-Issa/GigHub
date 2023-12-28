var FollowController = function (followservice) {
    var button;
    var init = function () {
        $(".js-follow").click(function (e) {
             button = $(e.target);
            var followeeid = button.attr("data-artistid");
            if (button.hasClass("btn-default"))
                followservice.createfollow(followeeid, done, fail)
            else if (button.hasClass("btn-info")) {
                followservice.deletefollow(followeeid, done, fail)

            }

        });
        var done = function () {
            var text = (button.text() == "follow?") ? "follow" : "follow?";
            button.toggleClass("btn-default").toggleClass("btn-info").text(text)

        };
        var fail = function () {

        }
      
    }
    return {
        init: init
    }




}(FollowService)