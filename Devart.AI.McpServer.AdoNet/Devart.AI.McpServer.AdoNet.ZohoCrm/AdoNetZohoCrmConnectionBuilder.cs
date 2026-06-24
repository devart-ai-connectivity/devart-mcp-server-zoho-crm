// --------------------------------------------------------------------------
// <copyright file="AdoNetZohoCrmConnectionBuilder.cs" company="Devart">
//
// Copyright (c) Devart. ALL RIGHTS RESERVED
// Use of the source code is permitted under the license.
// </copyright>
// --------------------------------------------------------------------------

using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Devart.AI.McpServer.Interfaces;
using Devart.Data.Zoho;

namespace Devart.AI.McpServer.AdoNet.ZohoCrm
{
  internal sealed class AdoNetZohoCrmConnectionBuilder : IConnectionBuilder
  {
    public async Task<DbConnection> CreateConnectionAsync(McpConfiguration configuration, CancellationToken cancellationToken)
    {
      var connection = new ZohoConnection(configuration.CompleteConnectionString);
      await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
      return connection;
    }
  }
}
