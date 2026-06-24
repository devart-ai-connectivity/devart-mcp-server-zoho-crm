// --------------------------------------------------------------------------
// <copyright file="OdbcZohoCrmTools.cs" company="Devart">
//
// Copyright (c) Devart. ALL RIGHTS RESERVED
// Use of the source code is permitted under the license.
// </copyright>
// --------------------------------------------------------------------------

using System.Collections.Generic;
using ModelContextProtocol.Server;
using Devart.AI.McpServer.Odbc.ZohoCrm.Tools;

namespace Devart.AI.McpServer.Odbc.ZohoCrm
{
  internal static class OdbcZohoCrmTools
  {
    public static List<McpServerTool> CreateTools(McpConfiguration configuration)
      => OdbcTools.CreateBuilder(configuration)
        .Add(new OdbcZohoCrmPrimaryKeysTool(configuration))
        .Add(new OdbcZohoCrmForeignKeysTool(configuration))
        .Build();
  }
}
