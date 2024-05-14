using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HWTDotNetCore.RestAPIWithNLayer.Features.BaganMap;

[Route("api/[controller]")]
[ApiController]
public class BaganMapController : ControllerBase
{
    private async Task<BaganMap> GetDataAsync()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("BaganMap.json");
        var model = JsonConvert.DeserializeObject<BaganMap>(jsonStr);
        return model;
    }
    [HttpGet("map")]
    public async Task<IActionResult> Map()
    {
        var model = await GetDataAsync();
        return Ok(model.Tbl_BaganMapInfoData);
    }
    [HttpGet("{map}")]
    public async Task<IActionResult> InfoDetailData(string map)
    {
        var model = await GetDataAsync();
        return Ok(model.Tbl_BaganMapInfoDetailData.FirstOrDefault(x=> x.Id == map));
    }
    [HttpGet]
    public async Task<IActionResult> TravelList()
    {
        var model = await GetDataAsync();
        return Ok(model.Tbl_TravelRouteListData);
    }
}

public class BaganMap
{
    public Tbl_Baganmapinfodata[] Tbl_BaganMapInfoData { get; set; }
    public Tbl_Baganmapinfodetaildata[] Tbl_BaganMapInfoDetailData { get; set; }
    public Tbl_Travelroutelistdata[] Tbl_TravelRouteListData { get; set; }
}

public class Tbl_Baganmapinfodata
{
    public string Id { get; set; }
    public string PagodaMmName { get; set; }
    public string PagodaEngName { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
}

public class Tbl_Baganmapinfodetaildata
{
    public string Id { get; set; }
    public string Description { get; set; }
}

public class Tbl_Travelroutelistdata
{
    public string TravelRouteId { get; set; }
    public string TravelRouteName { get; set; }
    public string TravelRouteDescription { get; set; }
    public string[] PagodaList { get; set; }
}
