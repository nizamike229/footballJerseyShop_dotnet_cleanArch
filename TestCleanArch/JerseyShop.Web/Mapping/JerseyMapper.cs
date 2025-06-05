using SneakerShop.Domain.Entities;
using SneakersShop.Models.Requests;

namespace SneakersShop.Mapping;

public static class JerseyMapper
{
    public static async Task<Jersey> ToJersey(this JerseyRequest jerseyRequest)
    {
        return new Jersey
        {
            Id = Guid.NewGuid()
                .ToString(),
            Name = jerseyRequest.Name,
            Description = jerseyRequest.Description,
            Price = jerseyRequest.Price,
            ClubName = jerseyRequest.ClubName,
            Image = await SaveImageAsync(jerseyRequest.Image)
        };
    }

    private static async Task<string> SaveImageAsync(string imageBase64)
    {
        if (string.IsNullOrWhiteSpace(imageBase64))
        {
            return null!;
        }

        var base64Data = imageBase64.Split(',')[^1];
        var imageBytes = Convert.FromBase64String(base64Data);

        var fileExtension = GetFileExtension(imageBase64);
        var fileName = $"{Guid.NewGuid()}.{fileExtension}";
        var imagesPath = Path.Combine("./Images");
        var filePath = Path.Combine(imagesPath, fileName);

        if (!Directory.Exists(imagesPath))
        {
            Directory.CreateDirectory(imagesPath);
        }

        await File.WriteAllBytesAsync(filePath, imageBytes);
        return Path.Combine("./Images/", fileName);
    }

    private static string GetFileExtension(string base64String)
    {
        var data = base64String.Split(',')[0];

        return data switch
        {
            not null when data.Contains("jpeg") => "jpg",
            not null when data.Contains("png") => "png",
            not null when data.Contains("gif") => "gif",
            not null when data.Contains("bmp") => "bmp",
            _ => "jpg"
        };
    }
}