// <copyright file="DbHelper.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Core.Windows.Tools.Database
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Security.Principal;

    /// <summary>
    /// Provides a collection of methods to work with databases.
    /// </summary>
    public static class DbHelper
    {
        /// <summary>
        /// Execute a SQL command on a database which can be connected to with the overgiven provider type. Multiple scripts are possible.
        /// </summary>
        /// <param name="providerType">The provider type.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="sqlCommand">The SQL command.</param>
        /// <param name="environment">The environment on which the SQL command should be executed. If not provided it will default to "Default".</param>
        /// <param name="impersonation">The impersonation which can be used for executing the SQL script.</param>
        /// <returns>Returns a <see cref="List{DataTable}"/> with the results of the SQL command. If provider type isn't supported it returns null.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "'impersonation' parameter has been added for future implementations")]
        public static List<DataTable> ExecuteSqlScript(string providerType, string connectionString, string sqlCommand, string environment = "Default", WindowsImpersonationContext impersonation = null)
        {
            switch (providerType)
            {
                case "System.Data.SqlClient":
                    return SoluiNet.Core.Tools.Database.DbHelper.ExecuteSqlScript<SqlConnection, SqlCommand>(connectionString, sqlCommand, environment);
                case "System.Data.SQLite":
                    return SoluiNet.Core.Tools.Database.DbHelper.ExecuteSqlScript<SQLiteConnection, SQLiteCommand>(connectionString, sqlCommand, environment);
                default:
                    return null;
            }
        }
    }
}
