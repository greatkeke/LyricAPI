namespace LyricAPITests;

public class LyricTextTest
{
    [Fact]
    public void ReadTextWihoutNewlineChar()
    {
        var path = @"./LyricAPITests.runtimeconfig.json";
        var text = System.IO.File.ReadAllText(path);
        using var reader = new StreamReader(path: path);
        var text2 = reader.ReadToEnd();
        Assert.Equal(text2, text);
    }
}