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
        //xmlDocument.Load(file.FullName);

        //parse and print
        PrintOutNodesRecursive(xmlDocument.DocumentElement, xmlDocument.DocumentElement.Name);

        //return a blank for successful
        return "";
    }


    /// <summary>
    /// Recursivly parse each node and write to console
    /// </summary>
    /// <param name="xmlElement"></param>
    /// <param name="currentStack"></param>
    private void PrintOutNodesRecursive(XmlElement xmlElement, string currentStack)
    {
        //loop attributes
        foreach (XmlAttribute xmlAttribute in xmlElement.Attributes)
        {
            Console.WriteLine("{0} >> {1} = {2}", currentStack, xmlAttribute.Name, xmlAttribute.Value);
        }

        //loop nodes
        foreach (XmlNode xmlNode in xmlElement.ChildNodes)
        {
            XmlElement xmlChildElement = xmlNode as XmlElement;
            XmlText xmlText = xmlNode as XmlText;

            if (xmlText != null)
            {
                //print the node to the console
                Console.WriteLine("{0} = {1}", currentStack, xmlText.Value);
            }

            if (xmlChildElement != null)
            {
                //recurse call ourself to traverse
                PrintOutNodesRecursive(xmlChildElement, currentStack + " > " + xmlChildElement.Name);
            }
        }
    }

}




