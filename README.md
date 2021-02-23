# Twilio API WhatsApp .NET Blazor Example

This Blazor App demonstrates how to send and receive WhatsApp messages within an Blazor environment.

The goal is to provide a very easy quick-start application to send and receive WhatsApp messages via the Twilio API

We use the Twilio MessageResource API to send WhatsApp Messages. For receicing WhatsApp we use the sugessted Twilio WebHook approach

Find the complete article here: https://alexbierhaus.medium.com/twilio-api-whatsapp-net-blazor-example-f7d226da5367


<img alt="chrome_2021-02-22_13-04-52" src="https://user-images.githubusercontent.com/18400458/108706288-adc08780-750e-11eb-9124-71a371bea44e.png">

The sample should also work with Twilio SMS, however, we did not test it yet.

## Getting started sending WhatsApp messages

1. Follow the instructions on https://www.twilio.com/console/sms/whatsapp/sandbox to enable your sandbox
2. Find your Account Sid and Token at twilio.com/console and set it in the appsettings.json
2. Run the sample
4. Open the send page and send yourself a WhatsApp


## Configure receiving WhatsApp messages
For receicing replies we need to configure the Twilio webhook. Note: It is necessary that your application is public available via the internet

1. Deploy application to your webhoster
2. Open https://www.twilio.com/console/sms/whatsapp/sandbox
3. Set "WHEN A MESSAGE COMES IN" parameter with  https://YOURDOMAINAPP.net/WhatsAppReceiver
<img width="396" alt="msedge_2021-02-22_13-13-01" src="https://user-images.githubusercontent.com/18400458/108707012-bd8c9b80-750f-11eb-85d8-3fa40e7a2471.png">
4. Reply to the received WhatsApp
5. Open the Receive page. You should see the reply


## Remarks
The demo makes use of https://www.litedb.org/ to simple store the received WhatsApp. When you are using the code in your environmennt you might replace it with your database provider.