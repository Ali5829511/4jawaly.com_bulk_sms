from client import Client

client = Client(app_id, app_sec)
response = client.get_packages()
print(response)

response = client.get_senders()
print(response)

response = client.send_message("test send message", ["966xxxx"], "test")
print(response)