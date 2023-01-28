package main

import (
    "fmt"
    "net/url"
    "./client"
)

func main() {
    c := client.NewClient("app_id", "app_sec")
    response, _ := c.GetPackages(url.Values{})
    fmt.Println(response)
    response2, _ := c.GetSenders(url.Values{})
    fmt.Println(response2)
	response3, _ := c.SendMessage("Hello World!", []string{"1234567890", "0987654321"}, "sender_name")
	fmt.Println(response3)
}
