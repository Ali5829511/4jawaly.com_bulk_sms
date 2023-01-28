To use the Client class, you will first need to import it at the top of your file:

```
const {Client} = require('./path/to/file');
```

Then you can create a new instance of the Client class by passing in your app_id and app_sec as arguments:

```
const client = new Client(app_id, app_sec);
```

Methods
The class has three methods:

getPackages(kwargs = {}): Returns a promise that resolves to the package information.
getSenders(kwargs = {}): Returns a promise that resolves to the senders information.
sendMessage(text, numbers, sender): Returns a promise that resolves to the sending message information.


Make sure you have request and base64-js package installed

```
npm install request
npm install base64-js
```

Note that the sendMessage method returns a promise, so you can use the .then() and .catch() methods to handle the response.

