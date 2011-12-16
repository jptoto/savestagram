using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace ScreenSaver
{
    class InstagramApi
    {        
        const string BaseUrl = "https://api.instagram.com/v1/users/self/feed";

        readonly string _oauthToken;

        public InstagramApi(string oauthToken)
        {
            _oauthToken = oauthToken;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = BaseUrl;
            request.AddParameter("access_token", _oauthToken, ParameterType.UrlSegment); // used on every request
            var response = client.Execute<T>(request);
            return response.Data;
        }

        
    }
}
