using AirJobs.Models;
using AirJobs.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AirJobs.Domain.Interfaces.Data.UnitOfWork;
using AirJobs.Models.Dtos.Address;
using AirJobs.Models.Dtos.City;
using AirJobs.Models.Dtos.Country;
using AirJobs.Models.Dtos.State;

namespace AirJobs.Controllers
{
    [Route("api/locations")]
    public class LocationController : Controller
    {
        #region Constructor / Fields

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LocationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        #endregion

        [HttpGet("countries")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CountryListDto>))]
        public async Task<IActionResult> ListCountries()
        {
            var countries = await unitOfWork.Country.List();

            if (!countries.Any())
                return NotFound();

            var countriesVm = mapper.Map<IEnumerable<CountryListDto>>(countries);
            return Ok(countriesVm);
        }

        [HttpGet("countries/{countryId:guid}/states")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<StateListDto>))]
        public async Task<IActionResult> ListStates(Guid countryId)
        {
            var states = await unitOfWork.State.ListByCountry(countryId);

            if (!states.Any())
                return NotFound();

            var statesVm = mapper.Map<IEnumerable<StateListDto>>(states);
            return Ok(statesVm);
        }

        [HttpGet("countries/{countryId:guid}/states/{stateId:guid}/cities")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CityListDto>))]
        public async Task<IActionResult> ListCities(Guid countryId, Guid stateId)
        {
            var cities = await unitOfWork.City.ListByState(stateId);

            if (!cities.Any())
                return NotFound();

            var citiesVm = mapper.Map<IEnumerable<CityListDto>>(cities);
            return Ok(citiesVm);
        }

        [HttpGet("countries/{countryId:guid}/states/{stateId:guid}/cities/{cityId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CityListDto>))]
        public async Task<IActionResult> GetCities(Guid countryId, Guid stateId, Guid cityId)
        {
            var city = await unitOfWork.City.Get(cityId);

            if (city == null)
                return NotFound();

            var citiesVm = mapper.Map<CityListDto>(city);
            return Ok(citiesVm);
        }

        [HttpGet("countries/{countryId:guid}/states/{stateId:guid}/cities/{cityId}/addresses")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CityListDto>))]
        public async Task<IActionResult> ListAddresses(Guid cityId)
        {
            var addresses = await unitOfWork.Address.ListByCity(cityId);

            if (addresses == null)
                return NotFound();

            var citiesVm = mapper.Map<IEnumerable<AddressListDto>>(addresses);
            return Ok(citiesVm);
        }

        //[HttpPost("populate")]
        //public async Task<IActionResult> PopulateDatabase()
        //{
        //    var service = new PopulateLocations(unitOfWork);
        //    await service.Populate();
        //    return Ok("tudo certo");
        //}
    }
}
