import base64
import requests
import json

class Client:
    def __init__(self, app_id, app_sec):
        self.app_id = app_id
        self.app_sec = app_sec
        self.base_url = "https://api-sms.4jawaly.com/api/v1/"
        self.app_hash = base64.b64encode(f"{app_id}:{app_sec}".encode()).decode()

    def get_packages(self, **kwargs):
        query = {
            "is_active": 1,
            "order_by": "id",
            "order_by_type": "desc",
            "page": 1,
            "page_size": 10,
            "return_collection": 1
        }
        query.update(kwargs)
        url = f"{self.base_url}account/area/me/packages?{query}"
        headers = {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "Authorization": f"Basic {self.app_hash}"
        }
        response = requests.get(url, headers=headers)
        return response.json()

    def get_senders(self, **kwargs):
        query = {
            "page_size": 10,
            "page": 1,
            "status": 1,
            "sender_name": "",
            "is_ad": "",
            "return_collection": 1
        }
        query.update(kwargs)
        url = f"{self.base_url}account/area/senders?{query}"
        headers = {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "Authorization": f"Basic {self.app_hash}"
        }
        response = requests.get(url, headers=headers)
        return response.json()
    
    def send_message(self, text, numbers, sender):
        messages = {"messages": [{"text": text, "numbers": numbers, "sender": sender}]}
        headers = {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': f'Basic {self.app_hash}'
        }
        url = f'{self.base_url}account/area/sms/send'
        response = requests.post(url, headers=headers, json=messages)
        return response.json()