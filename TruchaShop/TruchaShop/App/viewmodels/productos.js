function multiply(value, value1) {
    var r = value * value1;
    return r;
}



define(['plugins/router', 'durandal/app', 'viewmodels/shell', 'plugins/http'], function (router, app, shell, http) {
    
    var Product = function () {
        this.ProductoNombre = ko.observable();
        this.ProductoDescripcion = ko.observable();
        this.ProductoLogo = ko.observable();
        this.Precio = ko.observable();
        this.Cantidad = ko.observable();
        this.Subtotal = ko.dependentObservable(function () {
            var precio = ko.toJS(this.Precio);
            var cantidad = ko.toJS(this.Cantidad);
            return precio * cantidad;
        }.bind(this));
    };

    var self = {
        productos: ko.observable([]),
        order: ko.observable([]),
        total: ko.observable(0),
        addToOrder: function () {
            var orderSoFar = ko.toJS(self.order);
            var totalOrder = ko.toJS(self.total);
            var precio = ko.toJS(this.Precio);
            var cantidad = ko.toJS(this.Cantidad);
            var subtotal = precio * cantidad;
            totalOrder += subtotal;
            if (totalOrder > 0 && subtotal > 0) {
                self.total(totalOrder);
                orderSoFar.push({ Nombre: ko.toJS(this.ProductoNombre), Cantidad: cantidad, Precio: precio, Subtotal: subtotal });
                self.order(orderSoFar);
            }
        },

        activate: function () {
            var isUserLoggedIn = ko.toJS(shell.isUserLoggedIn);
            if (isUserLoggedIn) {
                http.post("/Producto/ObtenerProductos")
                .done(function (response, status, xhr) {
                    var array = new Array();
                    var length = response.length;
                    for (var i = 0; i < length; i++) {
                        var product = new Product();
                        product.ProductoNombre(response[i].ProductoNombre);
                        product.ProductoDescripcion(response[i].ProductoDescripcion);
                        product.ProductoLogo(response[i].ProductoLogo);
                        product.Precio(response[i].Precio);
                        product.Cantidad(response[i].Cantidad);
                        array.push(product);
                    }
                    self.productos(array);
                });
            } else {
                router.navigate('#/login');
            }
        }
    };

    return self;

});