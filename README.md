# NInfra

Infrastructure lib of c#.

- [JsonPatchValidator](#jsonpatchvalidator)
- [LinqExtensions](#linqextensions)
  - Sort-By
  - Search

## JsonPatchValidator

Use `TryVisit` to verify the syntax of `json-patch` and write the error message to `ModelState`, or return `Message`.

```csharp
[HttpPatch]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public IActionResult Update([FromBody, BindRequired] JsonPatchDocument<Column> patch)
{
    // verify the syntax of json-patch
    if (!patch.TryVisit(ModelState))
    {
        return BadRequest(ModelState);
    }

    return Ok();
}
```

## LinqExtensions

C# Linq extension method.

- [Sort By](#sort-by)
- [Search](#search)

### Sort-By

Support one or more sort-by expressions.

```c#
query = query.SortBy(new SortByExpression("[Name Asc]"), new SortByExpression("[CreatedTime Desc]"));
```

Use subs.

```c#
var subs = new Dictionary<string, string>
{
    { "Code", "Id" }
};

query = query.SortBy(subs, new SortByExpression("[Code Asc]"));
```

### Search

```c#

```
