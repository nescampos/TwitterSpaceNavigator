using System.ComponentModel;

namespace SpaceNavigator.Models
{
    public class IndexNavigatorFormModel
    {
        public string? Title { get; set; }
        public string? Language { get; set; }

        [DisplayName("Is live?")]
        public bool? IsLive { get; set; }


    }
}
