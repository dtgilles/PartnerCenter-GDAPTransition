﻿

using Microsoft.Identity.Client;

namespace PartnerLed
{
    internal class AppSetting
    {
        public AppSetting() => init();

        public IPublicClientApplication InteractiveApp { get; set; }

        public string GdapBaseEndPoint { get; private set; }

        public string MicrosoftGraphBaseEndpoint { get; private set; }

        public HttpClient Client { get { return new HttpClient(); } }

        public string GdapRefreshToken { get; set; }

        private void init()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            AppSettingsConfiguration config;

            if (string.IsNullOrEmpty(env))
            {
                config = AppSettingsConfiguration.ReadFromJsonFile($"appsettings.json");
            }
            else
            {
                config = AppSettingsConfiguration.ReadFromJsonFile($"appsettings.{env}.json");
            }

            var appConfig = config.PublicClientApplicationOptions;
            GdapBaseEndPoint = config.GdapEndPoint;
            MicrosoftGraphBaseEndpoint = config.MicrosoftGraphBaseEndpoint;
            InteractiveApp = PublicClientApplicationBuilder
                        .CreateWithApplicationOptions(appConfig)
                        .WithDefaultRedirectUri().WithExtraQueryParameters(new Dictionary<string, string>(){ { "acr_values", "urn:microsoft:policies:mfa" } }).Build();
        }
    }
}
