using AutoMapper;
using Moq;
using System;
using Tele2_webAPI.Data;
using Tele2_webAPI.Models;
using Tele2_webAPI.Profiles;
using Tele2_webAPI.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Json.Net;
using Newtonsoft.Json;

namespace Tele2_webAPI.UnitTest
{
    public class CitizentsControllerTest
    {
        private readonly Mock<ICityRepo> repositoryStub = new Mock<ICityRepo>();
        private static MapperConfiguration mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CitizentsProfile());
        });
        private IMapper mapper = mockMapper.CreateMapper();

        [Fact]
        public void GetAllResidents_SexMale()
        {
            
        }
        [Fact]
        public void GetResidentById_WithUnexistingItem_RetursNotFound()
        {
            repositoryStub.Setup(repo => repo.GetCitizentById(It.IsAny<string>())).Returns((Citizen)null);

            var controller = new CitizensController(repositoryStub.Object, mapper);

            var result = controller.GetResidentById(It.IsAny<string>());

            Assert.IsType<NotFoundResult>(result.Result);
        }
        [Fact]
        public void GetResidentById_WithExistingItem_RetursNotFound()
        {
            var expectedItem = new Citizen() { Id = "id1", Name = "Kate", Age = 23, Index = 1, Sex = "female" };
            var dataString = JsonConvert.SerializeObject(expectedItem);
            repositoryStub.Setup(repo => repo.GetCitizentById(It.IsAny<string>())).Returns(expectedItem);

            var controller = new CitizensController(repositoryStub.Object, mapper);

            var result = controller.GetResidentById("id1");

            Assert.IsType<OkObjectResult>(result.Result);
        }

        private List<Citizen> GetAllCitizents()
        {
            List <Citizen> citizents = new List<Citizen>();
            citizents.Add(new Citizen() { Id = "id1", Name = "Kate", Age = 23, Index = 1, Sex = "female" });
            citizents.Add(new Citizen() { Id = "id2", Name = "Mark", Age = 40, Index = 2, Sex = "male" });
            citizents.Add(new Citizen() { Id = "id3", Name = "Nick", Age = 35, Index = 3, Sex = "male" });
            citizents.Add(new Citizen() { Id = "id4", Name = "Alice", Age = 19, Index = 4, Sex = "female" });
            citizents.Add(new Citizen() { Id = "id5", Name = "Jhon", Age = 89, Index = 5, Sex = "male" });
            citizents.Add(new Citizen() { Id = "id6", Name = "Misha", Age = 56, Index = 6, Sex = "female" });
            citizents.Add(new Citizen() { Id = "id7", Name = "Beer", Age = 22, Index = 7, Sex = "male" });
            citizents.Add(new Citizen() { Id = "id8", Name = "Sonya", Age = 47, Index = 8, Sex = "female" });
            citizents.Add(new Citizen() { Id = "id9", Name = "Luisa", Age = 60, Index = 9, Sex = "female" });
            citizents.Add(new Citizen() { Id = "id10", Name = "Anne", Age = 27, Index = 10, Sex = "female" });

            return citizents;
        }
    }
}
