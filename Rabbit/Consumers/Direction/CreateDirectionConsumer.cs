using BusinessLogic;
using InternsTestModels.Models.Enums;
using InternsTestModels.Models.Rabbit.Direction.Requests;
using MassTransit;

namespace Rabbit.Consumers.Direction
{
    public class CreateDirectionConsumer : IConsumer<CreateDirectionRequest>
    {
        private readonly ServiceManager serviceManager;
        private readonly IServiceProvider serviceProvider;
        public CreateDirectionConsumer(IServiceProvider provider) 
        { 
            serviceManager = new(provider);
            serviceProvider = provider;
        }
        public async Task Consume(ConsumeContext<CreateDirectionRequest> context)
        {
            try
            {
                await serviceManager.Directions.CreateDirectionAsync(context.Message.RequestData);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
