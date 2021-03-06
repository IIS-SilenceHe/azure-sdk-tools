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

namespace Microsoft.WindowsAzure.Management.Utilities.CloudService
{
    using Microsoft.WindowsAzure.Management.Utilities.Common;
    using Microsoft.WindowsAzure.ServiceManagement;

    public interface ICloudServiceClient
    {
        /// <summary>
        /// Starts a cloud service.
        /// </summary>
        /// <param name="name">The cloud service name</param>
        /// <param name="slot">The deployment slot</param>
        void StartCloudService(string name = null, string slot = null);

        /// <summary>
        /// Stops a cloud service.
        /// </summary>
        /// <param name="name">The cloud service name</param>
        /// <param name="slot">The deployment slot</param>
        void StopCloudService(string name = null, string slot = null);

        /// <summary>
        /// Check if the deployment exists for given cloud service.
        /// </summary>
        /// <param name="name">The cloud service name</param>
        /// <param name="slot">The deployment slot name</param>
        /// <returns>Flag indicating the deployment exists or not</returns>
        bool DeploymentExists(string name = null, string slot = null);

        /// <summary>
        /// Publishes a service project on Windows Azure.
        /// </summary>
        /// <param name="name">The cloud service name</param>
        /// <param name="slot">The deployment slot</param>
        /// <param name="location">The deployment location</param>
        /// <param name="affinityGroup">The deployment affinity group</param>
        /// <param name="storageAccount">The storage account to store the package</param>
        /// <param name="deploymentName">The deployment name</param>
        /// <returns>The created deployment</returns>
        Deployment PublishCloudService(
            string name = null,
            string slot = null,
            string location = null,
            string affinityGroup = null,
            string storageAccount = null,
            string deploymentName = null,
            bool launch = false);

        /// <summary>
        /// Creates storage service if it does not exist.
        /// </summary>
        /// <param name="name">The storage service name</param>
        /// <param name="label">The storage service label</param>
        /// <param name="location">The location name. If not provided default one will be used</param>
        /// <param name="affinityGroup">The affinity group name</param>
        void CreateStorageServiceIfNotExist(
            string name,
            string label = null,
            string location = null,
            string affinityGroup = null);

        /// <summary>
        /// Gets the default subscription location.
        /// </summary>
        /// <returns>The location name</returns>
        string GetDefaultLocation();

        /// <summary>
        /// Checks if the provided storage service exists under the subscription or not.
        /// </summary>
        /// <param name="name">The storage service name</param>
        /// <returns>True if exists, false otherwise</returns>
        bool StorageServiceExists(string name);

        /// <summary>
        /// Waits for the given operation id until it's done.
        /// </summary>
        /// <param name="operationId">The operation id</param>
        void WaitForOperation(string operationId);

        /// <summary>
        /// Gets complete information of a storage service.
        /// </summary>
        /// <param name="name">The storage service name</param>
        /// <returns>The storage service instance</returns>
        StorageService GetStorageService(string name);

        /// <summary>
        /// Gets connection string of the given storage service name.
        /// </summary>
        /// <param name="name">The storage service name</param>
        /// <returns>The connection string</returns>
        string GetStorageServiceConnectionString(string name);

        /// <summary>
        /// Creates cloud service if it does not exist.
        /// </summary>
        /// <param name="name">The cloud service name</param>
        /// <param name="label">The cloud service label</param>
        void CreateCloudServiceIfNotExist(
            string name,
            string label = null,
            string location = null,
            string affinityGroup = null);

        /// <summary>
        /// Checks if a cloud service exists or not.
        /// </summary>
        /// <param name="name">The cloud service name</param>
        /// <returns>True if exists, false otherwise</returns>
        bool CloudServiceExists(string name);

        /// <summary>
        /// Removes all deployments in the given cloud service and the service itself.
        /// </summary>
        /// <param name="name">The cloud service name</param>
        void RemoveCloudService(string name);
    }
}
