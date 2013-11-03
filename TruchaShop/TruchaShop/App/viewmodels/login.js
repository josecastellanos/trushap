define(['plugins/router', 'durandal/app', 'viewmodels/shell', 'plugins/http'], function (router, app, shell, http) {

    var self = {
        userToLogin: {
            Username: ko.observable(""),
            Password: ko.observable("")
        },

        activate: function () {
            self.userToLogin.Username("");
            self.userToLogin.Password("");
            shell.isUserLoggedIn(false);
        },

        login: function () {
            var userToLogin = ko.toJS(self.userToLogin);
            http.post("/Usuario/Login", userToLogin)
                .done(function (response, status, xhr) {
                    if (response.Success) {
                        shell.isUserLoggedIn(true);
                        shell.user.PrimerNombre(response.PrimerNombre);
                        shell.user.NombreCompleto(response.NombreCompleto);
                        //router.navigate('#/meetings');
                    } else {
                        shell.isUserLoggedIn(false);
                        app.showMessage("You are not an user!");
                    }
                });
        }
    };

    return self;

});