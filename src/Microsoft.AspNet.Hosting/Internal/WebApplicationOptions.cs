﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNet.Hosting.Internal
{
    public class WebApplicationOptions
    {
        private const string OldEnvironmentKey = "ENV";

        public WebApplicationOptions()
        {
        }

        public WebApplicationOptions(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            Application = configuration[WebApplicationDefaults.ApplicationKey];
            DetailedErrors = ParseBool(configuration, WebApplicationDefaults.DetailedErrorsKey);
            CaptureStartupErrors = ParseBool(configuration, WebApplicationDefaults.CaptureStartupErrorsKey);
            Environment = configuration[WebApplicationDefaults.EnvironmentKey] ?? configuration[OldEnvironmentKey];
            ServerFactoryLocation = configuration[WebApplicationDefaults.ServerKey];
            WebRoot = configuration[WebApplicationDefaults.WebRootKey];
            ApplicationBasePath = configuration[WebApplicationDefaults.ApplicationBaseKey];
        }

        public string Application { get; set; }

        public bool DetailedErrors { get; set; }

        public bool CaptureStartupErrors { get; set; }

        public string Environment { get; set; }

        public string ServerFactoryLocation { get; set; }

        public string WebRoot { get; set; }

        public string ApplicationBasePath { get; set; }

        private static bool ParseBool(IConfiguration configuration, string key)
        {
            return string.Equals("true", configuration[key], StringComparison.OrdinalIgnoreCase)
                || string.Equals("1", configuration[key], StringComparison.OrdinalIgnoreCase);
        }
    }
}