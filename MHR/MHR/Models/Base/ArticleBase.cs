using System;
using Newtonsoft.Json;
using MHR.Support;

namespace MHR.Models.Base
{
    public class ArticleBase : BaseBindableObject
    {
         // Id Start
		string _id;
		[JsonProperty(PropertyName = "_id")]
		public string Id
		{
			get { return _id; }
			set { SetValue(ref _id, value); }
		}
		 // Id End 
        
        string articleby;
        [JsonProperty(PropertyName = "ArticleBy")]
        public string ArticleBy
        {
            get { return articleby; }
            set { SetValue(ref articleby, value); }
        }
        
        string articleid;
        [JsonProperty(PropertyName = "ArticleID")]
        public string ArticleID
        {
            get { return articleid; }
            set { SetValue(ref articleid, value); }
        }
        
        string articlemedia;
        [JsonProperty(PropertyName = "ArticleMedia")]
        public string ArticleMedia
        {
            get { return articlemedia; }
            set { SetValue(ref articlemedia, value); }
        }
        
        string articlereference;
        [JsonProperty(PropertyName = "ArticleReference")]
        public string ArticleReference
        {
            get { return articlereference; }
            set { SetValue(ref articlereference, value); }
        }
        
        string articletitle;
        [JsonProperty(PropertyName = "ArticleTitle")]
        public string ArticleTitle
        {
            get { return articletitle; }
            set { SetValue(ref articletitle, value); }
        }
        
        string articletrailer;
        [JsonProperty(PropertyName = "ArticleTrailer")]
        public string ArticleTrailer
        {
            get { return articletrailer; }
            set { SetValue(ref articletrailer, value); }
        }
        
        int mediaorderno;
        [JsonProperty(PropertyName = "MediaOrderNo")]
        public int MediaOrderNo
        {
            get { return mediaorderno; }
            set { SetValue(ref mediaorderno, value); }
        }
        
    }
}