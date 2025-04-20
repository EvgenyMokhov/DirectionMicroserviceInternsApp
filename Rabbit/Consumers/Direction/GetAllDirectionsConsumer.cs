using BusinessLogic;
using InternsTestModels.Models.Enums;
using InternsTestModels.Models.Rabbit.Direction.Requests;
using InternsTestModels.Models.Rabbit.Direction.Responses;
using MassTransit;

namespace Rabbit.Consumers.Direction
{
    public class GetAllDirectionsConsumer : IConsumer<GetAllDirectionsRequest>
    {
        private readonly ServiceManager serviceManager;
        private readonly IServiceProvider serviceProvider;
        public GetAllDirectionsConsumer(IServiceProvider provider)
        {
            serviceManager = new(provider);
            serviceProvider = provider;
        }

        public async Task Consume(ConsumeContext<GetAllDirectionsRequest> context)
        {
            try
            {
                GetAllDirectionsResponse response = new() { ResponseData = await serviceManager.Directions.GetAllDirectionAsync() };
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
