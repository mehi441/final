//import { request } from "d3-request";

$(document).ready(function () {

    //$("#accordion .header").click(function () {
    //    $(this).next().toggleClass("active");
    //})
    $(".BILHead").click(function () {
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
        loop: false,
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
    });

    // details image to  bigger/main
    $("#productDetails .item img").click(function () {

        var sorce = $(this).attr('src');
        console.log(sorce);

        $("#productDetails .mainImage img").attr('src', sorce);
    });

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

    // product Count Change in cart
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
                GetProCount();
                GetProPrice();
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

    // add Wish List 
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

    // add Newsletter
    $("#myNewsletter").submit(function (event) {
        event.preventDefault(); //prevent default action 
        var post_url = $(this).attr("action"); //get form action url
        var request_method = $(this).attr("method"); //get form GET/POST method
        var form_data = $(this).serialize(); //Encode form elements for submission

        $.ajax({
            url: post_url,
            type: request_method,
            data: form_data
        }).done(function (response) { //
            if (response=="sucs") {
                Swal.fire('You have successfully subscribed to this newsletter.')
            } else if (response=="error") {
                Swal.fire({
                    icon: 'error',
                    text: 'This email address is already registered.!',
                    //footer: '<a href>Why do I have this issue?</a>'
                })
            }
        });
    });

    // add review by ajax 
    $("#myReview").submit(function (event) {
        event.preventDefault(); //prevent default action 
        var post_url = $(this).attr("action"); //get form action url
        var request_method = $(this).attr("method"); //get form GET/POST method
        var form_data = $(this).serialize(); //Encode form elements for submission

        $.ajax({
            url: post_url,
            type: request_method,
            data: form_data
        }).done(function (response) { //
            if (response == "sucs") {
                $(".revErrorStar").html("");
                Swal.fire('You have successfully added review.')
            } else if (response == "error") {
                Swal.fire({
                    icon: 'error',
                    text: 'fill all.!',
                })
            } else if (response == "error-name") {
                $(".revErrorName").html("Name max 70 ");
            } else if (response == "error-content") {
                $(".revErrorName").html("");
                $(".revErrorContent").html("Name max 500  min 10");
            } else if (response == "error-star") {
                $(".revErrorName").html("");
                $(".revErrorContent").html("");
                $(".revErrorStar").html("You must add review");
            }
        });
    });

    // pass to write review 
    $(".reviewCount .PassReview").click(function (e) {
        e.preventDefault();

        $("#nav-tab .nav-link").removeClass("active");
        $("#nav-tab .nav-link").attr("aria-selected", "false");

        $("#nav-tab .nav-contact-tab").addClass("active");
        $("#nav-tab .nav-contact-tab").attr("aria-selected", "true");

        $(".tab-content .tab-pane").removeClass("active");
        $(".tab-content .tab-pane").removeClass("show");

        $(".tab-content #nav-contact").addClass("active");
        $(".tab-content #nav-contact").addClass("show");


        var slCharTop = $('#myReview').position().top;
        console.log(slCharTop);
        window.scrollTo(0, slCharTop+750);
    });

    // add to compare cookie 
    $(".choose .addCompareBtn").click(function (e) {
        e.preventDefault();

        var id = parseInt($(this).data("id"));
        $.ajax({
            url: "/Compare/AddCompare/" + id,
            type: "get",
            dataType: "json",
            success: function (response) {
                if (response === "success-true") {

                    var oldCompareCount = parseInt($(".CompareProCount").text());
                    oldCompareCount++;
                    $(".CompareProCount").text(oldCompareCount);

                    Swal.fire({
                        position: 'top',
                        icon: 'success',
                        title: 'You have added product to comparison',
                        showConfirmButton: false,
                        timer: 1200
                    })
                } else if (response === "success-false") {
                    Swal.fire({
                        position: 'top',
                        icon: 'success',
                        title: 'You have added product to comparison',
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

    // Check boc yollari 
    //add Address to order 
    $("#addAddressOrder").submit(function (event) {
        event.preventDefault(); //prevent default action 
        var post_url = $(this).attr("action"); //get form action url
        var request_method = $(this).attr("method"); //get form GET/POST method
        var form_data = $(this).serialize(); //Encode form elements for submission

        $.ajax({
            url: post_url,
            type: request_method,
            data: form_data
        }).done(function (response) { //

            if (response!="error") {
                var id = parseInt(response);
                $("#ForAddOrderId input").val(id);
                $("#EndBtn").data("id", id);
                $("#DLVmet").addClass("active");
            }


        });
    });

    // add is ship to order
    $("#AddShipToOrder").submit(function (event) {
        event.preventDefault(); //prevent default action 
        var post_url = $(this).attr("action"); //get form action url
        var request_method = $(this).attr("method"); //get form GET/POST method
        var form_data = $(this).serialize(); //Encode form elements for submission

        $.ajax({
            url: post_url,
            type: request_method,
            data: form_data
        }).done(function (response) { //

            if (response === "Sucses") {
                $("#PYMmet").addClass("active");
            }
            
            console.log(response);

        });
    });

    // add pay to order
    $("#AddPayToOrder").submit(function (event) {
        event.preventDefault(); //prevent default action 
        var post_url = $(this).attr("action"); //get form action url
        var request_method = $(this).attr("method"); //get form GET/POST method
        var form_data = $(this).serialize(); //Encode form elements for submission

        $.ajax({
            url: post_url,
            type: request_method,
            data: form_data
        }).done(function (response) { //

            if (response === "Sucses-false") {
                $("#forMustCheck").text("You have to agree");
            } else if (response === "Sucses") {
                $("#CFRMOrd").addClass("active");
                console.log("Sucss");
            } else if (response==="error") {
                console.log("tom");

            }
        });
    });

    // inut clik show cart inputs for paying
    $(".inpR").change(function () {

        if ($("#in4").prop("checked") == true) {
            $("#ForAddCartInput").css("display", "block");
        } else {
            $("#ForAddCartInput").css("display", "none");
        }
    });

    // home shipping change eveti 
    $(".inpShip").change(function () {

        if ($("#in2").prop("checked") == true) {
            $(".ForShipPrice").text("$13.00");

            var SumTotalPrices = 0;

            $(".ForTotPr").each(function (index) {
                SumTotalPrices += parseFloat($(this).text().substring(1));
            });
            $("#TotPrCh").text("$"+SumTotalPrices);

        } else {
            $(".ForShipPrice").text("$0.00");
            var SumTotalPrices = 0;

            $(".ForTotPr").each(function (index) {
                SumTotalPrices += parseFloat($(this).text().substring(1));
            });
            $("#TotPrCh").text("$"+SumTotalPrices);
        }
    });

    // End Btn click
    $("#EndBtn").click(function (e) {
        e.preventDefault();
        Id = parseInt($(this).data("id"));

        $.ajax({
            url: "/Checkout/AddItemOToOrder/" + Id,
            type: "get",
            dataType: "json",
            success: function (response) {
                console.log(response);
                if (response ==="sucses") {
                    Swal.fire("Your order has been placed! Your order has been successfully processed! You can view your order history by going to the my account page and by clicking on history. If your purchase has an associated download, you can go to the account downloads page to view them.Please direct any questions you have to the store owner.Thanks for shopping with us online!")

                    setInterval(function () { window.location.href = '/Home/Index/'; }, 3000);
                }

            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    // login user in checkbox page
    $("#CheckLogin").submit(function (event) {
        event.preventDefault(); //prevent default action 
        var post_url = $(this).attr("action"); //get form action url
        var request_method = $(this).attr("method"); //get form GET/POST method
        var form_data = $(this).serialize(); //Encode form elements for submission

        $.ajax({
            url: post_url,
            type: request_method,
            data: form_data
        }).done(function (response) { //
            if (response ==="Sucses") {
                window.location.href = '/Checkout/Index/';
            }else if (response === "error-password") {
                $("#errPassword").text("Password is wrong");
                $("#errEmail").text("");
            } else if (response === "error-email") {
                $("#errEmail").text("Email is wrong");
                $("#errPassword").text("");
            } else if (response === "error") {
                console.log("tom");
            }
        });
    });

    // add product to card from order details page
    $(".addOrdItToCard").click(function () {

        Id = parseInt($(this).data("id"));
        refreshCart(Id, 1);

        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Product added to Cart',
            showConfirmButton: false,
            timer: 1200
        })
    });

    // filter section elements toogle active
    $("#filter .myHeader").click(function () {
        $(this).next().toggleClass("d-none");
    })


    // add clear btn to is stock filter
    $(".isStockFltr").click(function () {
        $("#BtnClrIsStock").removeClass("d-none");
    });

    // remove clicked items from is stock 
    $("#BtnClrIsStock").click(function () {
        $(".isStockFltr").each(function () {
            $(this).prop("checked", false);
        });
        refreshFilter();
        $(this).addClass("d-none");
    });

    // add clear btn to brands filter
    $(".chkBoxBrdIdFltr").click(function () {
        $("#BtnClrBrands").removeClass("d-none");
    });

    // remove clicked items from brands filter 
    $("#BtnClrBrands").click(function () {
        $(".chkBoxBrdIdFltr").each(function () {
            $(this).prop("checked", false);
        });
        refreshFilter();
        $(this).addClass("d-none");
    });

    // Brands Fltr refresh filter
    $(".chkBoxBrdIdFltr").change(function () {
        refreshFilter();
        var IdSlctd = []; // get selected brands ids in array int
        $('input.chkBoxBrdIdFltr:checked').each(function () {
            IdSlctd.push(parseInt(this.value));
        });
        if (IdSlctd.length == 0) {
            $("#BtnClrBrands").addClass("d-none");
        }
    });

    // Filter Is Stock change event refresh products in filter
    $(".isStockFltr").change(function () {
        refreshFilter();
    });

    // minprice change event refresh products in filter
    $(".minPrcFilter").change(function () { // dont work
        refreshFilter();
    });

    // max price change event refresh products in filter
    $(".maxPrcFilter").change(function () { // dont work
        refreshFilter();
    });

    // sort by filter change event refresh products in filter
    $(".sortSltFltr").change(function () { // dont work
        refreshFilter();
    });
























    // refresh filter
    function refreshFilter() {
        var checkedIsStockVal = $('.isStockFltr:checked').val();
        var minPrcVal = parseInt($(".minPrcFilter").val()); // get min value price
        var maxPrcVal = parseInt($(".maxPrcFilter").val()); // get max value price
        var sortSelId = parseInt($('select.sortSltFltr').children("option:selected").val()); // get Sort type id
        var showSelId = parseInt($('select.showCntFltr').children("option:selected").val()); // get Show count id

        var brandIdsSlctd = []; // get selected brands ids in array int
        $('input.chkBoxBrdIdFltr:checked').each(function () {
            brandIdsSlctd.push(parseInt(this.value));
        });

        //console.log(minPrcVal, maxPrcVal, brandIdsSlctd, checkedIsStockVal, sortSelId, showSelId );

        var filter_data = {  // send data object to controller
            MinPrc: minPrcVal,
            MaxPrc: maxPrcVal,
            BrandId: brandIdsSlctd,
            IsStock: checkedIsStockVal,
            SortId: sortSelId,
            ShowCnt: showSelId
        };

        $.ajax({
            url: "/Filter/GetData/",
            type: "post",
            data: filter_data,
            dataType: "json",
            success: function (response) {  // recive response from controller


                $("#products #FltrRow").empty(); //  remove items from row
                $.each(response, function (i, item) {
                    var row = $("#products #FltrRow");

                    var divItem = $("<div>", { "class": "item col-lg-3 col-md-4 col-sm-6 col-xs-12" }); // create item div

                    var ItemPro = $("<div>", { "class": "product" }).appendTo(divItem); // creat product div

                    var ProLink = $("<a>", { "href": "/Detail/Index/" + item.Id }).appendTo(ItemPro); // create "a" tag

                    var LinkImageDiv = $("<div>", { "class": "image" }).appendTo(ProLink); // add image div to a tag

                    $("<img>", { "src": "/Uploads/" + item.Img, "alt": "phoone" }).appendTo(LinkImageDiv); // add img tag to image div

                    if (item.HoverImg != null) {
                        // check hover image of item then add
                        var LinkHoverDiv = $("<div>", { "class": "overlay" }).appendTo(ProLink); // creat overlay div add to "a" tag
                        $("<img>", { "src": "/Uploads/" + item.HoverImg, "alt": "dinamik" }).appendTo(LinkHoverDiv); // add img to overlay div
                    }

                    if (item.Quantity != 0) {
                        // check quantiy of item then add
                        var LinkSaleDiv = $("<div>", { "class": "forSale" }).appendTo(ProLink); // creat Sale div add to "a" tag
                        var SaleDivSpan = $("<span>").appendTo(LinkSaleDiv); // creat span add forSale div
                        SaleDivSpan.append("SALE"); // add text to span 
                    }

                    var ProChoose = $("<div>", { "class": "choose" }).appendTo(ItemPro); // creat choose div add to product div
                    var ChooseUl = $("<ul>").appendTo(ProChoose); // creat ul tag div add to Choose div

                    // add Shop icon
                    var UlLi1 = $("<li>").appendTo(ChooseUl); // create li tag add to ul
                    var Li1Div1 = $("<div>", { "class": "addCardBtn", "data-id": item.Id }).appendTo(UlLi1); // creat div add to li tag
                    $("<i>", { "class": "fas fa-shopping-cart" }).appendTo(Li1Div1); // creat icon add to div1 tag

                    // add Wish icon
                    var UlLi2 = $("<li>").appendTo(ChooseUl); // create li tag add to ul
                    var Li1Div2 = $("<div>", { "class": "addWishBtn", "data-id": item.Id }).appendTo(UlLi2); // creat div add to li tag
                    $("<i>", { "class": "far fa-heart" }).appendTo(Li1Div2); // creat icon add to div2 tag

                    // add Compare icon
                    var UlLi3 = $("<li>").appendTo(ChooseUl); // create li tag add to ul
                    var Li1Div3 = $("<div>", { "class": "addCompareBtn", "data-id": item.Id }).appendTo(UlLi3); // creat div add to li tag
                    $("<i>", { "class": "far fa-chart-bar" }).appendTo(Li1Div3); // creat icon add to div3 tag

                    // create content div
                    var ProContent = $("<div>", { "class": "content" }).appendTo(ItemPro); // creat Content div add to product div

                    var ContentLink = $("<a>", { "href": "/Detail/Index/" + item.Id, "style": "text-decoration:none" }).appendTo(ProContent); // create a tag for name
                    var LinkH4 = $("<h4>").appendTo(ContentLink); // create h4 tag for name add to "a" tag
                    LinkH4.append(item.BrandName + " " + item.ModelName + " " + item.ProName + " " + item.ColorName); // add text to h4 tag

                    var ContentkH5 = $("<h5>").appendTo(ProContent); // create h5 tag for price add to content div
                    ContentkH5.append("$ " + item.Price); // add text to h5 tag
                    if (item.OldPrice != 0) { // check if old price is null
                        var OldPriceSpan = $("<span>").appendTo(ContentkH5); // creat span for old price add h5 tag
                        OldPriceSpan.append("$ " + item.OldPrice); // add text to span 
                    }
                    // end prices

                    // create stars div
                    var ContentStars = $("<div>", { "class": "stars" }).appendTo(ProContent); // creat stars div add to content
                    var StarsUl = $("<ul>").appendTo(ContentStars); // creat ul tag  add to stars div

                    for (var i = 0; i < 5; i++) {
                        var ulStar = $("<li>"); // create li tag for ul star

                        if (item.StarCount <= i) {
                            $("<i>", { "class": "fa fa-star sade" }).appendTo(ulStar); // creat icon add to  li tag
                        } else {
                            $("<i>", { "class": "fa fa-star" }).appendTo(ulStar); // creat icon add to  li tag
                        }

                        StarsUl.append(ulStar); // add li to ulb
                    }
                    row.append(divItem); //  add new item to Row
                });
            },
            error: function (error) {
                console.log(error);
            }
        });
    }


    // refresh cart cookie
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
                GetProCount();
                GetProPrice();
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

    // get products count for nav
    function GetProCount() {
        $.ajax({
            url: "/Home/GetProCount",
            type: "get",
            dataType: "json",
            success: function (response) {
                console.log(response);
                $("#nav-Count").text(response);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

    // get products prices for nav
    function GetProPrice() {
        $.ajax({
            url: "/Home/GetProPrice",
            type: "get",
            dataType: "json",
            success: function (response) {
                console.log(response);
                $("#nav-Price").text(response);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }



});