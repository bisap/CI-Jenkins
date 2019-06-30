using Committee_Microservices.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace UnitTestCaseCommittee_Microservices
{
    public class CommitteeMicroserviceUnitTest
    {
        [Fact]
        public void Test1()
        {
            var controller = new ValuesController();
            var actionResult =  controller.Get();
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);

        }
    }
}
