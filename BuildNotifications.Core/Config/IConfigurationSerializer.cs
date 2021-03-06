﻿namespace BuildNotifications.Core.Config
{
    /// <summary>
    /// (De)serializes configurations from and to a file.
    /// </summary>
    internal interface IConfigurationSerializer
    {
        /// <summary>
        /// Load configuration from file. If file does not exist,
        /// default configuration will be returned.
        /// </summary>
        /// <param name="fileName">Path to the file to load from.</param>
        /// <returns>The loaded configuration.</returns>
        IConfiguration Load(string fileName);

        /// <summary>
        /// Saves a configuration to a file.
        /// </summary>
        /// <param name="configuration">Configuration to save.</param>
        /// <param name="fileName">Path to the file to save to.</param>
        void Save(IConfiguration configuration, string fileName);
    }
}