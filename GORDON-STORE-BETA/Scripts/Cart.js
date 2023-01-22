

$("a.addtocart").click(function (e) {
    e.preventDefault();
    $("span.loader").addClass("ib");
    var url = "/cart/AddToCartPartial";
   /* $.get(url, { id: @Model.ProdutoId }, function (data) {*/
    $(".ajaxcart").html(data);
}).done(function () {
    $("span.loader").removeClass("ib");
    $("span.ajaxmsg").addClass("ib");
    setTimeout(function () {
        $("span.ajaxmsg").fadeOut("fast");
        $("span.ajaxmsg").removeClass("ib");
    }, 1000);
});



    $("a.incrproduct").click(function (e) {
        e.preventDefault();

        var productId = $(this).data("id");
        var url = "/cart/IncrementProduct";

        $.getJSON(url, { produtoId: produtoId }, function (data) {

            $("td.qty" + produtoId).html(data.qty);

            var price = data.qty * data.preco;
            var precoHtml = "R$" + preco.toFixed(2);

            $("td.total" + produtoId).html(precoHtml);

            var gt = parseFloat($("th.grandtotal span").text());
            var grandtotal = (gt + data.preco).toFixed(2);

            $("th.grandtotal span").text(grandtotal);
        }).done(function () {
            var url2 = "/cart/PaypalPartial";

            $.get(url2, {}, function (data) {
                $("div.paypaldiv").html(data);
            });
        });
    });

    //////////////////////////////////////////////////////////////

    /*
    * Decrement product
    */

    $("a.decrproduct").click(function (e) {
        e.preventDefault();

        var productId = $(this).data("id");
        var url = "/cart/DecrementProduct";

        $.getJSON(url, { produtoId: produtoId }, function (data) {
            if (data.qty == 0) {
                $this.parent().parent().fadeOut("fast", function () {
                    location.reload();
                });
            }
            else {
                $("td.qty" + produtoId).html(data.qty);

                var preco = data.qty * data.preco;
                var precoHtml = "$" + preco.toFixed(2);

                $("td.total" + produtoId).html(priceHtml);

                var gt = parseFloat($("th.grandtotal span").text());
                var grandtotal = (gt - data.preco).toFixed(2);

                $("th.grandtotal span").text(grandtotal);
            }

        }).done(function (data) {
            var url2 = "/cart/PaypalPartial";

            $.get(url2, {}, function (data) {
                $('div.paypaldiv').html(data);
            });
        });
    });

    //////////////////////////////////////////////////////////////

    /*
    * Remove product
    */

    $("a.removeproduct").click(function (e) {
        e.preventDefault();

        var produtoId = $(this).data("id");
        var url = "/cart/RemoveProduct";

        $.get(url, { produtoId: produtoId }, function (data) {
            location.reload();
        });
    });

    //////////////////////////////////////////////////////////////

    /*
    * Place order
    */

    $("a.placeorder").click(function (e) {
        e.preventDefault();
        var url = "/cart/MakeOrder";

        $(".ajaxbg").show();

        $.post(url, {}, function (data) {
            $(".ajaxbg span").html("<h3>Thank you. You will automatically be redirected to paypal.</h1>");
            setTimeout(function () {
                $('form input[name="submit"]').click();
            }, 2000);
        });
    });

    //////////////////////////////////////////////////////////////

});