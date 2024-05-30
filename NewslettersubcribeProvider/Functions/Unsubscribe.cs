using Data.Context;
using Data.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace NewsletterProvider.Functions
{
    public class Unsubscribe(ILogger<Unsubscribe> logger, DataContext dataContext)
    {
        private readonly ILogger<Unsubscribe> _logger = logger;
        private readonly DataContext _dataContext = dataContext;

        [Function("Unsubscribe")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            if (!string.IsNullOrEmpty(body))
            {
                var subscribeEntity = JsonConvert.DeserializeObject<SubscribeEntity>(body);
                if (subscribeEntity != null)
                {
                    var existingSubscriber = await _dataContext.NewsSubscribers.FirstOrDefaultAsync(x => x.Email == subscribeEntity.Email);
                    if (existingSubscriber != null)
                    {
                        _dataContext.Remove(existingSubscriber);
                        await _dataContext.SaveChangesAsync();
                        return new OkObjectResult(new { Status = 200, Message = "Subsriber was updated" });

                    }
                }
            }
            return new BadRequestObjectResult(new { Status = 200, Message = "Unable to unsubscribe right now" });

            
        }
    }
}
