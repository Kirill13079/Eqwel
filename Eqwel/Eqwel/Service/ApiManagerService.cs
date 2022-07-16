using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Eqwel.Enums;
using Eqwel.Interfaces;
using Eqwel.Models;
using Eqwel.ViewModels.Data;
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Eqwel.Service
{
    public class ApiManagerService : IApiManager
    {
        public ApiManagerService()
        {
            Barrel.ApplicationId = "CachingData";
        }

        public async Task<List<DictoinaryViewModel>> GetDictionaryAsync()
        {
            try
            {
                string url = "https://kirill13079.github.io/eqwel-list/";

                if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired(key: url))
                {
                    return Barrel.Current.Get<List<DictoinaryViewModel>>(key: url);
                }

                var result = await ApiCallerService.Get(url);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    string response = "";

                    var parser = new HtmlParser();

                    parser.ParseDocument(result);

                    IHtmlDocument angle = parser.ParseDocument(result);

                    response = angle.QuerySelectorAll("span")[0].InnerHtml;

                    var dictionaryResponse = JsonConvert.DeserializeObject<List<DictionaryResponseModel>>(response);

                    if (dictionaryResponse != null)
                    {
                        var dictionaryViewModel = new List<DictoinaryViewModel>();

                        foreach (var item in dictionaryResponse)
                        {
                            dictionaryViewModel.Add(new DictoinaryViewModel
                            {
                                SourceLanguage = Language.English,
                                TargetLanguage = Language.Russian,
                                Translation = new TranslationModel
                                {
                                    Heading = item.English,
                                    Transltion = item.Russian,
                                    Transcription = item.Transcription
                                }
                            });
                        }

                        Barrel.Current.Add(key: url, data: dictionaryViewModel, expireIn: TimeSpan.FromDays(1));

                        return dictionaryViewModel;
                    }
                }
            }
            catch
            {

            }

            return null;
        }
    }
}
