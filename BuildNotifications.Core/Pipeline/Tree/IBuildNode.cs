﻿using BuildNotifications.PluginInterfaces.Builds;

namespace BuildNotifications.Core.Pipeline.Tree
{
    internal interface IBuildNode : IBuildTreeNode
    {
        IBuild Build { get; }
    }
}