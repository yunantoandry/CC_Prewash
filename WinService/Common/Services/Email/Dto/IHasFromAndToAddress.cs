using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Email.Dto
{
    public interface IHasFromAndToAddress
    {
        string FromAddress { get; set; }
        IEnumerable<string> ToAddresses { get; set; }
    }
}
