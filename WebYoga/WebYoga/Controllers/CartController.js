var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/Home/Index";
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/Cart/ThanhToan";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtsoluong');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    SanPham: {
                        IdSanPham: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/Index";
                    }
                }
            })
        });

        $('#btnDeleteAll').off('click').on('click', function () {


            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/Index";
                    }
                }
            })
        });

        $('#btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/Index";
                    }
                }
            })
        });
    }
}
cart.init();