using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiAiSDK;

namespace HRSmart.Utility
{
    public class ApiAiUtility
    {
        private ApiAi ai;

        public ApiAiUtility()
        {
            var config = new AIConfiguration("2b4219f782904d6a996efcc54b5742fe", SupportedLanguage.English);
            ai = new ApiAi(config);
        }
    }
}