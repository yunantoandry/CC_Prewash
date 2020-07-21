using Common.Services.Email.Dto;
using Common.Services.System;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Email
{
    public class SendHealthCheckEmailsCommand
    {
        public IList<string> ToAddresses { get; set; }

        public SendHealthCheckEmailsCommand()
        {
            ToAddresses = new List<string>();
        }

        public SendHealthCheckEmailsCommand(IList<string> toAddresses)
        {
            ToAddresses = toAddresses ?? new List<string>();
        }
    }
    public class SendEmailsReportingRiskCommander
    {
      //  private readonly GetInventory3plQuerier _getInventory3pl;

        private readonly IEmailCreator _emailCreator;
        private readonly IEmailSender _emailSender;
        private readonly ICurrentDateTimeService _currentDateTimeService;
        // private readonly IDsvCreator _dsvCreator;
      //  private readonly ISystemService _systemService;
      //  private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly ILog _log;

        public SendEmailsReportingRiskCommander(
            IEmailCreator emailCreator,
            IEmailSender emailSender,
            ICurrentDateTimeService currentDateTimeService,
            //IDsvCreator dsvCreator,
          //  ISystemService systemService,
            //IDbContextScopeFactory dbContextScopeFactory,
            ILog log
        )
        {
          //  _getInventory3pl = new GetInventory3plQuerier();

            _emailCreator = emailCreator ?? throw new ArgumentNullException(nameof(emailCreator));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _currentDateTimeService = currentDateTimeService ?? throw new ArgumentNullException(nameof(currentDateTimeService));
            //_dsvCreator = dsvCreator ?? throw new ArgumentNullException(nameof(dsvCreator));
          //  _systemService = systemService ?? throw new ArgumentNullException(nameof(systemService));
            //_dbContextScopeFactory = dbContextScopeFactory ?? throw new ArgumentNullException(nameof(dbContextScopeFactory));
             
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public SendEmailsReportingRiskCommander()
        {
            //_getInventory3pl = new GetInventory3plQuerier();

            //_dsvCreator = new DsvCreator();
            _emailCreator = new EmailCreator();
            _emailSender = new EmailSender();
            _currentDateTimeService = new CurrentDateTimeService();
        //    _systemService = new SystemService();
            //_dbContextScopeFactory = new DbContextScopeFactory();
            _log = LogManager.GetLogger(typeof(SendEmailsReportingRiskCommander));
        }

        public void Handle(SendHealthCheckEmailsCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (command?.ToAddresses == null) throw new ArgumentNullException($"{nameof(command)}.{nameof(command.ToAddresses)}");

            _log.Info($"Sending health check emails.");

        //    var emailSettings = _systemService.GetSystemEmailSettings();

            _log.Info($"Querying database.");

            var today = _currentDateTimeService.LocalToday();

            //var ordersHealthCheck = _getOrdersHealthCheck.Query(new GetOrdersHealthCheckQuery
            //{
            //    MinimumDate = today
            //});
            //var reportDpWindowBook = _getReportDpWindowBook.Query(new GetReportDpWindowBookQuery
            //{
            //    Date = today
            //});
            //var unscheduledBookings = _getUnscheduledBookings.Query();

            // NOTE: Don't use the standard DSV delimiter (which as of
            // 2019-03-05 is a pipe). Force it to use a comma.

            //var ordersHealthCheckCsv = _dsvCreator.CreateDsv(ordersHealthCheck, ",", isExcelFriendly: true);
            //var reportDpWindowBookCsv = _dsvCreator.CreateDsv(reportDpWindowBook, ",", isExcelFriendly: true);
            //var unscheduledBookingsCsv = _dsvCreator.CreateDsv(unscheduledBookings, ",", isExcelFriendly: true);

            var dateString = _currentDateTimeService.LocalNow()
                .ToString("yyyy-MM-dd_HH-mm-ss");

            //using (var ordersHealthCheckCsvStream = ordersHealthCheckCsv.ToUnicodeStream())
            //using (var reportDpWindowBookCsvStream = reportDpWindowBookCsv.ToUnicodeStream())
            //using (var unscheduledBookingsCsvStream = unscheduledBookingsCsv.ToUnicodeStream())
            //{
                _log.Info($"Creating email.");

                var email = _emailCreator.CreateMailMessage(new CreateMailMessageInput
                {
                  //  FromAddress = emailSettings.DefaultFromAddress,
                    ToAddresses = command.ToAddresses,
                    Subject = "Supplier Portal Health Check",
                    Body = "This is the daily health check email.",
                    Attachments = new List<Attachment>
                        {
                         new Attachment("c:/textfile.txt"),
                       //  new Attachment(ordersHealthCheckCsvStream, $"orders-health-check-{dateString}.csv", "text/csv"),
                            //new Attachment(reportDpWindowBookCsvStream, $"report-dp-window-book-{dateString}.csv", "text/csv"),
                            new Attachment("c:/textfile.txt")


                        }
                });

                _log.Info($"Sending email.");

             //   _emailSender.SendMailMessage(
                //    email
                  //  emailSettings
               // );
           // }
        }
    }
}
