// --------------------------------------------------------------------------
// <copyright file="Program.cs" company="Devart">
//
// Copyright (c) Devart. ALL RIGHTS RESERVED
// Use of the source code is permitted under the license.
// </copyright>
// --------------------------------------------------------------------------

using System.Threading.Tasks;
using Devart.AI.McpServer.Odbc.ZohoCrm.CommandLine;

namespace Devart.AI.McpServer.Odbc.ZohoCrm
{
  internal class Program
  {
    public static Task<int> Main(string[] args) => OdbcLauncher.Create(new OdbcZohoCrmRunCommand()).RunAsync(args);
  }
}
