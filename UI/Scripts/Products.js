(function () {
    var Products = {


        page_Int: function () {
            // Mini Cart
            paypal.minicart.render({
                action: '#',
                strings: {
                    button: "checkout",
                }
            });
        }
        , page_Load: function () {
            
        },
        Page_Event: function () {
        
         
            //addCart Button Event
            $(".addCart").click(function () {
                var dataObject = $(this).data("object");
                var Items = paypal.minicart.cart.items();
                if (Products.checkItemQuantity(dataObject.ItemID, dataObject.Quantity)) {
                    paypal.minicart.cart.add({
                        "ItemID": dataObject.ItemID, "business": "user@example.com", "add": 1, "discount_amount": dataObject.Discount, "item_name": dataObject.ItemName, "amount": dataObject.Price, "currency_code": "SAR"
                    });
                }
                else {
                    alert("Out Off Stock");
                }
               
               
            });
        },
        Page_Start: function () {
            Products.page_Int();
            Products.page_Load();
            Products.Page_Event();

        }
        , checkItemQuantity: function (ItemID,Quantity) {
            var Items = paypal.minicart.cart.items();
            if (Items.length > 0) {


                for (var i = 0; i < Items.length; i++) {
                    if (Items[i]._data.ItemID === ItemID) {
                        if (Items[i]._data.quantity < Quantity) {
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                   
                }
            }
            else {
                return true;
            }
            return true;
        }


    }
    $(document).ready(function () {
        Products.Page_Start();
    });
   
})();
//Minicart  CheckOut
function btn_CheckOut_Click() {
    var UserName = $("#UserName").val();
    if (UserName) {


        var Items = paypal.minicart.cart.items();
        var Order = { TotalPrice: paypal.minicart.cart.subtotal(), UserName: $("#UserName").val() };

        Order.OrderItems = [];
        for (var i = 0; i < Items.length; i++) {
            var Item = { ItemID: Items[i]._data.ItemID, Quantity: Items[i]._data.quantity, Price: (Items[i]._data.amount - Items[i]._data.discount_amount), TotalPrice: Items[i]._total };
            Order.OrderItems.push(Item);
        }
        $.post(API.APIURL + "Order", Order, function (data) {
            paypal.minicart.reset();
            DevExpress.ui.notify("success: order make sucess check your e-mail", "success");
        
        });
    }
    else {
        DevExpress.ui.notify( "error: Should Login to make order", "error");
    }
}