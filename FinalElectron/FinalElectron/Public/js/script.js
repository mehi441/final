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
        autoplay: true,
        autoplaytimeout: 2000,
        autoplayhoverpause: true,
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
        loop: false,
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
        loop: false,
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
        loop: false,
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

    // detail product quantity plus

    $(".nextBtn").click(function () {
        var quantity = $('#Qty').val();
        var qty = parseInt(quantity);
        qty += 1;
        $('#Qty').val(qty)
    })

    // detail product quantity minus

    $(".prevBtn").click(function () {
        var quantity = $('#Qty').val();
        var qty = parseInt(quantity);

        if (qty <= 1) {
            $('#Qty').val(qty)
        }
        else {
            qty -= 1;
            $('#Qty').val(qty)
        }
    })


    // detail product select change event 

    $("#inputDetailSelect").change(function () {

        var value = $("#inputDetailSelect").val();

        var valInt=parseInt(value);

        window.location.href = '/Detail/Index/' + valInt;

        //$.ajax({
        //    url: "/Detail/Index/" + valInt,
        //    type: "get",
        //    dataType: "json",
        //    success: function (response) {
        //        console.log(response);
        //    },
        //    error: function (error) {
        //        console.log(error);
        //    }
        //});

    });

    // details image to  bigger/main

    $("#productDetails .item img").click(function () {

        var sorce = $(this).attr('src');
        console.log(sorce);

        $("#productDetails .mainImage img").attr('src', sorce);
    });


    // add review by ajax

    //$("#productDetails #addReview").click(function () {

    //    var name = $('#productDetails #inputName').val();
    //    var content = $('#productDetails #inputContent').val();
    //    var stars = $('#productDetails #inputStars').val();
    //    var id = $('#productDetails #inputId').val();

    //    console.log(name + content + stars + id);
    //    $.ajax({

    //        url: '<%: Url.Action("writeReview")%>',
    //        data: { 'name': name, 'content': content, 'stars': stars, 'id': id  },

    //        type: "post",
    //        cache: false,

    //        //dataType: "html",

    //        success: function (response) {

    //            $("#colorContainer").append(response);

    //        },

    //        error: function (error) {
    //            console.log(error);
    //        }
    //    });
    //});


    // details add to card button
    $("#productDetails .choose .addToCardBtn").click(function () {

        Id = parseInt($(this).data("id"));
        Count =  parseInt($("#productDetails #Qty").val());

        refreshCart(Id, Count);

        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Product added to Cart',
            showConfirmButton: false,
            timer: 1200
        })
    });


    // home page add to cart button
    $(".choose .addCardBtn").click(function () {

        Id = parseInt($(this).data("id"));
        Count = 1;

        refreshCart(Id, Count);

        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Product added to Cart',
            showConfirmButton: false,
            timer: 1200
        })

    });



    // product Count Change 
    $("#soppingCart .addCardInput").change(function () {

        // refresc Cart cookie
        var Id = parseInt($(this).data("id"));
        var Count = parseInt($(this).val());
        refreshCart(Id, Count);

        var price = parseFloat($(this).data("price"));

        if (Count > 0 && Count < 10) {
            // own unit price
            $('#soppingCart #products *[data-proId=' + Id + ']').text("$" + price.toFixed(2));
            // own total price
            $('#soppingCart #products *[data-ownTotal=' + Id + ']').text("$" + (price * Count).toFixed(2));
        }
        else if (Count >= 10 && Count < 20) {  // 5%
            // own unit price
            $('#soppingCart #products *[data-proId=' + Id + ']').text("$" + (price * 95 / 100 ).toFixed(2));
            // own total price
            $('#soppingCart #products *[data-ownTotal=' + Id + ']').text("$" + (price * 95 / 100 * Count).toFixed(2));
            // for old price not decrise
            $('#soppingCart #products *[data-proId=' + Id + ']').append("<br />");
            $('#soppingCart #products *[data-proId=' + Id + ']').append("<span style='text - decoration: line - through'>$"+ price.toFixed(2)+ "</span>");
        }
        else if (Count >= 20 && Count < 30) {  // 12%
            // own unit price
            $('#soppingCart #products *[data-proId=' + Id + ']').text("$" + (price * 88 / 100).toFixed(2));
            // own total price
            $('#soppingCart #products *[data-ownTotal=' + Id + ']').text("$" + (price * 88 / 100 * Count).toFixed(2));
            // for old price not decrise
            $('#soppingCart #products *[data-proId=' + Id + ']').append("<br />");
            $('#soppingCart #products *[data-proId=' + Id + ']').append("<span style='text - decoration: line - through'>$" + price.toFixed(2) + "</span>");
        }
        else if (Count >= 30 ) {  // 20%
            // own unit price
            $('#soppingCart #products *[data-proId=' + Id + ']').text("$" + (price * 80 / 100).toFixed(2));
            // own total price
            $('#soppingCart #products *[data-ownTotal=' + Id + ']').text("$" + (price * 80 / 100 * Count).toFixed(2));
            // for old price not decrise in span tag
            $('#soppingCart #products *[data-proId=' + Id + ']').append("<br />");
            $('#soppingCart #products *[data-proId=' + Id + ']').append("<span style='text - decoration: line - through'>$" + price.toFixed(2) + "</span>");
        }

        // Total price of produsts
        var SumTotalPrices = 0;

        $("#soppingCart #products .forSumTotal").each(function (index) {
            SumTotalPrices += parseFloat($(this).text().substring(1));
        });

        // sub Total price of products 82%
        $('#soppingCart #total .allSubTotal').text("$" + (SumTotalPrices * 82 / 100).toFixed(2));
        // EDV price 18%
        $('#soppingCart #total .allTotalVat').text("$" + (SumTotalPrices * 18 / 100).toFixed(2));
        // TOTAL Price  100 %
        $('#soppingCart #total .allTotalPrice').text("$" + SumTotalPrices.toFixed(2));
        
    });

    // remove product from cart
    $("#soppingCart #products .miqdar .removeCardBtn").click(function () {

        Id = parseInt($(this).data("id"));
        var thisTotalPrice = parseFloat($('#soppingCart #products *[data-ownTotal=' + Id + ']').text().substring(1));
        $(this).parent().parent().parent().remove();

        //Decrease Total price
        var TotalPrice = parseFloat($('#soppingCart #total .allTotalPrice').text().substring(1));
        TotalPrice -= thisTotalPrice



        // sub Total price of products 82%
        $('#soppingCart #total .allSubTotal').text("$" + (TotalPrice * 82 / 100).toFixed(2));
        // EDV price 18%
        $('#soppingCart #total .allTotalVat').text("$" + (TotalPrice * 18 / 100).toFixed(2));
        // TOTAL Price  100 %
        $('#soppingCart #total .allTotalPrice').text("$" + TotalPrice.toFixed(2));


        //Remove from cookie
        $.ajax({
            url: "/Cart/RemoveFromCart/" + Id,
            type: "get",
            dataType: "json",
            success: function (response) {
                console.log(response);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });





    // remove Addres from user address list and database
    $("#account #register #addressList .btnDelete").click(function () {

        Id = parseInt($(this).data("id"));
        $(this).parent().parent().remove();

        //Remove from baza
        $.ajax({
            url: "/Account/RemoveFromBaza/" + Id,
            type: "get",
            dataType: "json",
            success: function (response) {
                console.log(response);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });




    // remove wish from Wishlis list and database
    $("#account #register #addressList .btnDeleteWish").click(function () {

        Id = parseInt($(this).data("id"));
        $(this).parent().parent().remove();

        //Remove from baza
        $.ajax({
            url: "/Account/RemoveWish/" + Id,
            type: "get",
            dataType: "json",
            success: function (response) {


                var oldCountTrue = parseInt($(".wishListCount").text());
                oldCountTrue--;
                $(".wishListCount").text(oldCountTrue);

                console.log(response);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

   

     //add Wish List 

    $(".addWishBtn").click(function () {

        id = parseInt($(this).data("id"));

        $.ajax({
            //url: "/Cart/AddToWishList/" + id,
            url: "/Cart/AddWishToUser/" + id,
            type: "get",
            dataType: "html",
            success: function (response) {
                if (response === "success-true") {
                    var oldCountTrue = parseInt($(".wishListCount").text());
                    oldCountTrue++;
                    $(".wishListCount").text(oldCountTrue);

                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Product added to Wish List',
                        showConfirmButton: false,
                        timer: 1200
                    })

                } else if (response === "success-false") {
                     // send to login for wish
                    window.location.href = '/Login/Index';
                } else if (response==="error") {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Product added to Wish List',
                        showConfirmButton: false,
                        timer: 1200
                    })
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    });


    // add product to card cookie from wish list
    $("#account #register #addressList .btnToCardWish").click(function () {

        Id = parseInt($(this).data("id"));
        Count = 1;

        refreshCart(Id, Count);
    });

    // change scroll positiuon by char selected

    $(".OurBrand .BrandChar").click(function () {
        var clikedChar = $(this).data("char")
        console.log(clikedChar);

        var slCharTop = $('#register .SelectData  *[data-charTop=' + clikedChar + ']').position().top;
        window.scrollTo(0, slCharTop + 200);
    });









































    function refreshCart(Id, Count) {
        var cartElem = {
            id: Id,
            count: Count
        };

        $.ajax({
            url: "/Cart/AddToCart/",
            type: "get",
            dataType: "json",
            data: cartElem,
            success: function (response) {

                // jsonda count ve price  almmaq  

                //if (response === "success-true") {
                //    var oldCountTrue = parseInt($(".cartCount").text());
                //    oldCountTrue++;
                //    $(".cartCount").text(oldCountTrue);
                //}
            },
            error: function (error) {
                console.log(error);
            }
        });
    }



});