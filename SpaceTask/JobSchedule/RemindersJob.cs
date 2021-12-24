using Microsoft.Extensions.Configuration;
using Quartz;
using SpaceTask.Controllers;
using SpaceTask.Model.Request;
using SpaceTask.Services;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace SpaceTask.JobSchedule
{
    public class RemindersJob : IJob
    {
        private readonly IMovieService _movieService;
        IConfiguration _configuration;
        private readonly IServiceProvider _provider;
        public RemindersJob(IServiceProvider provider, IConfiguration iConfig, IMovieService movieService)
        {

            _configuration = iConfig;
            _provider = provider;
            _movieService = movieService;

        }
        public Task Execute(IJobExecutionContext context)
        {
            SendMail();
            return Task.CompletedTask;
        }
        public void SendMail()
        {
           
            var getMovieList = _movieService.GetUnWatchedMoviesList();
            foreach (var movie in getMovieList)
            {
                string FromAddress = movie.Email;
                string ToAddress = movie.Email;
                string Pass = _configuration.GetValue<string>("Password");
                var fromAddress = new MailAddress(FromAddress, "From Name");
                var toAddress = new MailAddress(ToAddress, "To Name");
                const string subject = "Offer";
                string body = String.Format("Name : {0}\n"+"Description :  {1}\n" + "FilmRate :  {2} ", movie.FilmName, movie.Description, movie.FilmRate);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, Pass)
                };
                using (var msg = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(msg);
                }

            }            
        }
    }
}
