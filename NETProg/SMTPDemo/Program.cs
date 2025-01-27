// See https://aka.ms/new-console-template for more information
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;


Console.WriteLine("Hello, World!");
//IConfigurationRoot? configurationRoot;
//IConfigurationRoot Configuration()

//    {
//        if (configurationRoot == null)
//        {
//            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
//            //Determines the working environment as IHostingEnvironment is unavailable in a console app
//            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
//                                 devEnvironmentVariable.ToLower() == "development";
//            var builder = new ConfigurationBuilder();
//            // tell the builder to look for the appsettings.json file
//            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//            //only add secrets in development
//            if (isDevelopment)
//            {
//                builder.AddUserSecrets<Program>();
//            }
//            configurationRoot = builder.Build();
//            //dbProvider = configurationRoot["DbProvider"];

//        }
//        return configurationRoot;
//    }


async Task SendEmailAsync(string email, string subject, string message)
{
    //var MailServer = Configuration().GetSection("MailServer");
    //if (!MailServer.Exists())
    //{
    //    //_logger.LogError("MailServer not configured");
    //    return;
    //}


    var pass = "password";//MailServer.GetValue<string>("Pass");
    var login = "user"; // MailServer.GetValue<string>("Login");
    var port = 25;//  MailServer.GetValue<int>("Port");
    var host = "localhost";//MailServer.GetValue<string>("SMTPHost");

    var smtpClient = new SmtpClient()
    {
        Host = host, // set your SMTP server name here
        Port = port, // Port 
        EnableSsl = false,
        Credentials = new NetworkCredential(login, pass)
    };

    using (var mail = new MailMessage("user@localdomain", email, subject, message))
    {
        mail.IsBodyHtml = true;
        await smtpClient.SendMailAsync(mail);
    }

}

await SendEmailAsync("user@localdomain", "test", "Test mail");


 