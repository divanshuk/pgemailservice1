using System.Net;


public static async Task<HttpResponseMessage> Run(HttpRequestMessage req)
{
    bool output = false;
    // parse query parameter
    string fromemail = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "fromemail", true) == 0)
        .Value;

        string toemail = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "toemail", true) == 0)
        .Value;

    string subject = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "subject", true) == 0)
        .Value;
    string body = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "body", true) == 0)
        .Value;

    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Set name to query string or body data
    fromemail = fromemail ?? data?.fromemail;
    toemail = toemail ?? data?.toemail;
    subject = subject ?? data?.subject;
    body = body ?? data?.body;

    output = SendEmail(fromemail, toemail, subject, body); 
    return output == false
        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
        : req.CreateResponse(HttpStatusCode.OK, "Success");
}

private static bool SendEmail(string fromemail, string toemail, string subject, string body)
{
    //logic to send email
    bool isEmailSuccess = true;
    return isEmailSuccess;
}
