using CompanyEmployees.Application.Company.Commands;
using CompanyEmployees.Application.Company.Notifications;
using CompanyEmployees.Application.Company.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Infrastructure.Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public CompaniesController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _sender.Send(new GetCompaniesQuery(trackChanges: false));

            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _sender.Send(new GetCompanyQuery(id, TrackChanges: false));

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto companyForCreationDto)
        {
            if (companyForCreationDto == null)
            {
                return BadRequest("CompanyForCreationDto object is null.");
            }

            var company = await _sender.Send(new CreateCompanyCommand(companyForCreationDto));

            return CreatedAtRoute("CompanyById", new { id = company.Id }, company);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto companyForUpdateDto)
        {
            if (companyForUpdateDto == null)
            {
                return BadRequest("CompanyForUpdateDto object is null.");
            }

            await _sender.Send(new UpdateCompanyCommand(id, companyForUpdateDto, TrackChanges: false));

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            //await _sender.Send(new DeleteCompanyCommand(id, TrackChanges: false));

            await _publisher.Publish(new CompanyDeletedNotification(id, TrackChanges: false));

            return NoContent();
        }
    }
}