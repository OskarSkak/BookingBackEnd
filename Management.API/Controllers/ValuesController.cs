﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.Infrastructure.MessagingContracts;
using Microsoft.AspNetCore.Mvc;
using Management.API.RequestModels;
using Management.Domain.Commands;
using Management.Documents.Documents;
using Management.Queries.Queries;
using Management.Persistence.Model;
using Swashbuckle.AspNetCore.Swagger;

namespace Management.API.Controllers
{
    [Route("api/users")]
    [ApiController]
	public class ValuesController : BaseController
    {
		public ValuesController(ICommandRouter commandRouter, IQueryRouter queryRouter) : base(commandRouter, queryRouter)
		{
		}

		[HttpGet]
		[Route("{name}")]
		public async Task<IActionResult> Hello(string name)
		{
			return new ObjectResult($"Hello {name}!");
		}

		[HttpGet]
		[Route("myRoute/{name}")]
		public async Task<IActionResult> HelloMyRoute(string name)
		{
			return new ObjectResult($"Hello {name} from myRoute");
		}

		[HttpPost]
		[Route("")]
		public async Task<IActionResult> CreateUser([FromBody]CreateUserRequestModel requestModel)
		{
			var response = await CommandRouter.RouteAsync<CreateUserCommand, IdResponse>(new CreateUserCommand(requestModel.Name, requestModel.Age, requestModel.Addres));

			if(!response.IsSuccessful)
			{
				return StatusCode(401, response.Message);
			}

			return new ObjectResult(response.Id);
		}

		[HttpGet]
		[Route("specificuser/{id}")]
		public async Task<IActionResult> GetNewUser(Guid id)
		{
			var result = await QueryRouter.QueryAsync<GetUserQuery, User>(new GetUserQuery(id));

			if(result == null)
			{
				return NotFound();
			}

			return new ObjectResult(result);
		}
    }
}