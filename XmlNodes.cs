// See https://aka.ms/new-console-template for more information
using System.Xml;

namespace xmlnodes;

/// <summary>
/// Class responsible for parsing xml file
/// </summary>
public class XmlNodes
{
    /// <summary>
    /// Public endpoint for xmlnodes class
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public string Process(FileInfo file)
    {
        //test if filename exists
        if (!file.Exists)
        {
            return $"File {file} does not exist.";
        }

        //display the full path/name of the file
        Console.WriteLine(file.FullName);

        //Create xml document to parse
        XmlDocument xmlDocument = new XmlDocument();

        xmlDocument.Load(file.FullName);

        //parse and print
        PrintOutNodesRecursive(xmlDocument.DocumentElement, xmlDocument.DocumentElement.Name);

        //return a blank for successful
        return "";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public string Process(string url)
    {
        //Create xml document to parse
        XmlDocument xmlDocument = new XmlDocument();

        xmlDocument.Load(url);

        //parse and print
        PrintOutNodesRecursive(xmlDocument.DocumentElement, xmlDocument.DocumentElement.Name);

        //return a blank for successful
        return string.Empty;
    }

    /// <summary>
    /// Recursivly parse each node and write to console
    /// </summary>
    /// <param name="xmlElement"></param>
    /// <param name="currentStack"></param>
    private void PrintOutNodesRecursive(XmlElement xmlElement, string currentStack)
    {
        

        try
        {
            //loop attributes
            foreach (XmlAttribute xmlAttribute in xmlElement.Attributes)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{currentStack} >> ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{xmlAttribute.Name} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"= ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(xmlAttribute.Value);
            }

            //loop nodes
            foreach (XmlNode xmlNode in xmlElement.ChildNodes)
            {
                XmlElement xmlChildElement = xmlNode as XmlElement;
                XmlText xmlText = xmlNode as XmlText;

                if (xmlText != null)
                {
                    //print the node to the console
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{currentStack} ");
                    Console.Write($"= ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(xmlText.Value);
                }
                else if (xmlNode.NodeType == XmlNodeType.CDATA)
                {
                    //here we found there is no value but there is InnerXML so travers that xml
                    //clean up any \\r\\n from value
                    string cleaned = xmlNode.Value.Replace("\r\n", "");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{currentStack} ");
                    Console.Write($"= ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[[[{cleaned}]]]");
                }

                if (xmlChildElement != null)
                {
                    //recurse call ourself to traverse
                    PrintOutNodesRecursive(xmlChildElement, currentStack + " > " + xmlChildElement.Name);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}