import chardet
import requests
import random
import json
#import urllib.request

def SendSlack(text, file_name, file_bytes, file_type=None, title=None):
        slack_token = 'xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ'
        slack_channel = '#ar-masks-landmarks'
        slack_icon_emoji = ':see_no_evil:'
        slack_user_name = 'Double Images Monitor'
        return requests.post('https://slack.com/api/files.upload',
            {
                'token': slack_token,
                'filename': file_name,
                'channels': slack_channel,
                'filetype': file_type,
                'initial_comment': text,
                'title': title
            },
            files={'file': file_bytes}).json()
            