import chardet
import requests
import random
import json


class Greeter():

    def __init__(self):
        pass

    def greet(self, text, blocks=None):
        slack_token = 'xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ'
        slack_channel = '#ar-masks-landmarks'
        slack_icon_emoji = ':see_no_evil:'
        slack_user_name = 'Double Images Monitor'
        return requests.post('https://slack.com/api/chat.postMessage', {
            'token': slack_token,
            'channel': slack_channel,
            'text': text,
            'icon_emoji': slack_icon_emoji,
            'username': slack_user_name,
            'blocks': json.dumps(blocks) if blocks else None
        }).json()

    def greet2(text, file_name, file_bytes, path, file_type=None, title=None):
        slack_token = 'xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ'
        slack_channel = '#ar-masks-landmarks'
        slack_icon_emoji = ':see_no_evil:'
        slack_user_name = 'Double Images Monitor'
        with open(path, "rb") as image:
         f = image.read()
         b = bytearray(f)
        return requests.post(
            'https://slack.com/api/files.upload',
            {
                'token': slack_token,
                'filename': file_name,
                'channels': slack_channel,
                'initial_comment': text,
                'title': title
            },files={'file': b}).json()
        
"""
,
                'filetype': file_type
    """