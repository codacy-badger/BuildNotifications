﻿using System.Collections.Generic;
using System.Linq;
using Anotar.NLog;
using BuildNotifications.Core.Utilities;
using BuildNotifications.PluginInterfaces.Builds;
using BuildNotifications.PluginInterfaces.SourceControl;

namespace BuildNotifications.Core.Plugin
{
    internal class PluginRepository : IPluginRepository
    {
        /// <inheritdoc />
        public PluginRepository(IReadOnlyList<IBuildPlugin> build, IReadOnlyList<ISourceControlPlugin> sourceControl, ITypeMatcher typeMatcher)
        {
            Build = build;
            SourceControl = sourceControl;
            _typeMatcher = typeMatcher;
        }

        /// <inheritdoc />
        public IReadOnlyList<IBuildPlugin> Build { get; }

        /// <inheritdoc />
        public IReadOnlyList<ISourceControlPlugin> SourceControl { get; }

        /// <inheritdoc />
        public IBuildPlugin? FindBuildPlugin(string typeName)
        {
            var plugin = Build.FirstOrDefault(t => _typeMatcher.MatchesType(t.GetType(), typeName));
            if (plugin == null)
            {
                LogTo.Warn($"Failed to find build plugin for type {typeName}");
            }

            return plugin;
        }

        /// <inheritdoc />
        public ISourceControlPlugin? FindSourceControlPlugin(string typeName)
        {
            var plugin = SourceControl.FirstOrDefault(t => _typeMatcher.MatchesType(t.GetType(), typeName));
            if (plugin == null)
            {
                LogTo.Warn($"Failed to find source control plugin for type {typeName}");
            }

            return plugin;
        }

        private readonly ITypeMatcher _typeMatcher;
    }
}