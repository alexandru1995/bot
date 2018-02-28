using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Configuration;

using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Bot.Connector;
using System.Linq;

namespace EgovTestBot
{
    class AllIntentDetection
    {
            
        public async Task<LuisResultWithComposite> GetLuisResult(string query)
        {
            var luisApiPath = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/7add24bb-eebf-4f9b-adf6-38672603f2ae?subscription-key=28ab94f3060743eb84ff011b156e860b&verbose=true&timezoneOffset=0&q=";

            LuisResultWithComposite result = null;
            var path = luisApiPath + "" + query;
            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<LuisResultWithComposite>(await response.Content.ReadAsStringAsync());
            }

            return result;
        }

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            var message = await item;

            var luisResult = await this.GetLuisResult(message.Text);
            var bestResult = luisResult?.Intents?.First();

            switch (bestResult.Intent)
            {
                case "None":
                    await this.NoneIntent(context, luisResult);
                    break;

                case "Costul prestarii serviciului":
                    await this.PretIntent(context, luisResult);
                    break;
                case "Adresa si datele de contact":
                    await this.AdresaIntent(context, luisResult);
                    break;
                case "Informatie generala":
                    await this.InfoIntent(context, luisResult);
                    break;
                case "Documentele necesare":
                    await this.DocumentIntent(context, luisResult);
                    break;
                case "Acte normative":
                    await this.acteIntent(context, luisResult);
                    break;
                case "Program de lucru":
                    await this.ProgramDeLucru(context, luisResult);
                    break;

                default:
                    context.Done(true);
                    break;
            }
        }



        public async Task NoneIntent(IDialogContext context, LuisResultWithComposite result)
        {
            string message = $"None Intent";
            await context.PostAsync(message);
            context.Wait(this.MessageReceivedAsync);
        }


   

        public async Task PretIntent(IDialogContext context, LuisResultWithComposite result)
        {
            var count = result.CompositeEntities?.Count ?? 0;
            string message = $"I found {count}  intents.";
            await context.PostAsync(message);

            foreach (var intentCount in result.Intents)
            {
                string intentValue = "";
                intentValue += intentCount.Intent + " ";
                await context.PostAsync(intentValue);
            }

            context.Wait(this.MessageReceivedAsync);
        }


        public async Task AdresaIntent(IDialogContext context, LuisResultWithComposite result)
        {
            var count = result.CompositeEntities?.Count ?? 0;
            string message = $"I found {count}  intents.";
            await context.PostAsync(message);

            foreach (var intentCount in result.Intents)
            {
                string intentValue = "";
                intentValue += intentCount.Intent + " ";
                await context.PostAsync(intentValue);
            }

            context.Wait(this.MessageReceivedAsync);
        }


        public async Task InfoIntent(IDialogContext context, LuisResultWithComposite result)
        {
            var count = result.CompositeEntities?.Count ?? 0;
            string message = $"I found {count}  intents.";
            await context.PostAsync(message);

            foreach (var intentCount in result.Intents)
            {
                string intentValue = "";
                intentValue += intentCount.Intent + " ";
                await context.PostAsync(intentValue);
            }

            context.Wait(this.MessageReceivedAsync);
        }


        public async Task DocumentIntent(IDialogContext context, LuisResultWithComposite result)
        {
            var count = result.CompositeEntities?.Count ?? 0;
            string message = $"I found {count}  intents.";
            await context.PostAsync(message);

            foreach (var intentCount in result.Intents)
            {
                string intentValue = "";
                intentValue += intentCount.Intent + " ";
                await context.PostAsync(intentValue);
            }

            context.Wait(this.MessageReceivedAsync);
        }


        public async Task acteIntent(IDialogContext context, LuisResultWithComposite result)
        {
            var count = result.CompositeEntities?.Count ?? 0;
            string message = $"I found {count}  intents.";
            await context.PostAsync(message);

            foreach (var intentCount in result.Intents)
            {
                string intentValue = "";
                intentValue += intentCount.Intent + " ";
                await context.PostAsync(intentValue);
            }

            context.Wait(this.MessageReceivedAsync);
        }
        public async Task ProgramDeLucru(IDialogContext context, LuisResultWithComposite result)
        {
            var count = result.CompositeEntities?.Count ?? 0;
            string message = $"I found {count}  intents.";
            await context.PostAsync(message);

            foreach (var intentCount in result.Intents)
            {
                string intentValue = "";
                intentValue += intentCount.Intent + " ";
                await context.PostAsync(intentValue);
            }

            context.Wait(this.MessageReceivedAsync);
        }

    }


}
