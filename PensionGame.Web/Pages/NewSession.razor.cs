using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Web.Data;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace PensionGame.Web.Pages
{
    public partial class NewSession
    {
        readonly NewSessionModel session = new NewSessionModel(new StartupParameters(30000, 20000, 25, 65), RandName());

        EditContext editContext = new EditContext(new object());

        protected override async void OnInitialized()
        {
            editContext = new EditContext(session);
        }

        private async Task HandleValidSubmit()
        {
            var sessionId = await SessionService.CreateSession(session.StartupParametersModel, session.Name);
            navigationManager.NavigateTo($"/game/{sessionId.Id}");
        }

        private static string RandName()
        {
            string[] names_1 = new string[] { "Shymo", "Anička", "Adam", "Bači", "Miki", "Matovič", "Sulík", "Ciťo", "Peťo 2D", "Peťo 3D", "Donald Trump", "Joe Biden", "Babiš", "Your mom", "A scientist", "An epidemologist", "My boss" };
            string[] names_2 = new string[] { "is", "is best in", "is looking forward to", "is cooking up", "has", "took a photo of", "found a photo of", "doesn't have", "fixed", "created", "found", "knows nothing about", "predicts", "issued a warning about", "waits for", "saves for", "wants", "lost", "won", "won 6 times", "is looking for", "looks like", "caught", "cares about", "doesn't give a fuck about", "would like" };
            string[] names_3 = new string[] { "a huge", "an expensive", "a dirty", "a toy", "a cheap", "a fancy", "a godlike", "a tiny", "an overpriced", "a bad", "a sleepy", "a malicious", "a stolen", "a massive", "your" };
            string[] names_4 = new string[] { "vaccine", "vagina", "pension", "Sputnik", "covid", "something", "dick", "bitch", "pussy", "election", "election result", "election fraud", "joke", "result", "mom", "victory", "loss" };

            Random rand = new Random();
            var name_1 = names_1[rand.Next(0, names_1.Length)];
            var name_2 = names_2[rand.Next(0, names_2.Length)];
            var name_3 = names_3[rand.Next(0, names_3.Length)];
            var name_4 = names_4[rand.Next(0, names_4.Length)];

            return $"{name_1} {name_2} {name_3} {name_4}";
        }
    }
}