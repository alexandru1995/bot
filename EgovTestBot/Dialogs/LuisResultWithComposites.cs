using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace EgovTestBot
{
    public class LuisResultWithComposite : LuisResult
    {

        public LuisResultWithComposite(string query, IList<IntentRecommendation> intents, IList<EntityRecommendation> entities)
        {
            Query = query;
            Intents = intents;
            Entities = entities;

        }


        [JsonProperty(PropertyName = "intents")]
        public IList<IntentRecommendation> Intents { get; set; }
    }
}