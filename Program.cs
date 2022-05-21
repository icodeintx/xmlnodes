using System.Xml;
using System.CommandLine;
using System;

namespace xmlnodes;


/// <summary>
/// Application Entry class
/// </summary>
public class Program
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {

        //create our file option
        var fileArgument = new Argument<FileInfo?>(
            name: "--file", 
            description: "The xml file to read and display on the console.");

        //create url option
        var urlArgument = new Argument<string>(
            name: "--url", 
            description: "The xml URL to read and display on the console.");
        

        //setup File Command
        var fileCommand = new Command("file", "Parse xml in a local file");
        fileCommand.AddArgument(fileArgument);

        //setup URL command
        var urlCommand = new Command("url", "Parse xml from the web");
        urlCommand.AddArgument(urlArgument);

        //create our root command and add the option
        var rootCommand = new RootCommand("App to parse XML nodes");

        rootCommand.AddCommand(fileCommand);
        rootCommand.AddCommand(urlCommand);

        
        //clear approach https://intellitect.com/blog/demystified-system-commandline/
        
        fileCommand.SetHandler((FileInfo file) => 
            {
                ReadFile(file);
            }, fileArgument);



        urlCommand.SetHandler((string url) => 
            {
                ReadUrl(url);
            }, urlArgument);



        //invoke the commandline 
        rootCommand.Invoke(args);
        

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    static void ReadUrl(string url)
    {
        try
        {
            //create instand of the xml parser class
            XmlNodes xml = new();
            
            //call the parser entry point and pass the file to parse
            var errorText = xml.Process(url);

            //if the process returned a string write it to console
            if (!string.IsNullOrEmpty(errorText))
            {
                Console.WriteLine($"Error: {errorText}");
            }                
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Method responsible for calling the XML parser
    /// </summary>
    /// <param name="file"></param>
    static void ReadFile(FileInfo file)
    {
        try
        {
            //create instand of the xml parser class
            XmlNodes xml = new();
            
            //call the parser entry point and pass the file to parse
            var errorText = xml.Process(file);

            //if the process returned a string write it to console
            if (!string.IsNullOrEmpty(errorText))
            {
                Console.WriteLine($"Error: {errorText}");
            }                
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}




