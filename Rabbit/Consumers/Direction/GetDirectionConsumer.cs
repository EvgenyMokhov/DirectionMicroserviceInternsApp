using BusinessLogic;
using InternsTestModels.Models.Enums;
using InternsTestModels.Models.Rabbit.Direction.Requests;
using InternsTestModels.Models.Rabbit.Direction.Responses;
using MassTransit;

namespace Rabbit.Consumers.Direction
{
    public class GetDirectionConsumer : IConsumer<GetDirectionRequest>
    {
        private readonly ServiceManager serviceManager;
        private readonly IServiceProvider serviceProvider;
        public GetDirectionConsumer(IServiceProvider provider)
        {
            serviceManager = new(provider);
            serviceProvider = provider;
        }

        public async Task Consume(ConsumeContext<GetDirectionRequest> context)
        {
            try
            {
                GetDirectionResponse response = new() { ResponseData = await serviceManager.Directions.GetDirectionAsync(context.Message.Id) };
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
