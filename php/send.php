<?php
$apiKey = "api key";
$apiSecret = "api secret";
$appHash = base64_encode("$apiKey:$apiSecret");

$messages = array(
    "messages" => array(
        array(
            "text" => "test",
            "numbers" => array("9665000000"),
            "sender" => "4jawaly"
        )
    )
);

$url = "https://api-sms.4jawaly.com/api/v1/account/area/sms/send";
$headers = array(
    "Accept: application/json",
    "Content-Type: application/json",
    "Authorization: Basic $appHash"
);

$ch = curl_init();
curl_setopt($ch, CURLOPT_URL, $url);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
curl_setopt($ch, CURLOPT_POST, true);
curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($messages));
curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);

$response = curl_exec($ch);
$httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);

curl_close($ch);

if ($httpCode == 200) {
    $responseJson = json_decode($response, true);
    if (isset($responseJson["messages"][0]["err_text"])) {
        echo $responseJson["messages"][0]["err_text"];
    } else {
        echo "تم الارسال بنجاح  " . " job id:" . $responseJson["job_id"];
    }
} elseif ($httpCode == 400) {
    $responseJson = json_decode($response, true);
    echo $responseJson["message"];
} elseif ($httpCode == 422) {
    echo "نص الرسالة فارغ";
} else {
    echo "محظور بواسطة كلاودفلير. Status code: $httpCode";
}
?>
