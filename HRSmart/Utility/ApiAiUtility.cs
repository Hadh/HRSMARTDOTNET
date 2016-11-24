using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiAiSDK;

namespace HRSmart.Utility
{
    public class ApiAiUtility
    {
        public ApiAi Ai { get; set; }

        public ApiAiUtility()
        {
            var config = new AIConfiguration("2b4219f782904d6a996efcc54b5742fe", SupportedLanguage.English);
            this.Ai = new ApiAi(config);
        }
    }
}