$(document).ready(function () {

    $("#accordion .header").click(function () {

        $(this).next().toggleClass("active");

    })

    // for dropright in catagiries
    $("#categories li").mouseenter(function () {
        $(this).children(".btn-group").addClass("show");
        $(".btn-group .btn-secondary", this).attr("aria-expanded", true);
        $(".btn-group .btn-secondary", this).next().addClass("show");
    })

    $("#categories li").mouseleave(function () {
        $(this).children(".btn-group").removeClass("show");
        $(".btn-group .btn-secondary", this).attr("aria-expanded", false);
        $(".btn-group .btn-secondary", this).next().removeClass("show");
    })


    // hot deals owl in left side navbar
    $('#hotDeals .owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        dots: false,
        items: 1,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })

    // latest owl in navbar left side
    $('#latest .owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        dots: false,
        items: 1,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })

    // testimonial owl 
    $('#testimonial .owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: false,
        dots: false,
        items: 1,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })

    // offers 60 %off owl
    $('#home #offers .owl-carousel').owlCarousel({
        loop: false,
        margin: 10,
        nav: false,
        items: 1,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })


    // shop by categories >> for categories
    $('#home #shopByCategory .sliderCategories .owl-carousel').owlCarousel({
        loop: false,
        margin: 10,
        nav: false,
        items: 4,
        dots: false,
        responsive: {
            0: {
                items: 4
            },
            600: {
                items: 4
            },
            1000: {
                items: 4
            }
        }
    })

    // shop by categories >> for products
    $('#home #shopByCategory .sliderProducts .owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        items: 4,
        dots: false,
        responsive: {
            0: {
                items: 4
            },
            600: {
                items: 4
            },
            1000: {
                items: 4
            }
        }
    })

    // on trend owl
    $('#home #onTrend .sliderProducts .owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        items: 4,
        dots: false,
        responsive: {
            0: {
                items: 4
            },
            600: {
                items: 4
            },
            1000: {
                items: 4
            }
        }
    })

    // latest blogs owl
    $('#home #latestBlog .sliderBlog .owl-carousel').owlCarousel({
        loop: true,
        margin: 30,
        nav: true,
        items: 2,
        dots: false,
        responsive: {
            0: {
                items: 2
            },
            600: {
                items: 2
            },
            1000: {
                items: 2
            }
        }
    })

    // latest products owl 
    $('#home #latestProduct .sliderProducts .owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        items: 4,
        dots: false,
        responsive: {
            0: {
                items: 4
            },
            600: {
                items: 4
            },
            1000: {
                items: 4
            }
        }
    })

    // companies owl only home page
    $('#companies .owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: false,
        items: 4,
        dots: false,
        responsive: {
            0: {
                items: 4
            },
            600: {
                items: 4
            },
            1000: {
                items: 7
            }
        }
    })

    // product details images owl only home page
    $('#productDetails .images .owl-carousel').owlCarousel({
        loop: true,
        margin: 25,
        nav: false,
        items: 4,
        autoplay: true,
        autoplayTimeout: 4000,
        autoplayHoverPause: true,
        dots: false,
        responsive: {
            0: {
                items: 4
            },
            600: {
                items: 4
            },
            1000: {
                items: 4
            }
        }
    })

    // on related owl
    $('#productDetails #related .sliderProducts .owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        items: 4,
        dots: false,
        responsive: {
            0: {
                items: 4
            },
            600: {
                items: 4
            },
            1000: {
                items: 4
            }
        }
    })






});