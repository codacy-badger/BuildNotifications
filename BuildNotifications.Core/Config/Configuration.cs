﻿using System.Collections.Generic;
using System.Globalization;
using BuildNotifications.Core.Pipeline.Tree;

namespace BuildNotifications.Core.Config
{
    internal class Configuration : IConfiguration
    {
        public Configuration()
        {
            Projects = new List<IProjectConfiguration>();
            Connections = new List<IConnectionData>();

            BuildsToLoadCount = 200;
            BuildsToShow = 5;
            UpdateInterval = 30;
            CanceledBuildNotifyConfig = BuildNotificationMode.RequestedByMe;
            SucceededBuildNotifyConfig = BuildNotificationMode.RequestedByMe;
            FailedBuildNotifyConfig = BuildNotificationMode.RequestedByOrForMe;

            GroupDefinition = new BuildTreeGroupDefinition(
                Pipeline.Tree.GroupDefinition.Source,
                Pipeline.Tree.GroupDefinition.Branch,
                Pipeline.Tree.GroupDefinition.BuildDefinition);

            Culture = CultureInfo.GetCultureInfo("en-US");
        }

        /// <inheritdoc />
        public int BuildsToLoadCount { get; set; }

        /// <inheritdoc />
        public int BuildsToShow { get; set; }

        /// <inheritdoc />
        public BuildNotificationMode CanceledBuildNotifyConfig { get; set; }

        /// <inheritdoc />
        public IList<IConnectionData> Connections { get; set; }

        /// <inheritdoc />
        public CultureInfo Culture { get; set; }

        /// <inheritdoc />
        public IList<IProjectConfiguration> Projects { get; set; }

        /// <inheritdoc />
        public BuildNotificationMode FailedBuildNotifyConfig { get; set; }

        /// <inheritdoc />
        public BuildNotificationMode SucceededBuildNotifyConfig { get; set; }

        /// <inheritdoc />
        public IBuildTreeGroupDefinition GroupDefinition { get; }

        /// <inheritdoc />
        public int UpdateInterval { get; set; }
    }
}