using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System;
using System.Net;
using System.Linq;


class test
{
    static void Main(string[] args)
    {
        NameValueCollection parameters = new NameValueCollection();

        string tokenSlackAuth = "Bearer xoxp-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ";
        string tokenSlackAuth2 = "xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ";
        string tokenuser = "xoxp-3395519405008-3365112776422-3447743329173-c3e949dd2a80eeb60006ca2910f98346";
        string channelId = "C03AR3EGX54";
        parameters["channels"] = channelId;
        string URI = "https://slack.com/api/files.list";
        string token = "xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ";

        String LinkFinal = "";
        String IDfile = "";
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + tokenSlackAuth2;
            wc.Headers[HttpRequestHeader.Accept] = "application/json";
            wc.QueryString = parameters;
            String responseBytesS = wc.DownloadString(URI);
            List<string> result = responseBytesS?.Split("id").ToList();
            List<string> resultsplit = result[result.Count - 1]?.Split(',').ToList();
            List<string> resultsplitID = resultsplit[0]?.Split('"').ToList();
            List<string> resultsplitLinkDebut = resultsplit[19]?.Split("/files.slack.com\\/").ToList();
            List<string> resultsplitLinkMoyen = resultsplitLinkDebut[1]?.Split('\\').ToList();
            List<string> resultsplitLinkPug = resultsplit[46]?.Split('-').ToList();
            IDfile = resultsplitID[2];
            String IDTeamUser = resultsplitLinkMoyen[1];
            String NomFile = resultsplitLinkMoyen[3];
            String Pug = resultsplitLinkPug[3];

            String Link = "https://files.slack.com/files-pri" + IDTeamUser + NomFile + "?pub_secret=" + Pug;
            LinkFinal = Link.Replace("\"", "");
            Console.Write("\n");
        }

        URI = "https://slack.com/api/files.sharedPublicURL";
        parameters["file"] = IDfile;

        using (WebClient wc2 = new WebClient())
        {
            wc2.Headers[HttpRequestHeader.Authorization] = "Bearer " + tokenuser;
            wc2.Headers[HttpRequestHeader.Accept] = "application/json";
            wc2.QueryString = parameters;
            String responseBytesS = wc2.DownloadString(URI);
        }

        Console.Write(LinkFinal);

        using (WebClient webClient = new WebClient())
        {
            byte[] data = webClient.DownloadData(LinkFinal);
        }


    }
}

/*tokenSlackAuth = "Bearer xoxp-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ"
    tokenSlackAuth2 = "xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ"
    tokenuser = "xoxp-3395519405008-3365112776422-3447743329173-c3e949dd2a80eeb60006ca2910f98346"
    headers = {'Authorization': 'Bearer ' + tokenSlackAuth2}
    response = requests.get(
     url="https://slack.com/api/files.list", headers=headers).json()


    x = response['files'][-1]['id']
    myobj = {'file': x}
    #headers2 = {'Authorization': 'Bearer ' + tokenuser, 'file': x}
    headers3 = {'Authorization': 'Bearer ' + tokenuser}
    # print(x)
    response2 = requests.post(
      url="https://slack.com/api/files.sharedPublicURL", headers=headers3, data=myobj).json()

    */