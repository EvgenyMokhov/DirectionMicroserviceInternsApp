using BusinessLogic;
using InternsTestModels.Models.Enums;
using InternsTestModels.Models.Rabbit.Direction.Requests;
using MassTransit;

namespace Rabbit.Consumers.Direction
{
    public class UpdateDirectionConsumer : IConsumer<UpdateDirectionRequest>
    {
        private readonly ServiceManager serviceManager;
        private readonly IServiceProvider serviceProvider;
        public UpdateDirectionConsumer(IServiceProvider provider)
        {
            serviceManager = new(provider);
            serviceProvider = provider;
        }

        public async Task Consume(ConsumeContext<UpdateDirectionRequest> context)
        {
            try
            {
                await serviceManager.Directions.UpdateDirectionAsync(context.Message.RequestData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
