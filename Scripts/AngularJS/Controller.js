app.controller("IPController", function ($scope, $location, IPService) {

    console.log("Controller")
    $scope.loadServices = function () {
        var getData = IPService.LoadServices();
        getData.then(function (ReturnedData) {
            $scope.ServicesData = ReturnedData.data;



            console.log(ReturnedData.data);
            console.log("HI");
            $(document).ready(function () {


                $('#myTable').DataTable();
            });
        });
    };


    $scope.loadUsers = function () {
        var getData = IPService.LoadUsers();
        getData.then(function (ReturnedData) {
            $scope.UsersData = ReturnedData.data;



            console.log(ReturnedData.data);
            console.log("HI");
            $(document).ready(function () {


                $('#myTable').DataTable();
            });
        });
    };

    $scope.loadContents = function () {
        var getData = IPService.LoadContents();
        getData.then(function (ReturnedData) {
            $scope.ContentsData = ReturnedData.data;



            console.log(ReturnedData.data);
            console.log("HI");
            $(document).ready(function () {


                $('#myTable').DataTable();
            });
        });
    };

    $scope.loadStatus = function () {
        var getData = IPService.LoadStatus();
        getData.then(function (ReturnedData) {
            $scope.StatusData = ReturnedData.data;



            console.log(ReturnedData.data);
            console.log("HI");
            $(document).ready(function () {


                $('#myTable').DataTable();
            });
        });
    };

    $scope.loadReceipts = function () {
        var getData = IPService.LoadReceipts();
        getData.then(function (ReturnedData) {
            $scope.ReceiptsData = ReturnedData.data;



            console.log(ReturnedData.data);
            console.log("HI");
            $(document).ready(function () {


                $('#myTable').DataTable();
            });
        });
    };

    $scope.loadSizes = function () {
        var getData = IPService.LoadSizes();
        getData.then(function (ReturnedData) {
            $scope.sizesData = ReturnedData.data;



            console.log(ReturnedData.data);
            console.log("HI");
            $(document).ready(function () {


                $('#myTable').DataTable();
            });
        });
    };


    $scope.loadLogs = function () {
        var getData = IPService.LoadLogs();
        getData.then(function (ReturnedData) {
            $scope.LogsData = ReturnedData.data;



            console.log(ReturnedData.data);
            console.log("HI");
            $(document).ready(function () {


                $('#myTable').DataTable();
            });
        });
    };
    $scope.loadOrders = function () {
        var getData = IPService.LoadOrders();
        getData.then(function (ReturnedData) {
            $scope.OrdersData = ReturnedData.data;



            console.log(ReturnedData.data);
            console.log("HI");
            $(document).ready(function () {


                $('#myTable').DataTable();
            });
        });
    };

    $scope.loadPayments = function () {
        var getData = IPService.LoadPayments();
        getData.then(function (ReturnedData) {
            $scope.PaymentsData = ReturnedData.data;



            console.log(ReturnedData.data);
            console.log("HI");
            $(document).ready(function () {


                $('#myTable').DataTable();
            });
        });
    };



    $scope.InsertReg = function () {
        var RegData = {
            FName: $scope.firstName,
            LName: $scope.lastName,
            Email: $scope.email2,
            UName: $scope.username,
            PhoneNum: $scope.phone,
            Password: $scope.password2,
            RoleID: 1
        };
        console.log(RegData + " controller");

        var postData = IPService.InsertRegistration(RegData);

        postData.then(function (ReturnedData) {
            var response = ReturnedData.data;
            console.log("Full response:", ReturnedData);
            console.log("Response Success:", response.success);
            console.log("Response Message:", response.message);

            if (response.success) {
                var userId = response.userId;
                console.log("UserID created: ", userId);

                // Encrypt the userId using AES before passing it



                swal.fire({
                    title: 'Success!',
                    text: response.message,
                    icon: 'success',
                    confirmButtonText: 'OK',
                }).then(() => {
                    // Call SendEmail with the encryptedUserId
                    $scope.sendEmail(userId);
                });
            } else {
                swal.fire({
                    title: 'Error!',
                    text: response.message,
                    icon: 'error',
                    confirmButtonText: 'OK',
                });
            }
        }).catch(function (error) {
            console.log("Error occurred:", error);
            swal.fire({
                title: 'Error!',
                text: 'An error occurred. Please try again.',
                icon: 'error',
                confirmButtonText: 'OK',
            });
        });
    };

    $scope.sendEmail = function (encryptedUserId) {
        // Construct the URL with the encrypted userID
        var url = `https://localhost:44399/Home/ConfirmationPage?userID=${encryptedUserId}`;

        var emailData = {
            toEmail: "charlesjoseph.gutierrez.cics@ust.edu.ph",  // Target email address
            subject: "Infinity Prints Account Activation",      // Subject of the email
            body: `<h1>Infinity Prints</h1><p>Please click the <a href="${url}">link</a> to activate your account</p>` // Body of the email (HTML format)
        };

        var sendEmailRequest = IPService.SendEmail(emailData);
        sendEmailRequest.then(function (response) {
            console.log("Email sent successfully:", response.data);
            swal.fire({
                title: 'Success!',
                text: 'Activation email sent successfully!',
                icon: 'success',
                confirmButtonText: 'OK',
            });
        }).catch(function (error) {
            console.error("Error sending email:", error);
            swal.fire({
                title: 'Error!',
                text: 'Error sending activation email.',
                icon: 'error',
                confirmButtonText: 'OK',
            });
        });
    };


    $scope.ChangePassword = function () {
        var params = $location.search(); // gets all query parameters as an object
        $scope.userID = params.userID; //Get 'userID' directly from the URL query string
        var userID = $scope.userID
        var RegData = {
            password: $scope.password,
            userID: userID,

        };
        console.log(RegData + " controller");

        var postData = IPService.ChangePassword(RegData);

        postData.then(function (ReturnedData) {

            var response = ReturnedData.data;
            console.log(response);

            if (response.success) {
                swal.fire({
                    title: 'Success!',
                    text: response.message,
                    icon: 'success',
                    confirmButtonText: 'OK',
                });
            } else {
                swal.fire({
                    title: 'Error!',
                    text: response.message,
                    icon: 'error',
                    confirmButtonText: 'OK',
                });
            }

        }).catch(function (error) {
            swal.fire({
                title: 'Error!',
                text: 'An error occurred. Please try again.',
                icon: 'error',
                confirmButtonText: 'OK',
            });
        });
    };









    $scope.DateFormat = function (str) {
        var num = parseInt(str.replace(/[^0-9]/g, ""), 10);
        var date = new Date(num);

        var options = {
            year: 'numeric',
            month: 'long',
            day: '2-digit',
            hour: '2-digit',
            minute: '2-digit',
            hour12: true
        };

        return date.toLocaleString('en-US', options);
    };

    $scope.isModalOpen = false;
    $scope.newStatusName = '';

    // Open Modal
    $scope.openModal = function () {
        $scope.isModalOpen = true;
        console.log("Modal Opened");
    };

    // Close Modal
    $scope.closeModal = function () {
        $scope.isModalOpen = false;
        $scope.newStatusName = ''; // Reset form
        console.log("Modal Closed");
    };



    $scope.password2 = '';
    $scope.confirmPassword = '';
    $scope.showPassword = false;
    $scope.showConfirmPassword = false;
    $scope.email2 = '';


    $scope.confirmEmailFromURL = function () {
        var params = $location.search(); // gets all query parameters as an object
        $scope.userID = params.userID; //Get 'userID' directly from the URL query string
        var userID = $scope.userID
        console.log('Extracted userID:', userID);  // Log the extracted userID

        if (userID) {
            console.log('UserID found:', userID);

            // Call the service to confirm the email
            var sendConfirm = IPService.ConfirmEmail(userID)


            sendConfirm.then(function (response) {
                if (response.data.success) {
                    swal.fire({
                        title: 'Email Confirmed',
                        text: 'Your email has been successfully confirmed.',
                        icon: 'success',
                        confirmButtonText: 'OK',
                        timer: 2000
                    });
                } else {
                    swal.fire({
                        title: 'Error',
                        text: response.data.message,
                        icon: 'error',
                        confirmButtonText: 'OK'
                    });
                }
            }).catch(function (error) {
                swal.fire({
                    title: 'Error!',
                    text: 'An error occurred while confirming your email. Please try again.',
                    icon: 'error',
                    confirmButtonText: 'OK'
                });
            });
        } else {
            swal.fire({
                title: 'Error',
                text: 'Invalid link. No UserID found.',
                icon: 'error',
                confirmButtonText: 'OK'
            });
        }
    };


})