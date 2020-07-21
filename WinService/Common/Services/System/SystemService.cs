using Common.Services.Email.Dto;
using Common.Services.System.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.System
{
    public class SystemService 
    {
      //  public EmailAccountInformation GetSystemEmailSettings()
       // {
            //var sysParams = GetSystemParameters(new List<string>
            //{
            //    SystemConsts.SmtpServer,
            //    SystemConsts.SmtpUser,
            //    SystemConsts.SmtpPassword,
            //    SystemConsts.SmtpDefaultCredentials,
            //    SystemConsts.SmtpSsl,
            //    SystemConsts.SmtpPort,
            //    SystemConsts.EmailFrom
            //});

            //return new EmailAccountInformation
            //{
            //    SmtpServer = sysParams.Get(SystemConsts.SmtpServer),
            //    SmtpUser = sysParams.Get(SystemConsts.SmtpUser),
            //    SmtpPassword = sysParams.Get(SystemConsts.SmtpPassword),
            //    ShouldUseDefaultSmtpCredentials = sysParams.GetAs<bool>(SystemConsts.SmtpDefaultCredentials),
            //    SmtpSsl = sysParams.GetAs<bool>(SystemConsts.SmtpSsl),
            //    SmtpPort = sysParams.GetAs<int>(SystemConsts.SmtpPort),
            //    DefaultFromAddress = sysParams.Get(SystemConsts.EmailFrom)
            //};
      //  }

      //  private SystemParameterDictionary GetSystemParameters(IEnumerable<string> parameterCodes)
       // {
            //var output = new SystemParameterDictionary();

            //using (var dbContextScope = _dbContextScopeFactory.Create())
            //{
            //    var db = dbContextScope.DbContexts.Get<EBookingAppsContext>();

            //    //error object reference
            //    var systemParametersInDb = db.ms_system_parameter
            //        .Where(x => parameterCodes.Contains(x.ParameterCode))
            //        .Select(x => new { x.ParameterCode, x.ParameterValue })
            //        .ToList();

            //    var parameterCodesNotFoundInDb = parameterCodes
            //        .Where(parameterCode => !systemParametersInDb.Any(x => x.ParameterCode.Equals(parameterCode, StringComparison.InvariantCultureIgnoreCase)));

            //    if (parameterCodesNotFoundInDb.Any())
            //    {
            //        throw new InvalidOperationException($"The following system parameter codes could not be found: {string.Join(", ", parameterCodesNotFoundInDb)}.");
            //    }

            //    foreach (var codeAndValue in systemParametersInDb)
            //    {
            //        output.Add(codeAndValue.ParameterCode, codeAndValue.ParameterValue);
            //    }

              //  return output;
          //  }
       // }
    }
}
