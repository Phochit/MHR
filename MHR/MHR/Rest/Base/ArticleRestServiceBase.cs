using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MHR.Models;
using Newtonsoft.Json;

namespace MHR.Rest.Base
{
    public class ArticleRestServiceBase : RestClient
    {
        const string ArticleApi = "article/";

        //GET
        /// <summary>
        /// Get the complete list of Articles
        /// </summary>
        /// <returns>Article List</returns>
        public async Task<ObservableCollection<Article>> GETList()
        {
            ObservableCollection<Article> articlelist = new ObservableCollection<Article>();
            try
            {
                var content = await Client.GetStringAsync(ArticleApi);
                articlelist = JsonConvert.DeserializeObject<ObservableCollection<Article>>(content);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"				ERROR {0}", e);
            }
            return articlelist;
        }
    }
}
