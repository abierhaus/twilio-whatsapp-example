# Twilio WhatsApp .NET Blazor Example

This Blazor App demonstrates how to send and receive WhatsApp messages within an Blazor environment.
We use the Twilio API to send WhatsApp with a simple blazor page. For receicing WhatsApp we use the sugessted Twilio WebHook approach


<img alt="chrome_2021-02-22_13-04-52" src="https://user-images.githubusercontent.com/18400458/108706288-adc08780-750e-11eb-9124-71a371bea44e.png">


## Getting started sending Whatsapp

1. Follow the instructions on https://www.twilio.com/console/sms/whatsapp/sandbox to enable your sandbox
2. Find your Account Sid and Token at twilio.com/console and set it in the appsettings.json
2. Run the sample
4. Open the send page and send yourself a WhatsApp


## Configure receiving items
For receicing replies we need to configure the Twilio webhook. Note: It is necessary that your application is public available via the internet

1. Deploy application to your webhoster
2. Open https://www.twilio.com/console/sms/whatsapp/sandbox
3. Set "WHEN A MESSAGE COMES IN" parameter with  https://YOURDOMAINAPP.net/WhatsAppReceiver
4. Reply to the received WhatsApp
5. Open the Receive page. You should see the reply


## Remarks
The demo makes use of https://www.litedb.org/ to demonstrate how to store data. When you are using the code in your environmennt you might replace it with your database provider.