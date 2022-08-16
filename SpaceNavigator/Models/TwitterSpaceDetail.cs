namespace SpaceNavigator.Models
{
    public class TwitterSpaceDetail
    {
        public List<TwitterSpaceDetailData> data { get; set; }
        public TwitterSpaceDetailMeta meta { get; set; }
    }

    public class TwitterSpaceDetailData
    {
        public string id { get; set; }
        public bool is_ticketed { get; set; }
        public DateTime updated_at { get; set; }
        public int subscriber_count { get; set; }
        public DateTime started_at { get; set; }
        public string title { get; set; }
        public List<string> speaker_ids { get; set; }
        public int participant_count { get; set; }
        public DateTime created_at { get; set; }
        public List<string> topic_ids { get; set; }
        public string creator_id { get; set; }
        public string state { get; set; }
        public List<string> host_ids { get; set; }
        public string lang { get; set; }
        public List<string> invited_user_ids { get; set; }
        public DateTime? scheduled_start { get; set; }
    }

    public class TwitterSpaceDetailMeta
    {
        public int result_count { get; set; }
    }
}
