const Client = require("./client.js"); // This imports the class from the index.js file

const app_id = "app_id";
const app_sec = "app_sec";

const client = new Client(app_id, app_sec); // This creates an instance of the class

client.getPackages().then((response) => {
  console.log(response); // This will log the response from the getPackages function
});

client.getSenders().then((response) => {
  console.log(response); // This will log the response from the getSenders function
});

client
  .sendMessage("Hello World", "1234567890", "SenderName")
  .then((response) => {
    console.log(response); // This will log the response from the sendMessage function
  });
