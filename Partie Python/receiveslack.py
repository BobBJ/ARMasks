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


def SendSlack():
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


"""'permalink': 'https://armasks.slack.com/files/U03ARQ203F0/F03E2HS7C64/dayatthebeach222456.jpg', 'permalink_public': 'https://slack-files.com/T03BMF9BX08-F03E2HS7C64-5d1738bd16', 'comments_count': 0, 'is_starred': False, 
'shares': {'public': {'C03AR3EGX54': [{'reply_users': [], 'reply_users_count': 0, 'reply_count': 0, 'ts': '1651161696.895989', 'channel_name': 'ar-masks-landmarks', 'team_id': 'T03BMF9BX08', 'share_user_id': 'U03ARQ203F0'}]}}, 'permalink': 'https://armasks.slack.com/files/U03ARQ203F0/F03E2HS7C64/dayatthebeach222456.jpg', 'permalink_public': 'https://slack-files.com/T03BMF9BX08-F03E2HS7C64-5d1738bd16', 'comments_count': 0, 'is_starred': False, 'shares': {'public': {'C03AR3EGX54': [{'reply_users': [], 'reply_users_count': 0, 'reply_count': 0, 'ts': '1651161696.895989', 'channel_name': 'ar-masks-landmarks', 'team_id': 'T03BMF9BX08', 'share_user_id': 'U03ARQ203F0'}]}}, 'channels': ['C03AR3EGX54'], 'groups': [], 'ims': [], 'has_rich_preview': False}
'channels': ['C03AR3EGX54'], 'groups': [], 'ims': [], 'has_rich_preview': False}"""

"""
"""


"""slack_token = 'xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ'
slack_channel = '#ar-masks-landmarks'
slack_icon_emoji = ':see_no_evil:'
slack_user_name = 'Double Images Monitor'
print(requests.get('https://slack.com/api/files.list', headers={'Authorization': 'Bearer %s' % slack_token}
                   ))"""

"""with open("images/Lea.png", "rb") as image:
    f = image.read()
    b = bytearray(f)
print(greet2('Amazing day at the beach. Check out this photo.',
             'DayAtTheBeach.jpg',
             b)) """

"""
https://api.slack.com/api/files.list?token=xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ"""

"""{
                       'token': slack_token,
                       'channels': slack_channel,
                   }"""

"""response = requests.get("https://i.imgur.com/ExdKOOz.png")

file = open("sample_image.png", "wb")
file.write(response.content)
file.close()"""
