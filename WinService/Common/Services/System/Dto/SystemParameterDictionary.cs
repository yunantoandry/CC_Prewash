using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common.Services.System.Dto
{
    /// <summary>
    /// Represents a Dictionary where the keys are case insensitive that stores
    /// quer results from the MS_SYSTEM_PARAMETER table.
    /// </summary>
    public class SystemParameterDictionary
    {
        private IDictionary<string, string> _contents;

        public SystemParameterDictionary()
        {
            _contents = new Dictionary<string, string>();
        }

        /// <summary>
        /// Add new system parameter to this dictionary.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, string value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (value == null) throw new ArgumentNullException(nameof(value));

            var existingKey = _contents.Keys.FirstOrDefault(x => x.Equals(key, StringComparison.InvariantCultureIgnoreCase));

            if (existingKey == null)
            {
                _contents.Add(key, value);
            }
            else
            {
                throw new InvalidOperationException($"Cannot add an item with key '{key}' because there is already another key called '{existingKey}'.");
            }
        }

        /// <summary>
        /// Get a string given a certain key. If no match is found, return null.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            if (key == null) return null;

            var matchingKey = GetCaselessKey(key);

            if (matchingKey != null)
            {
                return _contents[matchingKey];
            }
            else
            {
                throw new InvalidOperationException($"Could not find case-insensitive key called '{key}' in system parameters table.");
            }
        }

        /// <summary>
        /// Get a string given a certain key. If no match is found, return null.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string TryGet(string key)
        {
            if (key == null) return null;

            var matchingKey = GetCaselessKey(key);

            if (matchingKey != null)
            {
                return _contents[matchingKey];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get a certain Typed object given a certain key. If no match is
        /// found, return the default for that object.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetAs<T>(string key)
            where T : struct
        {
            var desiredType = typeof(T);

            var matchingKey = GetCaselessKey(key);

            if (matchingKey != null)
            {
                try
                {
                    return (T)Convert.ChangeType(_contents[matchingKey], desiredType);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Could not convert item with key '{key}' into type {desiredType} from system parameters table.");
                }
            }
            else
            {
                return (T)Activator.CreateInstance(desiredType);
            }
        }

        /// <summary>
        /// Get a string given a certain key. If no match is found, return an
        /// empty list, otherwise, split that string using the seperator into a
        /// list of strings.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IList<string> GetAsList(string key, char seperator)
        {
            if (key == null) return new List<string>();

            var matchingKey = GetCaselessKey(key);

            if (matchingKey != null)
            {
                var value = _contents[matchingKey];
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException($"Found case-insensitive key called '{key}' in system parameters table but cannot convert into list because it is null or empty.");
                }
                else
                {
                    return value
                        .Split(seperator)
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x => x.Trim())
                        .ToList();
                }
            }
            else
            {
                throw new InvalidOperationException($"Could not find case-insensitive key called '{key}' in system parameters table.");
            }
        }

        /// <summary>
        /// Get a string given a certain key whose format is something like this
        /// 
        /// "SOURCE_FOLDER;DESTINATION_FOLDER"
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public FtpUploadParameter GetFtpUploadParameter(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            return new FtpUploadParameter(Get(key));
        }

        /// <summary>
        /// There are times where the data stored in the database only aims at
        /// a parent folder and the specific subfolder is ommited. Use this as
        /// a shortcut to combine the parent folder of a certain ParameterCode
        /// with a hardcoded subfolder.
        /// </summary>
        /// <param name="mainFolder"></param>
        /// <param name="subFolder"></param>
        /// <returns></returns>
        public string GetCombinedPath(string mainFolder, string subFolder)
        {
            return Path.Combine(Get(mainFolder), subFolder);
        }

        public HourAndMinuteDto GetHourAndMinute(string key)
        {
            return new HourAndMinuteDto(Get(key));
        }

        private string GetCaselessKey(string key)
        {
            return _contents.Keys.FirstOrDefault(x => x.Equals(key, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
