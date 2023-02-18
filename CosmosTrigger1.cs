using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class CosmosTrigger1
    {
        [FunctionName("CosmosTrigger1")]
        public static void Run([CosmosDBTrigger(
            databaseName: "mydb",
            collectionName: "mycoll",
            ConnectionStringSetting = "cdbtoeh_DOCUMENTDB",
            LeaseCollectionName = "leases")]IReadOnlyList<Document> input, 
            [CosmosDB(
                databaseName: "mydb",
                collectionName: "mycollout",
                ConnectionStringSetting = "cdbtoeh_DOCUMENTDB")] out dynamic outputDocument,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
               
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }
        }
    }
}
