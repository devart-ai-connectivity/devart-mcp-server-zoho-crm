[![Devart MCP Server for Zoho CRM](https://github.com/devart-ai-connectivity/.github/blob/main/assets/cover-banner-mcp-server-for-zoho-crm.webp?raw=true)](https://www.devart.com/mcp/)

# Devart MCP Server for Zoho CRM

Devart MCP Server for Zoho CRM enables AI clients to interact with your data through a secure server running in your environment. It turns a regular AI chat into a practical way to work with real-world business data — and it is faster than conventional export or manual querying.

## Key benefits

Devart MCP Server for Zoho CRM allows you to:

* Work with data intuitively through natural language.
* Retrieve the required data for analysis within minutes.
* Report on your data faster with AI-powered assistance.
* Minimize manual data handling and integration maintenance.

## How it works

Devart MCP Server for Zoho CRM helps AI clients communicate directly with Zoho CRM databases using natural-language prompts. It translates AI requests into structured queries, executes them through Devart connectivity drivers, and returns clean, structured results for seamless AI-powered data access.

![Devart MCP Server architecture](https://github.com/devart-ai-connectivity/.github/blob/main/assets/how_mcp_works_single.webp?raw=true)

## Quick start

To get started with Devart MCP Server for Zoho CRM:

1\. [Download](https://www.devart.com/odbc/zoho/download.html) and [install](https://docs.devart.com/odbc/zoho/installation-clouds.htm) Devart ODBC Driver for Zoho CRM.

2\. [Download](https://www.devart.com/mcp/download.html) and [install](https://docs.devart.com/mcp/installation.html) Devart MCP Server for Zoho CRM.

3\. In Devart MCP Server for Zoho CRM, [configure your data connection and integration settings](https://docs.devart.com/mcp/connection-configuration.html).

![Devart MCP Server configuration](https://github.com/devart-ai-connectivity/.github/blob/main/assets/mcp-servers-gui.webp?raw=true)

4\. Run your first natural-language query.

[![Need an MCP Server for multiple data sources?](https://github.com/devart-ai-connectivity/.github/blob/main/assets/need-mcp-server-universal.webp?raw=true)](https://www.devart.com/mcp/universal/)


## Manual installation and configuration 

**Prerequisites** 

Before building and running Devart MCP Server for Zoho CRM, ensure the following components are installed:

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* **ADO.NET connection** — **Devart.AI.McpServer.AdoNet.ZohoCrm.csproj** Devart dotConnect for Zoho CRM (installed automatically via NuGet during build)
* **ODBC connection** — **Devart.AI.McpServer.Odbc.ZohoCrm.csproj** [Devart ODBC Driver for Zoho CRM](https://www.devart.com/odbc/zoho/download.html) (requires manual download and installation)

**Step 1: Clone the repository**

Clone the project repository and navigate to the project directory:

1\. Open **Command Prompt**.

2\. Enter the following command:

```cmd
git clone https://github.com/devart-ai-connectivity/devart-mcp-server-zoho-crm.git
cd devart-mcp-server-zoho-crm
```

**Step 2: Build the MCP Server from source**

You can build Devart MCP Server for Zoho CRM from source using either of the supported database connectivity technologies: ADO.NET or ODBC.

* To build the MCP server with ADO.NET, run the following command:

```cmd
dotnet publish Devart.AI.McpServer.AdoNet/Devart.AI.McpServer.AdoNet.ZohoCrm/Devart.AI.McpServer.AdoNet.ZohoCrm.csproj -c ReleaseZohoCrm /p:TargetFramework=net8.0
```
The Devart dotConnect for Zoho CRM NuGet package is downloaded and restored automatically.

* To build the MCP server with ODBC, select the command based on the bitness of your data source.

For 64-bit data source, run the following command:

```cmd
dotnet publish Devart.AI.McpServer.Odbc/Devart.AI.McpServer.Odbc.ZohoCrm/Devart.AI.McpServer.Odbc.ZohoCrm.csproj -c ReleaseZohoCrm -r "win-x64" /p:TargetFramework=net8.0
```

For 32-bit data source, run the following command:

```cmd
dotnet publish Devart.AI.McpServer.Odbc/Devart.AI.McpServer.Odbc.ZohoCrm/Devart.AI.McpServer.Odbc.ZohoCrm.csproj -c ReleaseZohoCrm -r "win-x86" /p:TargetFramework=net8.0
```
>**Note**
>
>The target platform must match the bitness of your ODBC data source.

**Step 3: Configure the database connection for the MCP Server**

1\. Create an `mcpserver.json` configuration file in the directory containing the built MCP Server executable.

2\. In the file, configure the database connection.

* Configure a connection with ADO.NET.

Add the following configuration to the `mcpserver.json` file:

```json
{
  "Connections": [
    {
      "Name": "my_zohocrm",
      "ConnectionString": "Server=localhost;User Id=zohocrm;Password=your_password;Database=your_database;",
      "ProtocolType": "stdio"
    }
  ]
}
```

* Configure a connection with ODBC.

Add the following configuration to the `mcpserver.json` file:

```json
{
  "Connections": [
    {
      "Name": "my_zohocrm",
      "DsnName": "your_dsn_name",
      "ProtocolType": "stdio"
    }
  ]
}
```

* Configure a connection with ODBC using a connection string.

Add the following configuration to the `mcpserver.json` file:

```json
{
  "Connections": [
    {
      "Name": "my_zohocrm",
      "ConnectionString": "Driver={Devart ODBC Driver for Zoho CRM};Server=localhost;User ID=zohocrm;Password=your_password;Database=your_database;",
      "ProtocolType": "stdio"
    }
  ]
}
```
where:

* `Name` — The connection name.

* `ConnectionString` (applies to ADO.NET) — A database-specific connection string used to establish a connection to the target database.

* `DsnName` (applies to ODBC) — The name of your data source.

* `ProtocolType` — A transport protocol. The possible options are: `stdio` or `http`.

* `HttpPort` (required if `ProtocolType` is set to `http`) — The port number for the `http` protocol. 

**Step 4: Run the MCP server**

After you configure the MCP Server, you can start it. 

>**Note**
>
>This step is required only when `ProtocolType` is configured as `http`. If you use the `stdio` transport protocol, your AI client starts the server automatically.

* To start the server with ADO.NET, run the following command:

```cmd
Devart.AI.McpServer.AdoNet.ZohoCrm.exe run my_zohocrm
```

* To start the server with ODBC, run the following command:

```cmd
Devart.AI.McpServer.Odbc.ZohoCrm.exe run my_zohocrm
```

where `my_zohocrm` is the name of the ODBC connection.

**Step 5: Integrate with Claude Desktop**

1\. Open `claude_desktop_config.json`, the Claude configuration file.

>**Tip**
>
>If you can't locate the configuration file, it may not exist yet. To create it, open Claude Desktop and navigate to **File** > **Settings** > **Developer**, then click **Edit Config**. The folder with the `claude_desktop_config.json` file opens.

2\. Add one of the following objects, depending on the transport protocol used by MCP Server:

* STDIO

```json
{
  "mcpServers": {
    "devart": {
      "command": "C:\\path\\to\\Devart.AI.McpServer.AdoNet.ZohoCrm.exe",
      "args": [
        "run",
        "my_zohocrm"
      ]
    }
  }
}
```

 where:

  * `devart` is the connector name that will appear in Claude Desktop.
  * `C:\\path\\to\\Devart.AI.McpServer.AdoNet.ZohoCrm.exe` is the path to the executable file. For an ODBC connection, use `Devart.AI.McpServer.Odbc.ZohoCrm.exe`.
  * `my_zohocrm` is the connection name specified in the `mcpserver.json` configuration file.

* **HTTP**

  ```json
    "mcpServers": {
      "devart": {
        "command": "npx",
        "args": [
          "-y",
          "mcp-remote",
          "http://localhost:5000/sse"
        ]
      }
    }
  ```

  where:

  * `devart` is the connector name that will appear in Claude Desktop.
  * `5000` is the MCP Server listening port.

3\. Save the file.

4\. Restart Claude Desktop.

Devart MCP Server for Zoho CRM is now integrated with Claude, and **devart** appears in the Claude Desktop app in **Customize** > **Connectors**.

You can also [integrate](https://docs.devart.com/mcp/ai-integration/) Devart MCP Server for Zoho CRM with other AI clients such as Cline, Codex, Cursor, Visual Studio Code, Windsurf, Zed.

## Supported clients

Devart MCP Server for Zoho CRM supports integration with the following AI clients: 
 
* Claude Desktop
* Visual Studio Code
* Cursor
* Codex
* Windsurf
* Cline
* Zed
* ...and other MCP-compatible AI clients

## Typical use cases

Devart MCP Server for Zoho CRM is a practical fit for teams working with Zoho CRM as their primary data source.

* **Sales pipeline and deal tracking**  
  Let sales managers and reps query deal stages, expected close dates, deal values, and pipeline distributions directly from Zoho CRM.

* **Lead and contact database analysis**  
  Search and analyze lead records, qualification statuses, source attribution, and follow-up histories stored in Zoho CRM.

* **Territory and team performance reporting**  
  Compare deal performance across territories, sales teams, and individual reps using Zoho CRM opportunity and activity data.

* **Activity and engagement history**  
  Access call logs, email records, meeting notes, and task histories from Zoho CRM contact and account timelines.

* **Forecast and quota analysis**  
  Query forecast categories, quota assignments, and attainment data from Zoho CRM to support sales planning.

* **Customer lifecycle and retention insights**  
  Analyze deal win/loss patterns, customer reactivation histories, and churn indicators from Zoho CRM data.

## Licensing and activation

Devart MCP Server for Zoho CRM is distributed as a free single-source MCP server.

To connect to Zoho CRM, the server requires the corresponding [Devart ODBC Driver for Zoho CRM](https://www.devart.com/odbc/zoho/), which is a paid product.

A 30-day free trial is available for the Devart ODBC Driver for Zoho CRM.

See the product page and documentation for the latest installation and activation details.

## Support

* [Documentation](https://docs.devart.com/mcp/)
* [Submit a request](https://www.devart.com/company/contactform.html)
* [Suggest a feature](https://devart.uservoice.com/)
* [Join our forum](https://support.devart.com/portal/en/community)

## Other Devart connectivity solutions

* [MCP Server Universal](https://github.com/devart-ai-connectivity/devart-mcp-server-universal)
* [ODBC Driver for Zoho CRM](https://www.devart.com/odbc/zoho/)
* [dotConnect ADO.NET Provider for Zoho CRM](https://www.devart.com/dotconnect/zohocrm/)
