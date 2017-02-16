using Newtonsoft.Json;
using System;

namespace Epicom.Http.Client.Exceptions
{
    public class EpicomHttpException : Exception
    {
        public EpicomHttpException(string url, int statusCode, string response, string request, string traceId = null)
        {
            Url = url;
            StatusCode = statusCode;
            Response = response ?? "sem dados de response";
            Request = request ?? "sem dados de request";
            TraceId = traceId;

            Data["Url"] = url;
            Data["StatusCode"] = statusCode;
            Data["Request"] = Request;
            Data["Response"] = Response;
            Data["TraceId"] = TraceId;
        }

        public string Url { get; private set; }
        public int StatusCode { get; private set; }
        public string Response { get; private set; }
        public string Request { get; private set; }
        public string TraceId { get; private set; }

        public override string Message
        {
            get { return GetEpicomMessage(Response) ?? "Uma chamada para a API da Epicom retornou um erro"; }
        }

        public int? Code
        {
            get { return GetEpicomCode(Response); }
        }

        public dynamic Details
        {
            get { return GetDetails(Response); }
        }

        private dynamic GetDetails(string json)
        {
            dynamic details = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject<dynamic>(json);
                details = data.details;
            }
            catch (Exception)
            {
                //  'details' doesn't exist
            }
            return details;
        }

        private string GetEpicomMessage(string json)
        {
            string message = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject<dynamic>(json);
                message = data.message;
            }
            catch (Exception)
            {
                //  'message' doesn't exist
            }
            return message;
        }

        private int? GetEpicomCode(string json)
        {
            int? code = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject<dynamic>(json);
                code = data.code;
            }
            catch (Exception)
            {
                //  'code' doesn't exist
            }
            return code;
        }
    }
}
