using Microsoft.AspNetCore.Mvc.Rendering;

namespace SpaceNavigator.Models
{
    public class IndexNavigatorViewModel
    {
        public TwitterSpaceDetail? Response { get; set; }
        public List<SelectListItem> Languages { get; set; }
        public List<SelectListItem> IsLive { get; set; }
        public IndexNavigatorFormModel Form { get; set; }

        public IndexNavigatorViewModel()
        {
            Languages = GetLanguages();
            IsLive = new List<SelectListItem> { new SelectListItem("Yes",true.ToString()), new SelectListItem("No", false.ToString()) };
        }

        public string ReturnLanguage(string code)
        {
            string nameLanguage = string.Empty;
            var language = Languages.FirstOrDefault(x => x.Value == code);
            if(language != null)
            {
                nameLanguage = language.Text;
            }
            return nameLanguage;
        }

        private List<SelectListItem>? GetLanguages()
        {
            var languages = new List<SelectListItem>();
            languages.Add(new SelectListItem { Text = "Arabic", Value= "ar" });
            languages.Add(new SelectListItem { Text = "Armenian", Value = "hy" });
            languages.Add(new SelectListItem { Text = "Chinese", Value = "zh" });
            languages.Add(new SelectListItem { Text = "Danish", Value = "da" });
            languages.Add(new SelectListItem { Text = "English", Value = "en" });
            languages.Add(new SelectListItem { Text = "Finnish", Value = "fi" });
            languages.Add(new SelectListItem { Text = "French", Value = "fr" });
            languages.Add(new SelectListItem { Text = "German", Value = "de" });
            languages.Add(new SelectListItem { Text = "Hindi", Value = "hi" });
            languages.Add(new SelectListItem { Text = "Hebrew", Value = "iw" });
            languages.Add(new SelectListItem { Text = "Indonesian", Value = "in" });
            languages.Add(new SelectListItem { Text = "Italian", Value = "it" });
            languages.Add(new SelectListItem { Text = "Japanese", Value = "ja" });
            languages.Add(new SelectListItem { Text = "Kazakh", Value = "kk" });
            languages.Add(new SelectListItem { Text = "Korean", Value = "ko" });
            languages.Add(new SelectListItem { Text = "Norwegian", Value = "no" });
            languages.Add(new SelectListItem { Text = "Polish", Value = "pl" });
            languages.Add(new SelectListItem { Text = "Portuguese", Value = "pt" });
            languages.Add(new SelectListItem { Text = "Romanian", Value = "ro" });
            languages.Add(new SelectListItem { Text = "Russian", Value = "ru" });
            languages.Add(new SelectListItem { Text = "Spanish", Value = "es" });
            languages.Add(new SelectListItem { Text = "Swedish", Value = "sv" });
            languages.Add(new SelectListItem { Text = "Turkish", Value = "tr" });
            languages.Add(new SelectListItem { Text = "Ukranian", Value = "uk" });
            return languages;
        }
    }
}
