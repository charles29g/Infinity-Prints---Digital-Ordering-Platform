using InfinityPrints.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net;
using MD5Hash;
using Org.BouncyCastle.Ocsp;

using System.Security.Cryptography;
using System.Text;
namespace InfinityPrints.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DashContent()
        {

            return View();
        }
        public ActionResult DashUsers()
        {

            return View();
        }

        public ActionResult DashService()
        {

            return View();
        }
        public ActionResult DashStatus()
        {

            return View();
        }
        public ActionResult DashReceipt()
        {

            return View();
        }
        public ActionResult DashOrderItem()
        {

            return View();
        }
        public ActionResult DashOrders()
        {

            return View();
        }
        public ActionResult DashLogs()
        {

            return View();
        }
        public ActionResult DashSizes()
        {

            return View();
        }

        public ActionResult DashPayments()
        {

            return View();
        }

        public ActionResult SignIn()
        {

            return View();
        }
        public ActionResult ConfirmationPage()
        {

            return View();
        }
        public ActionResult ForgotPasswordPage()
        {

            return View();
        }
        public JsonResult LoadServices()
        {
            using (var db = new InfinityPrintsContext())
            {

                var ServicesInfo = db.tbl_services
     .Select(services => new
     {
         services.ServiceID,
         services.ImagePath,
         services.ServiceName,
         services.Description,
         services.Material,
         services.Size,
         services.Price,
         services.CreatedAt,
         services.UpdatedAt,
     })
     .ToList();


                return Json(ServicesInfo, JsonRequestBehavior.AllowGet);
            }
        }






        public JsonResult LoadUsers()
        {
            using (var db = new InfinityPrintsContext())
            {

                var UsersInfo = db.tbl_users
     .Select(users => new
     {
         users.UserID,
         users.FName,
         users.LName,
         users.Email,
         users.PhoneNum,
         users.Password,
         users.UName,
         users.RoleID,
         users.CreatedAt,
         users.UpdatedAt,
     })
     .ToList();


                return Json(UsersInfo, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult LoadContents()
        {
            using (var db = new InfinityPrintsContext())
            {

                var ContentsInfo = db.tbl_content
     .Select(content => new
     {
         content.ContID,
         content.ContName,
         content.Desc,
         content.IMG_Path,
         content.CreatedAt,
         content.UpdatedAt,
     })
     .ToList();


                return Json(ContentsInfo, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult LoadStatus()
        {
            using (var db = new InfinityPrintsContext())
            {

                var StatusInfo = db.tbl_status
     .Select(content => new
     {
         content.StatID,
         content.StatName,
         content.CreatedAt,
         content.UpdatedAt,
     })
     .ToList();


                return Json(StatusInfo, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult LoadReceipts()
        {
            using (var db = new InfinityPrintsContext())
            {

                var ReceiptsInfo = db.tbl_receipts
     .Select(receipt => new
     {
         receipt.ReceiptID,
         receipt.UserID,
         receipt.OrderID,
         receipt.PaymentTerm,
         receipt.ReferenceNo,
         receipt.Balance,
         receipt.CreatedAt,
     })
     .ToList();


                return Json(ReceiptsInfo, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult LoadSizes()
        {
            using (var db = new InfinityPrintsContext())
            {

                var SizesInfo = db.tbl_sizes
     .Select(size => new
     {
         size.SizeID,
         size.ServiceID,
         size.SizeName,
         size.Price,
         size.CreatedAt,
         size.UpdatedAt
     })
     .ToList();


                return Json(SizesInfo, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult LoadLogs()
        {
            using (var db = new InfinityPrintsContext())
            {

                var LogsInfo = db.tbl_logs
     .Select(log => new
     {
         log.LogID,
         log.UserID,
         log.Action,
         log.CreatedAt,
     })
     .ToList();


                return Json(LogsInfo, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult LoadOrders()
        {
            using (var db = new InfinityPrintsContext())
            {

                var OrdersInfo = db.tbl_orders
     .Select(order => new
     {
         order.OrderID,
         order.UserID,
         order.FileQuantity,
         order.FilePath,
         order.Size,
         order.TotalPrice,
         order.Request,
         order.CreatedAt,
         order.StatusID,
     })
     .ToList();


                return Json(OrdersInfo, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult LoadPayments()
        {
            using (var db = new InfinityPrintsContext())
            {

                var PaymentsInfo = db.tbl_payments
     .Select(payment => new
     {
         payment.PaymentID,
         payment.ReferenceNo,
         payment.IMG_PayPath,
         payment.CreatedAt,

     })
     .ToList();


                return Json(PaymentsInfo, JsonRequestBehavior.AllowGet);
            }
        }



        // Simplified SendEmail action
        [HttpPost]
        public JsonResult SendEmailVerification(EmailData emailData)
        {
            if (string.IsNullOrEmpty(emailData.ToEmail) || string.IsNullOrEmpty(emailData.Subject) || string.IsNullOrEmpty(emailData.Body))
            {
                return Json(new { success = false, message = "Invalid email details." });
            }

            try
            {
                // Setting up SMTP client and sending the email directly
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("infinityprints.team@gmail.com", "yfof olpz bdkb vdjm"), // Use app password here
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("infinityprints.team@gmail.com"),
                    Subject = emailData.Subject,
                    Body = emailData.Body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(emailData.ToEmail);

                smtpClient.Send(mailMessage);  // Send email

                return Json(new { success = true, message = "Email sent successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error sending email: {ex.Message}" });
            }
        }







        public JsonResult InsertRegistration(tbl_usersModel regData, int? UserID)
        {
            System.Diagnostics.Debug.WriteLine(regData + "Home");

            using (InfinityPrintsContext db = new InfinityPrintsContext())
            {
                try
                {
                    // Check if the email already exists in the database
                    var existingUser = db.tbl_users.FirstOrDefault(u => u.Email == regData.Email);

                    if (existingUser != null)
                    {
                        // If email already exists, return an appropriate message
                        return Json(new { success = false, message = "The email you entered is already associated with another account. Please use a different email." }, JsonRequestBehavior.AllowGet);
                    }

                    // If email is unique, proceed with insertion
                    var salt = "InfinityPrints";
                    var hashedpassword = regData.Password.GetMD5WithSalt(salt);

                    var dbnew = new tbl_usersModel()
                    {



                        LName = regData.LName,
                        FName = regData.FName,
                        Email = regData.Email,
                        UName = regData.UName,
                        PhoneNum = regData.PhoneNum,
                        Password = hashedpassword,
                        RoleID = regData.RoleID,
                        CreatedAt = DateTime.Now,
                        IsActive = "",
                    };

                    db.tbl_users.Add(dbnew);
                    db.SaveChanges();

                    // Fetch the newly inserted UserID
                    int newUserId = dbnew.UserID;
                    var encrypted = newUserId.GetMD5WithSalt(salt);


                    return Json(new { success = true, message = "Please check your email for the confirmation link", userId = encrypted }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public JsonResult UpdatePassword(tbl_usersModel regData)
        {
            using (InfinityPrintsContext db = new InfinityPrintsContext())
            {
                try
                {
                    // Find the user by UserID
                    var existingUser = db.tbl_users.FirstOrDefault(u => u.UserID == regData.UserID);

                    if (existingUser == null)
                    {
                        // If the user does not exist, return an appropriate message
                        return Json(new { success = false, message = "User not found." }, JsonRequestBehavior.AllowGet);
                    }

                    // Update the password
                    existingUser.Password = regData.Password;
                    existingUser.UpdatedAt = DateTime.Now;
                    // Save changes to the database
                    db.SaveChanges();

                    return Json(new { success = true, message = "Password updated successfully." }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    // Handle any errors
                    return Json(new { success = false, message = $"An error occurred: {ex.Message}" }, JsonRequestBehavior.AllowGet);
                }
            }
        }


        public JsonResult ActivateUser(string userID)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userID))
                    return Json(new { success = false, message = "Invalid user ID." });

                var salt = "InfinityPrints";
                bool isUserFound = false;  // Flag to track if a user is found

                using (InfinityPrintsContext db = new InfinityPrintsContext())
                {
                    // Iterate through all users in the table
                    foreach (var user in db.tbl_users)
                    {
                        // Apply hashing logic outside of LINQ
                        var hashedUserID = user.UserID.GetMD5WithSalt(salt);

                        // Compare the hashed user ID with the input user ID
                        if (hashedUserID == userID)
                        {
                            isUserFound = true;

                            // Check if the user is already active
                            if (user.IsActive == "true")
                                return Json(new { success = false, message = "This link has already been used." });

                            // Activate the user
                            user.IsActive = "true";
                            user.UpdatedAt = DateTime.Now;

                            // Break out of the loop once the user is found and updated
                            break;
                        }
                    }

                    // If no matching user is found
                    if (!isUserFound)
                        return Json(new { success = false, message = "User not found." });

                    // Save changes only once after the loop
                    db.SaveChanges();

                    return Json(new { success = true, message = "User activated successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }








    }
}


