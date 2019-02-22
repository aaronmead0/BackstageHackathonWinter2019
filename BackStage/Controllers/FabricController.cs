using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using TestActor.Interfaces;

namespace BackStage.Controllers
{
    [Route("api/[controller]")]
    public class FabricController : Controller
    {
        

        [HttpGet("[action]")]
        public string Calculator(string a, string b)
        {
            return CallFabric(a, b);
        }

        public string CallFabric(string a, string b) {

            // Create a randomly distributed actor ID
            ActorId actorId = ActorId.CreateRandom();

            // This only creates a proxy object, it does not activate an actor or invoke any methods yet.
            ITestActor myActor = ActorProxy.Create<ITestActor>(actorId, new Uri("fabric:/TestFabric/TestActorService"));

            // This will invoke a method on the actor. If an actor with the given ID does not exist, it will be activated by this method call.
            int parsedEquation, parsedEquation2;
            var parsed1 = int.TryParse(a, out parsedEquation);
            var parsed2 = int.TryParse(b, out parsedEquation2);
            if (parsed1 && parsed2)
            {
                var x= "Number Calculator Computed:" + myActor.DoSumWork(parsedEquation, parsedEquation2);
                return x;
            }
            else {
                return a + b;
            }
        }
    }
}
