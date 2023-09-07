using BW5_ExamenFinalReprise.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Controllers;
using TP2.Models;
using TP2.Services;

namespace Test_Movie
{
    public class ParentController_Tests
    {
        private Mock<IParentServices> _parentService_Mock;
        private Mock<IEnfantServices> _enfantService_Mock;
        private ParentsController _parentController;

        public ParentController_Tests()
        {
            _parentService_Mock = new Mock<IParentServices>();
            _enfantService_Mock = new Mock<IEnfantServices>();
            _parentController = new ParentsController(_parentService_Mock.Object, _enfantService_Mock.Object);
        }

        [Fact]
        public async void Index_VerifyGetAllInvoked()
        {
            var result = await _parentController.Index();

            _parentService_Mock.Verify(x => x.GetAllAsync(), Times.Once);

            Assert.IsAssignableFrom<ViewResult>(result);

            ViewResult viewResult = result as ViewResult;
            Assert.Equal("Index", viewResult.ViewName);
        }

        [Fact]
        public async void Create_ModelStateInvalid_ReturnView()
        {
            _parentController.ModelState.AddModelError("Error", "Error");

            var result = _parentController.Create(new Parent()).Result;

            ViewResult viewResult = result as ViewResult;
            Assert.Equal("Create", viewResult.ViewName);
        }

        [Fact]
        public async void Create_ModelStateValid_RedirectToView()
        {
            var parent = new Parent()
            {
                Id = 11,
                Nom = "Netflix",
           
                IsDisponible = true
            };

            _parentService_Mock.Setup(x => x.CreateAsync(It.IsAny<Parent>())).ReturnsAsync(new Parent());

            var result = _parentController.Create(new Parent()).Result;

            _parentService_Mock.Verify(x => x.CreateAsync(It.IsAny<Parent>()), Times.Once);

            Assert.IsType<RedirectToActionResult>(result);
            // même vérification 
            Assert.IsAssignableFrom<RedirectToActionResult>(result);

            var viewResult = result as RedirectToActionResult;
            Assert.Equal("Index", viewResult.ActionName);
            Assert.Null(viewResult.ControllerName);
        }

        [Fact]
        public async void Edit_GetValidId_ReturnView()
        {
            _parentService_Mock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
            new Parent()
            {
                Id = 11,
                Nom = "Netflix",

                IsDisponible = true
            });

            var result = _parentController.Edit(11).Result;

            ViewResult viewResult = result as ViewResult;
            Assert.Equal("Edit", viewResult.ViewName);

            Assert.NotNull(viewResult.ViewData);

            Assert.IsType<Parent>(viewResult.Model);

            var model = viewResult.ViewData.Model as Parent;
            Assert.Equal(11, model.Id);
        }

    }
}