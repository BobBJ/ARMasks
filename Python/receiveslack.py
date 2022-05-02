import chardet
import requests
import random
import json
import re
import sys
from PIL import Image
from io import BytesIO
import urllib.request
#import urllib.request


def GetSlack():
    tokenSlackAuth = "Bearer xoxp-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ"
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
    
    #print(response2)

    t = response2['file']
    t2 = t['permalink_public']
    print(t2)
    privatelink = t['url_private_download']
    privatelinksplit = privatelink.split('/')
    pug = t2.split('-')
    pugret = pug[-1]
    teamidstart = pug[1]
    teamidsplit = teamidstart.split('/')
    teamID = teamidsplit[-1]
    linkstart = "https://files.slack.com/files-pri/"
    fileID = t['id']
    fileName = privatelinksplit[-1]
    link = linkstart + teamID + "-" + fileID + "/" + fileName + "?pub_secret=" + pugret
    print(privatelink)
    print(link)
    urllib.request.urlretrieve(link, "sample.jpg")

