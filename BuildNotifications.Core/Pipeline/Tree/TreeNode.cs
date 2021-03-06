﻿using System.Collections.Generic;

namespace BuildNotifications.Core.Pipeline.Tree
{
    internal abstract class TreeNode : IBuildTreeNode
    {
        protected TreeNode()
        {
            _childList = new List<IBuildTreeNode>();
        }

        public void AddChild(IBuildTreeNode node)
        {
            _childList.Add(node);
        }

        public void RemoveChild(IBuildTreeNode node)
        {
            _childList.Remove(node);
        }

        /// <inheritdoc />
        public IEnumerable<IBuildTreeNode> Children => _childList;

        private readonly List<IBuildTreeNode> _childList;
    }
}