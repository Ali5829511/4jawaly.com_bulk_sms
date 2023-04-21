const request = require('request');
const base64 = require('base-64');

const app_id = '27WOaZb64UJ1RMPnyxsIPaefiwwnAYn7f7109ahK';
const app_sec = 'NoAvpN3kP9VzZT7aWr6l2dzqhhaJdV8oOaWzhPYS6chmMYrJobGz0OkhPKxwfJSPZ1e5czzbpC04m78ikaHeY6qT11tpdVJSL1C9';
const app_hash = base64.encode(`${app_id}:${app_sec}`);
const base_url = 'https://api-sms.4jawaly.com/api/v1/';

const query = {};  // Define the query parameters here if needed

let url = base_url + 'account/area/senders?' + Object.entries(query).map(([k, v]) => `${k}=${v}`).join('&');

const headers = {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
    'Authorization': `Basic ${app_hash}`,
};

request.get({url, headers}, (err, response, body) => {
    if (err) {
        console.error('Error executing request:', err);
        return;
    }

    const responseJSON = JSON.parse(body);

    const code = responseJSON.code;
    console.log('error code:', code);

    if (code === 200) {
        const data = responseJSON.items.data;
        for (const item of data) {
            console.log(item.sender_name);
        }
    } else {
        console.log('message:', responseJSON.message);
    }
});
