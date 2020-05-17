## OpenIDClient

This repo contains an OpenIDClient library to communicate with an IDP Authentication/Authorization Service.  
### Organization

The library is organized as follows:

* An implementation project `OpenIDClient` that contains the implementation of the OpenIDClient
* Test projects:
   * `OpenIDClient.UnitTests`: unit test driver targeting NetCore 3.1.

### Build
   * make build

### Test
   * make test

### Pack
   * make pack

### Client Usage 

```c#
var context = new Context
(
	clientId: "65442a84-c8f4-4dad-9a86-d14dae3954d9", 
	clientSecret: "cmo9lyU2qsy4STD6MojwlphIRcnRn3shC9DhCxGJ6eAfHXh86lWfr5pv6YZ8rsnG", 
	accessTokenUrl: "https://idp-rel.eval.test.com/op/tenant/XYZ123456/token",
	scope: "*"
);

var client = OpenIDClient(context);
var token = await client.GetAccessToken();
```
