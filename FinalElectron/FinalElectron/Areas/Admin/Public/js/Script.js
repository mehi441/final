$(document).ready(function () {

    $("#catId").change(function () {

        var catId = $(this).val();

        $.ajax({
            
            //url: "/home/getProducts/" + catId,
            url: "getSubCategories/" + catId,
            type: "Get",
            dataType: "html",

            success: function (response) {

                $("#subCatId").html(response);

            },
            error: function (error) { }
        });
    });

    $("#brandId").change(function () {

        var brandId = $(this).val();

        $.ajax({

            url: "getModels/" + brandId,
            type: "Get",
            dataType: "html",

            success: function (response) {

                $("#modelId").html(response);

            },
            error: function (error) { }
        });
    });

    $("#AddColor").click(function () {

        console.log("toom");
        $.ajax({

            url: "GetColors",
            type: "get",
            dataType: "html",

            success: function (response) {

                $("#colorContainer").append(response);

            },

            error: function (error) {
                console.log(error);
            }
        });
    });


    CKEDITOR.replace('cktext');

});