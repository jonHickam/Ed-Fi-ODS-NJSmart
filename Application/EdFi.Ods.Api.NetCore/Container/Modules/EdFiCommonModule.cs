﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.NetCore.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.IO;

namespace EdFi.Ods.Api.NetCore.Container.Modules
{
    public class EdFiCommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AssembliesProvider>().As<IAssembliesProvider>();
            builder.RegisterType<FileSystemWrapper>().As<IFileSystem>();
            builder.RegisterType<ConfigConnectionStringsProvider>().As<IConfigConnectionStringsProvider>();
            builder.RegisterType<AppConfigValueProvider>().As<IConfigValueProvider>();
            builder.RegisterType<DefaultPageSizeLimitProvider>().As<IDefaultPageSizeLimitProvider>();
            builder.RegisterType<DatabaseEngineProvider>().As<IDatabaseEngineProvider>();
        }
    }
}
