# JsonPatchValidator

Use `TryVisit` to verify the syntax of `json-patch` and write the error message to `ModelState`, or return `Message`.

## Sample

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
