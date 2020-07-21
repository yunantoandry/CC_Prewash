

using Common.Services.Email.Dto;
using System;
using System.Collections.Generic;

namespace Common.Services.System
{
    //TODO: Consider splitting this up.
    //- Step one, check which functions call the functions below. Double check
    //how they use them.
    //- Step two, reorganize them how you see fit.
    //public interface ISystemService
    //    : ISystemEmailSettingsGetter
    //{
    //    //XmlMessagingSettings GetXmlMessagingSettings();
    //    //FtpSessionCredentials GetFtpSessionCredentials();
    //    //XmlStorageFolders GetXmlStorageFolders();
    //    //DsvStorageFolders GetDsvStorageFolders();
    //    //T GetSystemParameters<T>(
    //    //    IEnumerable<string> systemParameterCodes,
    //    //    Func<SystemParameterDictionary, T> castToDto
    //    //) where T : class;
    //}

    //public interface ISystemEmailSettingsGetter
    //{
    //    EmailAccountInformation GetSystemEmailSettings();
    //}

}