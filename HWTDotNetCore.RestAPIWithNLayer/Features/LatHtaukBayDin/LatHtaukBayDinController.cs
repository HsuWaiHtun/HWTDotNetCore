using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HWTDotNetCore.RestAPIWithNLayer.Features.LatHtaukBayDin;

[Route("api/[controller]")]
[ApiController]
public class LatHtaukBayDinController : ControllerBase
{
    private async Task<LatHtaukBayDin> GetDataAsync()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
        var model = JsonConvert.DeserializeObject<LatHtaukBayDin>(jsonStr);
        return model;
    }
    //end point - api/LatHtaukBayDin/questions
    [HttpGet("questions")]
    public async Task<IActionResult> Questions()
    {
        var model = await GetDataAsync();
        return Ok(model.questions);
    }

    [HttpGet]
    public async Task<IActionResult> NumberList()
    {
        var model = await GetDataAsync();
        return Ok(model.numberList);
    }

    [HttpGet("{questionsNo}/{no}")]
    public async Task<IActionResult> Answers(int questionsNo, int no)
    {
        var model = await GetDataAsync();

        return Ok(model.answers.FirstOrDefault(x => x.questionNo == questionsNo && x.answerNo == no));
    }
}
public class LatHtaukBayDin
{
    public Question[] questions { get; set; }
    public Answer[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Question
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answer
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}
