package client

import (
    "encoding/base64"
    "net/http"
    "net/url"
    "bytes"
    "encoding/json"
)

type Client struct {
    app_id    string
    app_sec   string
    base_url  string
    app_hash  string
}

func (c *Client) GetPackages(query url.Values) (map[string]interface{}, error) {
    query.Set("is_active", "1")
    query.Set("order_by", "id")
    query.Set("order_by_type", "desc")
    query.Set("page", "1")
    query.Set("page_size", "10")
    query.Set("return_collection", "1")

    url := c.base_url + "account/area/me/packages?" + query.Encode()
    req, _ := http.NewRequest("GET", url, nil)
    req.Header.Add("Accept", "application/json")
    req.Header.Add("Content-Type", "application/json")
    req.Header.Add("Authorization", "Basic "+c.app_hash)

    client := &http.Client{}
    resp, err := client.Do(req)
    if err != nil {
        return nil, err
    }
    defer resp.Body.Close()

    var data map[string]interface{}
    json.NewDecoder(resp.Body).Decode(&data)
    return data, nil
}

func (c *Client) GetSenders(query url.Values) (map[string]interface{}, error) {
    query.Set("page_size", "10")
    query.Set("page", "1")
    query.Set("status", "1")
    query.Set("sender_name", "")
    query.Set("is_ad", "")
    query.Set("return_collection", "1")

    url := c.base_url + "account/area/senders?" + query.Encode()
    req, _ := http.NewRequest("GET", url, nil)
    req.Header.Add("Accept", "application/json")
    req.Header.Add("Content-Type", "application/json")
    req.Header.Add("Authorization", "Basic "+c.app_hash)

    client := &http.Client{}
    resp, err := client.Do(req)
    if err != nil {
        return nil, err
    }
    defer resp.Body.Close()

    var data map[string]interface{}
    json.NewDecoder(resp.Body).Decode(&data)
    return data, nil
}

func (c *Client) SendMessage(text string, numbers []string, sender string) (map[string]interface{}, error) {
    messages := map[string][]struct {
        Text    string   `json:"text"`
        Numbers []string `json:"numbers"`
        Sender  string   `json:"sender"`
    }{
        "messages": []struct {
            Text    string   `json:"text"`
            Numbers []string `json:"numbers"`
            Sender  string   `json:"sender"`
        }{
            {
                Text:    text,
                Numbers: numbers,
                Sender:  sender,
            },
        },
    }
    body, err := json.Marshal(messages)
    if err != nil {
        return nil, err
    }

    url := c.base_url + "account/area/sms/send"
    req, err := http.NewRequest("POST", url, bytes.NewBuffer(body))
    if err != nil {
        return nil, err
    }

    req.Header.Set("Accept", "application/json")
    req.Header.Set("Content-Type", "application/json")
    req.Header.Set("Authorization", "Basic "+c.app_hash)

    client := &http.Client{}
    resp, err := client.Do(req)
    if err != nil {
        return nil, err
    }
    defer resp.Body.Close()

    var data map[string]interface{}
    json.NewDecoder(resp.Body).Decode(&data)
    return data, nil
}

func NewClient(app_id, app_sec string) *Client {
    c := &Client{app_id: app_id, app_sec: app_sec}
    c.base_url = "https://api-sms.4jawaly.com/api/v1/"
    c.app_hash = base64.StdEncoding.EncodeToString([]byte(app_id + ":" + app_sec))
    return c
}