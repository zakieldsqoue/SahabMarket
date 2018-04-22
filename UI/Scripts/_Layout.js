(function () {
    var _Layout = {


        page_Int: function () {
           
        }
        , page_Load: function () {
            $.get(API.APIURL + "Categories", function (data) {
                for (var i = 0; i < data.length; i++) {
                    $("#Menu").append("<li><a href='/products?CatID=" + data[i].CatID + "&CatName=" + data[i].CatName+"'>" + data[i].CatName + "</a></li>");
                }
                
            });
        },
        Page_Event: function () {

        },
        Page_Start: function () {
            _Layout.page_Int();
            _Layout.page_Load();
            _Layout.Page_Event();

        }



    }
    $(document).ready(function () {
        _Layout.Page_Start();
        $(".dropdown").hover(
            function () {
                $('.dropdown-menu', this).stop(true, true).slideDown("fast");
                $(this).toggleClass('open');
            },
            function () {
                $('.dropdown-menu', this).stop(true, true).slideUp("fast");
                $(this).toggleClass('open');
            }
        );
        $().UItoTop({ easingType: 'easeOutQuart' });
       

        if (~window.location.search.indexOf('reset=true')) {
            paypal.minicart.reset();
        }
        //script-for sticky-nav
        var navoffeset = $(".agileits_header").offset().top;
        $(window).scroll(function () {
            var scrollpos = $(window).scrollTop();
            if (scrollpos >= navoffeset) {
                $(".agileits_header").addClass("fixed");
            } else {
                $(".agileits_header").removeClass("fixed");
            }
        });
        $(".scroll").click(function (event) {
            event.preventDefault();
            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
        });
    });
})();

