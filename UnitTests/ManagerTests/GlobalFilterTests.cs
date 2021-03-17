using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.AuthenticationManagement.Models;
using Services.EntityFramework.DbEntities;
using Services.Filters;
using Services.Filters.Attributes;
using Services.Models.Abstract;
using Services.Models.DTOs;
using Services.Models.Enums;
using Services.SessionManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;

namespace UnitTests.ManagerTests
{
    [TestClass]
    public class GlobalFilterTests
    {
        private GlobalActionFilter GetFilter(MockContainer c)
        {
            return new GlobalActionFilter(c.AuthenticationManager.Object);
        }

        /// <summary>
        /// This is fot mocking the controller action and setting a user in the session
        /// </summary>
        /// <returns>Relevant controller action context</returns>
        private ActionExecutingContext GetActionFilterContext(UserTypeEnum userFilter, MockContainer c, AbstractUser userInSession = null)
        {
            var httpCtx = new Mock<HttpContext>();
            var session = new Mock<ISession>();
            httpCtx.SetupGet(s => s.Session).Returns(session.Object);

            if (userInSession != null)
            {
                byte[] userSession = JsonSerializer.SerializeToUtf8Bytes(new AuthenticatedSession(userInSession.UserID, userInSession.UserType));
                session.Setup(s => s.TryGetValue(SessionHelper.UserSessionKey, out userSession)).Returns(true);

                if (userInSession.UserType == UserTypeEnum.INTERNAL)
                    c.AuthenticationManager.Setup(s => s.GetSessionUser(It.IsAny<ISession>()))
                        .ReturnsAsync(new InternalUserDTO() { UserType = UserTypeEnum.INTERNAL, UserID = userInSession.UserID });
                else
                    c.AuthenticationManager.Setup(s => s.GetSessionUser(It.IsAny<ISession>()))
                        .ReturnsAsync(new ExternalUserDTO() { UserType = UserTypeEnum.EXTERNAL, UserID = userInSession.UserID });
            }

            var actionContext = new ActionContext(httpCtx.Object, new RouteData(), new ActionDescriptor());
            var actionFilters = new List<IFilterMetadata>()
            {
                new RequireUser(userFilter)
            };

            return new ActionExecutingContext(actionContext, actionFilters, new Dictionary<string, object>(), null);
        }

        [TestMethod]
        public async Task GlobalFilter_NoUserSession_RedirectToLogin()
        {
            var c = new MockContainer();
            var filter = GetFilter(c);

            var actionExecContext = GetActionFilterContext(UserTypeEnum.ANY, c, null);
            ActionExecutionDelegate mockAction = () => Task.FromResult(new ActionExecutedContext(null, null, null));

            // Act
            await filter.OnActionExecutionAsync(actionExecContext, mockAction);
            RedirectToActionResult res = actionExecContext.Result as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(res.ActionName, "Login");
            Assert.AreEqual(res.ControllerName, "Authentication");
        }

        [TestMethod]
        public async Task GlobalFilter_ExternalAction_InternalUser_RedirectToLogin()
        {
            var c = new MockContainer();
            var filter = GetFilter(c);

            var actionExecContext = GetActionFilterContext(UserTypeEnum.EXTERNAL, c, new InternalUserDTO() { UserID = 290, UserType = UserTypeEnum.INTERNAL });
            ActionExecutionDelegate mockAction = () => Task.FromResult(new ActionExecutedContext(null, null, null));

            // Act
            await filter.OnActionExecutionAsync(actionExecContext, mockAction);
            RedirectToActionResult res = actionExecContext.Result as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(res.ActionName, "Login");
            Assert.AreEqual(res.ControllerName, "Authentication");
        }

        [TestMethod]
        public async Task GlobalFilter_InternalAction_ExternalUser_RedirectToLogin()
        {
            var c = new MockContainer();
            var filter = GetFilter(c);

            var actionExecContext = GetActionFilterContext(UserTypeEnum.INTERNAL, c, new InternalUserDTO() { UserID = 290, UserType = UserTypeEnum.EXTERNAL });
            ActionExecutionDelegate mockAction = () => Task.FromResult(new ActionExecutedContext(null, null, null));

            // Act
            await filter.OnActionExecutionAsync(actionExecContext, mockAction);
            RedirectToActionResult res = actionExecContext.Result as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(res.ActionName, "Login");
            Assert.AreEqual(res.ControllerName, "Authentication");
        }

        [TestMethod]
        public async Task GlobalFilter_InternalAction_Success()
        {
            var c = new MockContainer();
            var filter = GetFilter(c);

            var actionExecContext = GetActionFilterContext(UserTypeEnum.INTERNAL, c, new InternalUserDTO() { UserID = 290, UserType = UserTypeEnum.INTERNAL });
            var actionContext = new ActionContext(new Mock<HttpContext>().Object, new RouteData(), new ActionDescriptor());
            ActionExecutionDelegate mockAction = () => Task.FromResult(new ActionExecutedContext(actionContext, new List<IFilterMetadata>() {
                new RequireUser(UserTypeEnum.INTERNAL)
            }, null));

            // Act
            await filter.OnActionExecutionAsync(actionExecContext, mockAction);
            RedirectToActionResult res = actionExecContext.Result as RedirectToActionResult;

            //Assert
            Assert.IsNull(res); // if the result is null then the action is fired and a redirect has not happened.
        }

        [TestMethod]
        public async Task GlobalFilter_ExternalAction_Success()
        {
            var c = new MockContainer();
            var filter = GetFilter(c);

            var actionExecContext = GetActionFilterContext(UserTypeEnum.EXTERNAL, c, new InternalUserDTO() { UserID = 290, UserType = UserTypeEnum.EXTERNAL });
            var actionContext = new ActionContext(new Mock<HttpContext>().Object, new RouteData(), new ActionDescriptor());
            ActionExecutionDelegate mockAction = () => Task.FromResult(new ActionExecutedContext(actionContext, new List<IFilterMetadata>() {
                new RequireUser(UserTypeEnum.INTERNAL)
            }, null));

            // Act
            await filter.OnActionExecutionAsync(actionExecContext, mockAction);
            RedirectToActionResult res = actionExecContext.Result as RedirectToActionResult;

            //Assert
            Assert.IsNull(res); // if the result is null then the action is fired and a redirect has not happened.
        }

        [TestMethod]
        public async Task GlobalFilter_AnyAction_Success()
        {
            var c = new MockContainer();
            var filter = GetFilter(c);

            var actionExecContext = GetActionFilterContext(UserTypeEnum.ANY, c, new InternalUserDTO() { UserID = 290, UserType = UserTypeEnum.EXTERNAL });
            var actionContext = new ActionContext(new Mock<HttpContext>().Object, new RouteData(), new ActionDescriptor());
            ActionExecutionDelegate mockAction = () => Task.FromResult(new ActionExecutedContext(actionContext, new List<IFilterMetadata>() {
                new RequireUser(UserTypeEnum.INTERNAL)
            }, null));

            // Act
            await filter.OnActionExecutionAsync(actionExecContext, mockAction);
            RedirectToActionResult res = actionExecContext.Result as RedirectToActionResult;

            //Assert
            Assert.IsNull(res); // if the result is null then the action is fired and a redirect has not happened.
        }
    }
}
