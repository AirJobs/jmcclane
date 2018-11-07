using AirJobs.Domain.Entities.Addresses;
using AirJobs.Domain.Entities.Jobs;
using AirJobs.Domain.Interfaces.Data.UnitOfWork;
using Bogus;
using GeoCoordinatePortable;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AirJobs.Data.Services
{
    public class PopularJobs
    {
        public static async Task Initialize(IUnitOfWork unitOfWork)
        {
            var users = await unitOfWork.User.List();
            var userIds = users.Select(x => x.Id).ToArray();

            var state = await unitOfWork.State.Get(x => x.UF == "SP");
            var cities = await unitOfWork.City.ListByState(state.Id);
            var citiesCount = cities.Count();

            var random = new Random();

            foreach (var userId in userIds)
            {
                var cityIndex = random.Next(0, citiesCount);
                var cityId = cities[cityIndex].Id;
                var addresses = Addresses(userId, cityId).Generate(5);

                foreach (var address in addresses)
                {
                    address.Jobs = Jobs(address.Id).Generate(2);
                }

                await unitOfWork.Address.Add(addresses);
            }

            await unitOfWork.SaveAsync();
        }

        public static Faker<Job> Jobs(Guid addressId)
        {
            return  new Faker<Job>("pt_BR")
                .RuleFor(x => x.Id, faker => Guid.NewGuid())
                .RuleFor(x => x.AddressId, faker => addressId)
                .RuleFor(x => x.CreatedDate, faker => DateTime.Now)
                .RuleFor(x => x.Title, faker => faker.Lorem.Word())
                .RuleFor(x => x.Description, faker => faker.Lorem.Paragraph())
                .RuleFor(x => x.Price, faker => faker.Random.Decimal(80, 200))
                .RuleFor(x => x.ImageUrl, faker => faker.Image.City());
        }

        public static Faker<Address> Addresses(Guid userId, Guid cityId)
        {
            return new Faker<Address>("pt_BR")
                .RuleFor(x => x.Id, faker => Guid.NewGuid())
                .RuleFor(x => x.UserId, faker => userId)
                .RuleFor(x => x.CityId, faker => cityId)
                .RuleFor(x => x.GeoLocation, faker => new GeoCoordinate(faker.Address.Latitude(), faker.Address.Longitude()))
                .RuleFor(x => x.Neighborhood, faker => faker.Address.FullAddress())
                .RuleFor(x => x.Number, faker => faker.Address.BuildingNumber())
                .RuleFor(x => x.Street, faker => faker.Address.StreetName());
        }
    }
}
