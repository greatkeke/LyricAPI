using Microsoft.AspNetCore.Mvc;

namespace LyricAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LyricController : ControllerBase
{
    private readonly string _lyricsFolder = @"/lyrics";
    private readonly ILogger<LyricController> _logger;

    public LyricController(ILogger<LyricController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public object Get(string title = "", string artist = "", string path = "")
    {
        _logger.LogInformation($"api is called, title={title}, artist={artist}, path={path}");

        var location = _lyricsFolder; //Path.GetDirectoryName(path);

        _logger.LogInformation($"Try get lyric at {location}");

        var text = string.Empty;

        var files = System.IO.Directory.EnumerateFiles(location, $"*{title}*.lrc");

        if (files.Any())
        {
            var file = files.FirstOrDefault();

            _logger.LogInformation($"Searched lyric at {file}");

            text = string.Join(Environment.NewLine, System.IO.File.ReadAllLines(file));;
        }

        var a = new
        {
            id = $"{title.GetHashCode()}",
            title = title,
            artist = artist,
            lyrics = text
        };
        return new List<object>() { a };
    }
}
