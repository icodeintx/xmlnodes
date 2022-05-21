# xmlnodes

Traverse through an xml file and print a text representation of the nodes/attributes

> Currently .Net Core 6.0

```text
Description:
  App to parse XML nodes

Usage:
  xmlnodes [command] [options]

Options:
  --version       Show version information
  -?, -h, --help  Show help and usage information

Commands:
  file <--file>  Parse xml in a local file
  url <--url>    Parse xml from the web

```


The output below displays the nodes and attributes.

```text
>   Indicates nodes
>>  Indicates attributes
=   Indicates value of node or attribute
```


## output

```text
catalog > book >> id = bk101
catalog > book > author = Gambardella, Matthew
catalog > book > title = XML Developer's Guide
catalog > book > genre = Computer
catalog > book > price = 44.95
catalog > book > publish_date = 2000-10-01
catalog > book > description = An in-depth look at creating applications
      with XML.
catalog > book >> id = bk102
catalog > book > author = Ralls, Kim
catalog > book > title = Midnight Rain
catalog > book > genre = Fantasy
catalog > book > price = 5.95
catalog > book > publish_date = 2000-12-16
catalog > book > description = A former architect battles corporate zombies,
      an evil sorceress, and her own childhood to become queen
      of the world.
```      
