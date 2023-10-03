using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DesignPattern.OpenApi
{
    public class JsonParser
    {
        public string data { get; }

        public JsonParser(string data)
        {
            this.data = data;
        }

        public string GetData()
        {
            return data;
        }
    }

    public static class JFactory
    {
        public static async Task<JsonParser> Create()
        {
            var fileName = "/Users/popai/Projects/DesignPattern/OpenApi/openapi.json";
            var text = await LoadDataAsync(fileName);
            return new JsonParser(text);
        }

        private static async Task<string> LoadDataAsync(string fileName)
        {
            var text = "";

            try
            {
                using (StreamReader sr = new(fileName, Encoding.GetEncoding("UTF-8")))
                {
                    text = await sr.ReadToEndAsync();
                }
            }
            catch (Exception ex)
            {
            }
            return text;
        }

        public static string Dir = "/Users/popai/Projects/DesignPattern/DesignPattern/OpenApi/";
        public static async Task<ApiDoc> GetApiDoc()
        {
            //var fileName = "openapi.json";
            var fileName = $"{Dir}openapi.json";
            var text = await LoadDataAsync(fileName);

            var apiDoc = new ApiDoc();

            var node = JsonNode.Parse(text);
            apiDoc.Title = node?["info"]?["title"]?.GetValue<string>();


            var p = node?["paths"];
            var pathsJson = JsonSerializer.Deserialize<JsonObject>(p.ToJsonString());

            // endpoint 
            foreach (var path in pathsJson)
            {
                var pathValue = JsonNode.Parse(path.Value.ToJsonString());
                var methods = JsonSerializer.Deserialize<JsonObject>(pathValue.ToJsonString());
                var pathStr = path.Key.ToString();

                // method child
                foreach (var method in methods)
                {
                    var methodStr = method.Key.ToString();
                    var methodVal = JsonNode.Parse(method.Value.ToJsonString());
                    var summary = methodVal["summary"];
                    var description = methodVal["description"];
                    var requestBody = methodVal["requestBody"];
                    requestBody = requestBody?["content"]?["application/json"];

                    var re = methodVal["responses"];

                    var responses = JsonSerializer.Deserialize<JsonObject>(re.ToJsonString());
                    // response child
                    var responseItems = new List<Response>();
                    foreach (var response in responses)
                    {
                        var rv = JsonNode.Parse(response.Value.ToJsonString());
                        var responseBody = rv["content"]?["application/json"];
                        responseItems.Add(new Response()
                        {
                            code = response.Key.ToString(),
                            description = rv["description"]?.ToString(),
                            content = responseBody?.ToString(),
                        });
                    }

                    apiDoc.ApiItems.Add(new ApiItem()
                    {
                        path = pathStr,
                        method = methodStr,
                        summary = summary?.ToString(),
                        description = description?.ToString(),
                        requestBody = requestBody?.ToString(),
                        responses = responseItems,
                    });
                }
            }
            List<Schema> Schemas = GetSchima(node);
            apiDoc.Schemas = Schemas;

            Print(apiDoc);

            return apiDoc;
        }

        private static List<Schema> GetSchima(JsonNode node)
        {
            List<Schema> Schemas = new List<Schema>();
            var schemas = node?["components"]?["schemas"];
            var schemasObj = JsonSerializer.Deserialize<JsonObject>(schemas.ToJsonString());
            // schemas 
            foreach (var schema in schemasObj ?? new())
            {
                var Schema = new Schema();
                Schema.name = schema.Key.ToString();

                var prop = schema.Value["properties"];
                if(prop == null)
                    continue;

                var propObj = JsonSerializer.Deserialize<JsonObject>(prop.ToJsonString());
                var propList = new List<Property>();
                foreach (var propItem in propObj ?? new())
                {
                    var p = new Property();
                    p.name = propItem.Key;
                    p.type = propItem.Value["type"]?.ToString(); 
                    p.format = propItem.Value["format"]?.ToString(); 
                    p.example = propItem.Value["example"]?.ToString(); 
                    p.description = propItem.Value["description"]?.ToString(); 
                    propList.Add(p);
                }
                Schema.properties = propList;
                Schemas.Add(Schema);
            }
            return Schemas;
        }

        private static void Print(ApiDoc doc)
        {
            var buff = new StringBuilder();
            foreach (var item in doc.ApiItems)
            {
                buff.AppendLine($"### 概要");
                buff.AppendLine($"{item.summary}");
                buff.AppendLine($"### {item.method} {item.path}");
                buff.AppendLine($"### 説明");
                buff.AppendLine($"{item.description}");

                buff.AppendLine($"### requestBody");
                buff.AppendLine($@"```json title=""Exsample""");
                buff.AppendLine($"{item.requestBody}");
                buff.AppendLine($"```");
                buff.AppendLine($"");

                var ok = item.responses.Find(x => x.code == "200");
                if (ok != null)
                {
                    buff.AppendLine($"### responseBody");
                    buff.AppendLine($@"```json title=""Exsample""");
                    buff.AppendLine($"{ok.content}");
                    buff.AppendLine($"```");
                    buff.AppendLine($"");
                }

                buff.AppendLine($"| コード  | 説明  |");
                buff.AppendLine($"| ------ | ---- |");
                foreach (var response in item.responses)
                {
                    buff.AppendLine($"| **{response.code}** | {response.description} |");
                }

                buff.AppendLine($"");
                buff.AppendLine($"---");
                buff.AppendLine($"");
            }

            // Schema
            buff.AppendLine($"--Schema---");
            foreach(var schema in doc.Schemas){
                buff.AppendLine($"□ {schema.name}");
                buff.AppendLine($"|  プロパティ  |   データ型  | 文字数 |  必須  |         説明       |");
                foreach(var property in schema.properties){
                    var name = (property.name??"").PadRight(10);
                    var format = (property.format??"").PadRight(10);
                    var description = (property.description??"").PadRight(20);
                    buff.AppendLine($"| {name} | {format} |   -   |   -   | {description} |");
                }
            }
            Console.WriteLine(buff);

            // File Write
            Encoding enc = Encoding.GetEncoding("UTF-8");
            StreamWriter writer = new StreamWriter($"{Dir}openapi.md", false, enc);
            writer.WriteLine(buff.ToString());
            writer.Close();
        }
    }

    public class ApiItem
    {
        public string? method { get; set; }
        public string? path { get; set; }
        public string? summary { get; set; }
        public string? description { get; set; }
        public string? requestBody { get; set; }
        public List<Response> responses { get; set; }
    }
    public class Response
    {
        public string code { get; set; }
        public string description { get; set; }
        public string content { get; set; }
    }

    public class ApiDoc
    {
        public string? Title { get; set; }
        public List<ApiItem> ApiItems { get; set; } = new();
        public List<Schema> Schemas { get; set; } = new();
    }
    public class Schema
    {
        public string? name { get; set; }
        public List<Property> properties { get; set; }

    }
    public class Property
    {
        public string? name { get; set; }
        public string? type { get; set; }
        public string? format { get; set; }
        public string? example { get; set; }
        public string? description { get; set; }
    }
}
