using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace DGMLGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting DGML generation...");

                var assembly = typeof(TaskClass.TaskManager).Assembly;
                Console.WriteLine($"Assembly: {assembly.FullName}");

                var taskManagerType = assembly.GetType("TaskClass.TaskManager");
                if (taskManagerType == null)
                {
                    Console.WriteLine("TaskManager type not found.");
                    return;
                }
                Console.WriteLine("TaskManager type found.");

                // Additional logging for methods
                foreach (var method in taskManagerType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    Console.WriteLine($"Method: {method.Name}");
                }

                // Create a new DGML document
                XDocument dgml = new XDocument(
                     new XElement("DirectedGraph",
                     new XAttribute("GraphDirection", "LeftToRight"),
                     new XElement("Nodes"),
                     new XElement("Links")
                     )
                 );

                var nodes = dgml.Root.Element("Nodes");
                var links = dgml.Root.Element("Links");

                // Add TaskManager node
                nodes.Add(new XElement("Node", new XAttribute("Id", "TaskManager"), new XAttribute("Label", "TaskManager"), new XAttribute("Category", "Class")));

                // Add methods and their relationships
                foreach (var method in taskManagerType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    var methodName = method.Name;
                    var returnType = method.ReturnType.Name;
                    var parameters = method.GetParameters().Select(p => p.ParameterType.Name).ToArray();

                    // Add method node
                    nodes.Add(new XElement("Node", new XAttribute("Id", methodName), new XAttribute("Label", methodName), new XAttribute("Category", "Method")));

                    // Link TaskManager to method
                    links.Add(new XElement("Link", new XAttribute("Source", "TaskManager"), new XAttribute("Target", methodName)));

                    // Add return type node and link
                    if (!nodes.Elements("Node").Any(n => n.Attribute("Id").Value == returnType))
                    {
                        nodes.Add(new XElement("Node", new XAttribute("Id", returnType), new XAttribute("Label", returnType), new XAttribute("Category", "Type")));
                    }
                    links.Add(new XElement("Link", new XAttribute("Source", methodName), new XAttribute("Target", returnType)));

                    // Add parameter nodes and links
                    foreach (var param in parameters)
                    {
                        if (!nodes.Elements("Node").Any(n => n.Attribute("Id").Value == param))
                        {
                            nodes.Add(new XElement("Node", new XAttribute("Id", param), new XAttribute("Label", param), new XAttribute("Category", "Type")));
                        }
                        links.Add(new XElement("Link", new XAttribute("Source", param), new XAttribute("Target", methodName)));
                    }
                }

                // Save the DGML document to a file
                string filePath = "TaskManager.dgml";
                dgml.Save(filePath);
                Console.WriteLine($"DGML file saved to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

