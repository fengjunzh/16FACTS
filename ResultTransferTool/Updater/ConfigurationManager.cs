using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Updater
{
    public class ConfigurationManager
    {
        private readonly string _filePath;
        private string _server;
        private readonly List<Component> _components = new List<Component>();
        private string _versionSubFolder;
        private string _callerNamme;
        public string CallerName => _callerNamme;
        public string VersionSubFolder => _versionSubFolder;
        public string Server => _server;
        public string ServerVersion { get; set; } //adam add
        public Component[] Components => _components.ToArray();

        public ConfigurationManager()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", "Components.xml");
            ReadConfigurations();
        }

        private void ReadConfigurations()
        {
            var xDoc = XDocument.Load(_filePath);
            var root = xDoc.Root;
            _server = root.Element("Connection").Element("Server").Value;
            _versionSubFolder = root.Element("Connection").Element("VersionSubFolder").Value;
            _callerNamme = root.Element("Connection").Element("CallerProcessName").Value;
            foreach (var componentElement in root.Element("Components").Elements("Component"))
            {
                var component = new Component();
                component.Source = componentElement.Element("Source").Value;
                component.Target = componentElement.Element("Target").Value;
                _components.Add(component);
            }
            xDoc = XDocument.Load(Path.Combine(_server, "ServerVersion.xml"));
            ServerVersion =xDoc.Root.Element("ServerVersion").Value;
        }
    }

    public class Component
    {
        public string Source;
        public string Target;
    }
}
