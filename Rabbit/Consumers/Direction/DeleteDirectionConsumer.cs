using BusinessLogic;
using InternsTestModels.Models.Enums;
using InternsTestModels.Models.Rabbit.Direction.Requests;
using MassTransit;

namespace Rabbit.Consumers.Direction
{
    public class DeleteDirectionConsumer : IConsumer<DeleteDirectionRequest>
    {
        private readonly ServiceManager serviceManager;
        private readonly IServiceProvider serviceProvider;
        public DeleteDirectionConsumer(IServiceProvider provider)
        {
            serviceManager = new(provider);
            serviceProvider = provider;
        }
        public async Task Consume(ConsumeContext<DeleteDirectionRequest> context)
        {
            try
            {
                await serviceManager.Directions.DeleteDirectionAsync(context.Message.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
