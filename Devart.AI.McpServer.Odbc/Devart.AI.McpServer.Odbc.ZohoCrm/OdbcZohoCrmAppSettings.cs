// --------------------------------------------------------------------------
// <copyright file="OdbcZohoCrmAppSettings.cs" company="Devart">
//
// Copyright (c) Devart. ALL RIGHTS RESERVED
// Use of the source code is permitted under the license.
// </copyright>
// --------------------------------------------------------------------------

namespace Devart.AI.McpServer.Odbc.ZohoCrm
{
  internal sealed class OdbcZohoCrmAppSettings : McpAppSettings
  {
    public override string ServerName => $"Devart {Properties.ProductInfo.ProductFullName}";

    public override string SourceName => "Zoho CRM";

    public override bool OnPremise => false;
  }
}
