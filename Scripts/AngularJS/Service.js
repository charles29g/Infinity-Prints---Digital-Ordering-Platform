app.service("IPService", function ($http) {

    console.log("Service")

    this.LoadServices = function () {
        return $http.get("Home/LoadServices");
    }

    this.LoadUsers = function () {
        return $http.get("Home/LoadUsers");
    }

    this.LoadContents = function () {
        return $http.get("Home/LoadContents");
    }
    this.LoadStatus = function () {
        return $http.get("Home/LoadStatus");
    }
    this.LoadReceipts = function () {
        return $http.get("Home/LoadReceipts");
    }
    this.LoadSizes = function () {
        return $http.get("Home/LoadSizes");
    }
    this.LoadLogs = function () {
        return $http.get("Home/LoadLogs");
    }
    this.LoadOrders = function () {
        return $http.get("Home/LoadOrders");
    }
    this.LoadPayments = function () {
        return $http.get("Home/LoadPayments");
    }

    this.SendEmailCP = function (emailData) {
        console.log(emailData);

        console.log(emailData + " Service");
        var SendEmail = $http({
            method: "post",
            url: "Home/LoadUserCP",
            data: { SendEmail: emailData.Email, }

        });

        return SendEmail;
    };
    this.SendEmail = function (emailData) {
        console.log(emailData);

        console.log(emailData + " Service");
        var SendEmail = $http({
            method: "post",
            url: "Home/SendEmailVerification",
            data: {
                emailData: emailData,
            }
        });

        return SendEmail;
    };

    this.InsertRegistration = function (RegData) {
        console.log(RegData)

        console.log(RegData + "Service")
        var Insert = $http({
            method: "post",
            url: "Home/InsertRegistration",
            data: {
                RegData: RegData,
                // userID: sessionStorage.getItem("userID")

            }

        });

        return Insert;
    };

    this.ChangePassword = function (RegData) {
        console.log(RegData)

        console.log(RegData + "Service")
        var Insert = $http({
            method: "post",
            url: "Home/UpdatePassword",
            data: {
                RegData: RegData,
                // userID: sessionStorage.getItem("userID")

            }

        });

        return Insert;
    };



    this.loginfunc = function (loginData) {

        console.log(loginData + "Service");
        var response = $http({
            method: "post",
            url: "Home/ValidateLogin",
            data: {
                loginData, userID: sessionStorage.getItem("userID")
            }

        });

        return response;

    };

    this.ConfirmEmail = function (userID) {
        console.log("Confirming email for userID:", userID);

        var Confirm = $http({
            method: "post",
            url: "/Home/ActivateUser",  // Full URL path for the controller action
            data: { userID: userID }  // Use an object to send data
        });

        return Confirm;
    };



    this.UpdateSelf = function (userDataUpdate) {

        console.log(userDataUpdate + "Service")
        var Insert = $http({
            method: "post",
            url: "Home/UpdateSelf",
            data: {
                userDataUpdate
            }


        });

        return Insert;
    };



    this.ValidatePassword = function (passwordData) {
        return $http({
            method: "POST",
            url: "Home/ValidatePassword",
            data: passwordData
        });
    };



})