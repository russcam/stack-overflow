# Exploring Stack Overflow data with the Elastic Stack

Explore the Stack Overflow data set with the Elastic Stack using this gentle introduction. Stack Overflow data is indexed using .NET Core, a cross platform, open source platform for building applications, using [NEST, the official Elasticsearch client for .NET](https://github.com/elastic/elasticsearch-net).

## Prerequisites

1. Download at least [Elasticsearch 7.3.2](https://www.elastic.co/downloads/elasticsearch)
2. Download at least [Kibana 7.3.2](https://www.elastic.co/downloads/kibana) _(version must match same version as Elasticsearch)_
3. Install [.NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
4. Download latest [Stack Overflow data set](https://archive.org/details/stackexchange)
    - Under 7Z files, choose `stackoverflow.com-Posts.7z` , `stackoverflow.com-Users.7z` and `stackoverflow.com-Badges.7z`
5. Unzip Stack Overflow data set to a directory. You'll need around 90GB of available space! 

## Building

1. Restore project Nuget package dependencies. In the solution root directory

    ```bat
    dotnet restore
    ```
2. Build the solution in Release configuration. In the solution root directory

    ```bat
    dotnet build -c Release
    ```

## Setting up Elasticsearch

1. Set the JVM heap size to at least 8GB, by adding the following to the `jvm.options` file in `config` directory within Elasticsearch home directory, and saving the file

    ```
    -Xms8g
    -Xmx8g
    ```
2. Start Elasticsearch using the `elasticsearch.[sh|bat]` file in `bin` directory within Elasticsearch home directory

    ```bat
    ./elasticsearch.bat
    ```

## Indexing data

1. Navigate to `StackOverflow.Indexer/bin/Release/netcoreapp2.2` directory from the root of the solution. There should be a compiled `StackOverflow.Indexer.dll` file in the directory from compiling the solution in previous steps.

2. Check available options for indexing posts or users using `--help` argument

    ```
    dotnet .\StackOverflow.Indexer.dll --help

    dotnet .\StackOverflow.Indexer.dll posts --help

    dotnet .\StackOverflow.Indexer.dll users --help

    dotnet .\StackOverflow.Indexer.dll tags --help
    ```

3. Index posts data

    ```
    dotnet .\StackOverflow.Indexer.dll posts -e "http://localhost:9200" -f "/path/to/Posts.xml"
    ```

    Wait ~90 minutes to index all questions and answers on a local single node Elasticsearch cluster

4. Index users data

    ```
    dotnet .\StackOverflow.Indexer.dll users -e "http://localhost:9200" -f "/path/to/Users.xml" -b "/path/to/Badges.xml"
    ```

    Wait ~15 minutes to index all users and their badges on a local single node Elasticsearch cluster

5. (Optional) Update answers with tags

    If you'd like to be able to filter both questions and answers using tags, it can be useful to denormalize question tags onto
    answers. The source data can be transformed before ingesting to do this, but can also be achieved using the update by query API

    ```
    dotnet .\StackOverflow.Indexer.dll tags -e "http://localhost:9200" -f "/path/to/Posts.xml"
    ```

    This can take a few hours. The `-s` argument can be used to change the number of concurrent updates, so depending on the performance of
    the cluster into which you're indexing, you may be able to increase this to speed up the process. 


## License

- Content of this repository made available under Apache 2.0 license.
- Stack Overflow data is made available under [Creative Commons Attribution-ShareAlike 4.0 International license](https://creativecommons.org/licenses/by-sa/4.0/).