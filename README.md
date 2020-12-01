# CatFacts.Net
.Net Standard 2.0 client for cat-facts API. It supports C# 8.0. Made using RestSharp.

#### Usage
```csharp
var client = new CatFactsClient();
var randomFact = await client.GetRandomFactsAsync();
```

### Features
Supported endpoints: 
* `facts/random`
* `facts/:factID`
* `facts`

> Project is fully tested, using `NUnit` and `FluentAssertion`.


#### Links
* [Source](CatFacts.Net/CatFacts.Net/CatFacts.Net/CatFactsClient.cs) 
* [Cat Facts](https://alexwohlbruck.github.io/cat-facts/) 
* [Documentations](https://alexwohlbruck.github.io/cat-facts/docs/) 

