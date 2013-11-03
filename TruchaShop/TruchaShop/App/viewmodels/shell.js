define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,
        
        search: function() {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        
        isUserLoggedIn: ko.observable(false),
        
        user: {
            PrimerNombre: ko.observable(""),
            NombreCompleto: ko.observable("")
        },
        
        activate: function () {
            router.map([
                { route: '', title: 'TruchaShop!', moduleId: 'viewmodels/login', nav: true },
                { route: 'login', moduleId: 'viewmodels/login', nav: true },
                { route: 'productos', moduleId: 'viewmodels/productos', nav: true },
                { route: 'details/:id', moduleId: 'viewmodels/meetinfo/details', nav: true },
                { route: 'add(/:id)', moduleId: 'viewmodels/meetinfo/add', nav: true }
            ]).buildNavigationModel();
            
            return router.activate();
        },
        
        logout: function() {
            router.navigate('#/login');
        }
    };
});