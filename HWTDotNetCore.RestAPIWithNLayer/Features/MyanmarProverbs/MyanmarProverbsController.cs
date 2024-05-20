using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HWTDotNetCore.RestAPIWithNLayer.Features.MyanmarProverbs;

[Route("api/[controller]")]
[ApiController]
public class MyanmarProverbsController : ControllerBase
{
    private async Task<Tbl_MMProverb> GetDataFromApi()
    {
        //HttpClient client = new HttpClient();
        //var response = await client.GetAsync("https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json");
        //if (!response.IsSuccessStatusCode) return null;

        //string jsonStr = await response.Content.ReadAsStringAsync();
        //var model = JsonConvert.DeserializeObject<Tbl_MMProverb>(jsonStr);
        //return model;

        string jsonStr = await System.IO.File.ReadAllTextAsync("data2.json");
        var model = JsonConvert.DeserializeObject<Tbl_MMProverb>(jsonStr);
        return model;
    }

    [HttpGet]
    public async Task<IActionResult> GetTitle()
    {
        var model = await GetDataFromApi();
        return Ok(model.Tbl_MMProverbsTitle);
    }

    [HttpGet("{titleName}")]
    public async Task<IActionResult> GetTitleName(string titleName)
    {
        var model = await GetDataFromApi();
        var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
        if (item is null) return NotFound();

        var titleId = item.TitleId;
        var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);
        List<Tbl_MMProverbsHead> lst = result.Select(x => new Tbl_MMProverbsHead
        {
            TitleId = x.TitleId,
            ProverbId = x.ProverbId,
            ProverbName = x.ProverbName,
        }).ToList();
        return Ok(lst);
    }

    [HttpGet("{titleId}/{proverbId}")]
    public async Task<IActionResult> GetDetails(int titleId, int proverbId)
    {
        var model = await GetDataFromApi();
        var lst = model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == titleId && x.ProverbId == proverbId);
        return Ok(lst);
    }
}


public class Tbl_MMProverb
{
    public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
    public Tbl_MmproverbsDetails[] Tbl_MMProverbs { get; set; }
}

public class Tbl_Mmproverbstitle
{
    public int TitleId { get; set; }
    public string TitleName { get; set; }
}

public class Tbl_MmproverbsDetails
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
    public string ProverbDesp { get; set; }
}

public class Tbl_MMProverbsHead
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
}