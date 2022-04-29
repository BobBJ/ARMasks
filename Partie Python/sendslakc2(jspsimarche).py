from slack import WebClient
"""# link to files.upload method 
url = "https://slack.com/api/files.upload" 
# this is where you add your query string. Please chage token value 
querystring = {"token":"xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ"} 
# this is where you define who do you want to send it to. Change channels to your target one 
payload = { "channels":"C03AR3EGX54"} 
file_upload = { 
"file":("hello-world.txt", 
open("hello-world.txt", 'rb'), 'text/plain') 
} 
headers = { "Content-Type": "multipart/form-data", } 
response = requests.post(url, data=payload, params=querystring, files=file_upload)
print(response)"""
"""
my_file = {'file': ('./hello-world.txt',
                    open('./hello-world.txt', 'r'), 'txt')}

payload = {
    "filename": "aaaa.txt",
    "token": 'xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ',
    "channels": 'C03AR3EGX54',
}

x = requests.post("https://slack.com/api/files.upload",
                  params=payload, files=my_file)

print(x)
print(x.json())"""

## Send image to a channel
# Get an image in your environment and transform this in bytes
img = open("Lea.png", 'rb').read()
# Authenticate to the Slack API via the generated token
client = WebClient("xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ")
# Send the image
client.files_upload(
        channels = "C03AR3EGX54",
        initial_comment = "That's one small step for man, one giant leap for mankind.",
        filename = "Apollo 11",
        content = img)
