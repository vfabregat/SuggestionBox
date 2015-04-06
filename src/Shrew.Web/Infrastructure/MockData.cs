
//using System.Collections.Generic;
//using System.Linq;
//using Shrew.Web.Models.Domain;
//namespace Shrew.Web.Infrastructure
//{
//    public static class MockData
//    {
//        static List<Box> suggestionBoxes = new List<Box>();
//        public static IQueryable<Box> GetFakeSuggestionBoxes()
//        {

//            var tokiotaBox = new Box("Tokiota");
//            tokiotaBox.Id = 1;
//            tokiotaBox.Publish();
//            tokiotaBox.AddSuggestion("molaria tener tickets restaurants");

//            var formacion = new Box("Formación");
//            tokiotaBox.Id = 2;
//            formacion.Publish();
//            formacion.AddSuggestion("Quiero aprender cosas chulas");

//            var jueveX = new Box("JueveX");
//            jueveX.Id = 3;
//            jueveX.Publish();
//            jueveX.AddSuggestion("siempre a fin de mes");
//            jueveX.AddSuggestion("Es una mierda siempre estar viendo cosas de IT");
//            jueveX.AddSuggestion("siempre a fin de mes");
//            jueveX.AddSuggestion("Es una mierda siempre estar viendo cosas de IT");
//            jueveX.AddSuggestion("siempre a fin de mes");
//            jueveX.AddSuggestion("Es una mierda siempre estar viendo cosas de IT");
//            jueveX.AddSuggestion("siempre a fin de mes");
//            jueveX.AddSuggestion("Es una mierda siempre estar viendo cosas de IT");
//            jueveX.AddSuggestion("siempre a fin de mes");
//            jueveX.AddSuggestion("Es una mierda siempre estar viendo cosas de IT");
//            for (int i = 0; i < 10; i++)
//            {
//                jueveX.Suggestions.First().VoteUp("fake user" + i);

//            }
//            suggestionBoxes.Add(tokiotaBox);
//            suggestionBoxes.Add(formacion);
//            suggestionBoxes.Add(jueveX);
//            return suggestionBoxes.AsQueryable();
//        }

//        public static void AddSuggestion(string body, int boxId)
//        {
//            var suggestion = suggestionBoxes.First(s => s.Id == boxId);
//            suggestion.AddSuggestion(body);
//        }
//    }
//}