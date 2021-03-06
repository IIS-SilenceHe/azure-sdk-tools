﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Management.SqlDatabase.Services.Server
{
    /// <summary>
    /// The <see cref="Database"/> extensions
    /// </summary>
    public partial class Database
    {
        /// <summary>
        /// Gets or sets the context from which this object was constructed.
        /// </summary>
        public IServerDataServiceContext Context;

        /// <summary>
        /// Gets the name of the service objective for this Database.
        /// </summary>
        public string ServiceObjectiveName;

        /// <summary>
        /// Tries to copy the context into the database field.
        /// </summary>
        /// <param name="context">The context to store in the database object</param>
        internal void LoadExtraProperties(IServerDataServiceContext context)
        {
            try
            {
                // Fill in the context property
                this.Context = context;

                // Fill in the service objective properties
                this.Context.LoadProperty(this, "ServiceObjective");
                this.ServiceObjectiveName =
                    this.ServiceObjective == null ? null : this.ServiceObjective.Name;
            }
            catch
            {
                // Ignore exceptions when loading extra properties, for backward compatibility.
            }
        }

        /// <summary>
        /// Copies all the internal fields from one database object into another.
        /// </summary>
        /// <param name="other">The database to be copied.</param>
        internal void CopyFields(Database other)
        {
            this._CollationName = other._CollationName;
            this._CreationDate = other._CreationDate;
            this._Edition = other._Edition;
            this._Id = other._Id;
            this._MaxSizeGB = other._MaxSizeGB;
            this._Name = other._Name;
            this._Server = other._Server;
            this.Context = other.Context;
        }
    }
}
