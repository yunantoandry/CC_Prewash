using System.Collections.Generic;

namespace Common.Services.System.Dto
{
    public class SystemEmailTemplates
    {
        // Email parameters
        // Who to email when the XMLs complete.

        public string DPSubjectVendorGetSlot { get; set; }
        public string DPEmailVendorGetSlot { get; set; }
        public string DPSubjectAdmin { get; set; }
        public string DPEmailAdmin { get; set; }
        public IList<string> DPAdminEmailTo { get; set; }

        public SystemEmailTemplates()
        {
            DPAdminEmailTo = new List<string>();
        }
    }
}
