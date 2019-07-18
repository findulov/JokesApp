window.demo = {
    scrollToTop: function () {
        $('html,body').animate({
            scrollTop: 0
        }, 1200);
    },
    showMessage: function (message) {
        alert(message);
    }
};