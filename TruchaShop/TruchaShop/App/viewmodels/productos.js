define(['plugins/router', 'durandal/app', 'viewmodels/shell', 'plugins/http'], function (router, app, shell, http) {

    var self = {
        productos: ko.observable([]),

        activate: function () {
            var isUserLoggedIn = ko.toJS(shell.isUserLoggedIn);
            if (isUserLoggedIn) {
                http.post("/Producto/ObtenerProductos")
                .done(function (response, status, xhr) {
                    self.productos(response);
                });
            } else {
                router.navigate('#/login');
            }
        }
    };

    return self;

});