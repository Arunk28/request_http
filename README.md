# HttpLibrary
Http library used to make rest calls easily in  c# projects

# How to use
 Install this library and  follow the below steps

# Add Name space before using in your class file
```
using System;
using request;
```

# GET
```

                    HttpProperties httpProperty = new HttpProperties()
                    {
                        dictObject = null,
                        methodType = "GET",
                        sync = true,
                        token = this.token.access_token, --optional
                        url =<request url>
                    };

                    object s = Http.HttpRequest(httpProperty);
```

# POST

```
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("xxKey",xxxxvalue);
                    dict.Add("xxKey",xxxxvalue);
                            
                    HttpProperties httpProperty = new HttpProperties()
                    {
                        dictObject = dict,
                        methodType = "POST",
                        sync = true,
                        token = this.token.access_token, --optional
                        url =<request url>
                    };

                    object s = Http.HttpRequest(httpProperty);
```


# PUT

```
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("xxKey",xxxxvalue);
                    dict.Add("xxKey",xxxxvalue);
                            
                    HttpProperties httpProperty = new HttpProperties()
                    {
                        dictObject = dict,
                        methodType = "PUT",
                        sync = true,
                        token = this.token.access_token, --optional
                        url =<request url>
                    };

                    object s = Http.HttpRequest(httpProperty);
```

# DELETE

```
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("xxKey",xxxxvalue);
                    dict.Add("xxKey",xxxxvalue);
                            
                    HttpProperties httpProperty = new HttpProperties()
                    {
                        dictObject = dict,
                        methodType = "DELETE",
                        sync = true,
                        token = this.token.access_token, --optional
                        url =<request url>
                    };

                    object s = Http.HttpRequest(httpProperty);
```
