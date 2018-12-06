using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using DevelopersDirectory.BindingModels;
using DevelopersDirectory.Controllers;
using DevelopersDirectory.Interfaces;
using Moq;
using NUnit.Framework;


namespace DevelopersDirectoryTest
{
    [TestFixture]
    class DeveloperControllerTests
    {
       
        private Mock<IDevelopersRepository> _developersRepoMock;
        private DevelopersController _controller;
        private List<DeveloperDirectoryBindingModel> _listOfDirectoryBindingModels;

        [SetUp]
        public void Setup()
        {
            _developersRepoMock = new Mock<IDevelopersRepository>();
            _controller = new DevelopersController(_developersRepoMock.Object);

            _listOfDirectoryBindingModels = new List<DeveloperDirectoryBindingModel>
            {
                new DeveloperDirectoryBindingModel
                {
                    EmailAddress = "xya@jas.com",
                    CategoryId = 1,
                    GithubId = "http://github.com/@malso",
                    Name = "Daniel Smith",
                    TwitterHandle = "http://twitter.com/@pas"
                },
                new DeveloperDirectoryBindingModel
                {
                    EmailAddress = "slimas@hsa.com",
                    CategoryId = 2,
                    GithubId = "http://github.com/@malso",
                    Name = "Felix Adas",
                    TwitterHandle = "http://twitter.com/@pas"
                },
                new DeveloperDirectoryBindingModel
                {
                    EmailAddress = "iamflipponachi@jssd.com",
                    CategoryId = 1,
                    GithubId = "http://github.com/ioasmalso",
                    Name = "Samuel Jones",
                    TwitterHandle = "http://twitter.com/aspas"
                }
            };
        }

        [Test]
        public void Developers_ListOfEntry_ReturnsOkWithList()
        {
            _developersRepoMock.Setup(e => e.ListOfDevelopers()).Returns(_listOfDirectoryBindingModels);

            var result = _controller.Developers() as OkNegotiatedContentResult<List<DeveloperDirectoryBindingModel>>;

            Assert.IsNotNull(result);
           
            Assert.That(result.Content.Count, Is.EqualTo(_listOfDirectoryBindingModels.Count));
            Assert.That(result.Content, Is.TypeOf<List<DeveloperDirectoryBindingModel>>());
        }

        [Test]
        public async Task Developers_CreateDeveloperEntry_ReturnsBadRequestWithMessage()
        {
            DeveloperDirectoryBindingModel model = new DeveloperDirectoryBindingModel
                {EmailAddress = "Smith Ola", GithubId = "assd"};

            var result = await _controller.Developers(model) as BadRequestErrorMessageResult;

           Assert.IsNotNull(result);
           Assert.AreEqual("Specify Name of the Developer", result.Message);
        }

        [Test]
        public async Task Developers_SupplyIncompleteRequest_ReturnsBadRequestForNoCategoryId()
        {
            DeveloperDirectoryBindingModel model = new DeveloperDirectoryBindingModel
                { Name = "Smith Ola", GithubId = "assd" };

            var result = await _controller.Developers(model) as BadRequestErrorMessageResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Specify the Category Id", result.Message);
        }

        [Test]
        public async Task Developers_CreateDeveloperEntry_ReturnsSuccess()
        {
            DeveloperDirectoryBindingModel model = new DeveloperDirectoryBindingModel
                { Name = "Smith Ola", GithubId = "assd", CategoryId = 1};

            var result = await _controller.Developers(model) as StatusCodeResult;

            Assert.IsNotNull(result);
            Assert.That(result.StatusCode == HttpStatusCode.Created);
            
        }

        [Test]
        public async Task SingleEntry_SupplyNoValueForDeveloperId_ReturnsBadRequestWithMessage()
        {
            
            var result = await _controller.SingleEntry(null) as BadRequestErrorMessageResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Supply Id of Developer Entry", result.Message);

        }

        [Test]
        public async Task SingleEntry_SupplyValueForDeveloperId_ReturnsSingleEntry()
        {
            _developersRepoMock.Setup(e => e.SingleDeveloper(1)).Returns(Task.FromResult(
                new DeveloperDirectoryBindingModel
                    {CategoryId = 1, EmailAddress = "Feli@as.com", GithubId = "flas", Name = "Bankols"}));

            var result = await _controller.SingleEntry(1) as OkNegotiatedContentResult<DeveloperDirectoryBindingModel>;

            Assert.IsNotNull(result);
            Assert.That(result.Content, Is.TypeOf<DeveloperDirectoryBindingModel>());
        }

       
    }
}
