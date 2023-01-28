const request = require('request');
const base64 = require('base64-js');

class Client {
    constructor(app_id, app_sec) {
        this.app_id = app_id;
        this.app_sec = app_sec;
        this.base_url = "https://api-sms.4jawaly.com/api/v1/";
        this.app_hash = base64.fromByteArray(Buffer.from(`${app_id}:${app_sec}`)).toString();
    }

    getPackages(kwargs = {}) {
        let query = {
            is_active: 1,
            order_by: "id",
            order_by_type: "desc",
            page: 1,
            page_size: 10,
            return_collection: 1
        }
        Object.assign(query, kwargs);
        let url = `${this.base_url}account/area/me/packages?${new URLSearchParams(query)}`;
        let headers = {
            Accept: "application/json",
            "Content-Type": "application/json",
            Authorization: `Basic ${this.app_hash}`
        }
        return new Promise((resolve, reject) => {
            request.get({ url, headers }, (error, response, body) => {
                if (error) reject(error);
                else resolve(JSON.parse(body));
            });
        });
    }

    getSenders(kwargs = {}) {
        let query = {
            page_size: 10,
            page: 1,
            status: 1,
            sender_name: "",
            is_ad: "",
            return_collection: 1
        }
        Object.assign(query, kwargs);
        let url = `${this.base_url}account/area/senders?${new URLSearchParams(query)}`;
        let headers = {
            Accept: "application/json",
            "Content-Type": "application/json",
            Authorization: `Basic ${this.app_hash}`
        }
        return new Promise((resolve, reject) => {
            request.get({ url, headers }, (error, response, body) => {
                if (error) reject(error);
                else resolve(JSON.parse(body));
            });
        });
    }

    sendMessage(text, numbers, sender) {
        let messages = { messages: [{ text, numbers, sender }] };
        let headers = {
            Accept: "application/json",
            "Content-Type": "application/json",
            Authorization: `Basic ${this.app_hash}`
        }
        let url = `${this.base_url}account/area/sms/send`;
        return new Promise((resolve, reject) => {
            request.post({ url, headers, json: messages }, (error, response, body) => {
                if (error) reject(error);
                else resolve(body);
            });
        });
    }
}

module.exports = Client;
